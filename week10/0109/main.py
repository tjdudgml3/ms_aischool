import torch
import torchvision
import torch.nn as nn 
from customdata import my_customdata
import os
import copy
os.environ['KMP_DUPLICATE_LIB_OK']='True'
import albumentations as A
from albumentations.pytorch.transforms import ToTensorV2
from torch.utils.data import DataLoader
from timm.loss import LabelSmoothingCrossEntropy
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

train_transforms = A.Compose([
    A.SmallestMaxSize(max_size=224),
    A.ShiftScaleRotate(shift_limit=0.08, scale_limit=0.08, rotate_limit=0.08, p=0.8),
    A.RandomShadow(p=0.6),
    A.HorizontalFlip(p=.5),
    A.VerticalFlip(p=.5),
    A.Normalize(mean=(0.485, 0.456, 0.406), std=(0.229, 0.224, 0.255)),
    ToTensorV2()
])

val_transforms = A.Compose([
    A.SmallestMaxSize(max_size=224),
    A.Normalize(mean=(0.485, 0.456, 0.406), std=(0.229, 0.224, 0.255)),
    ToTensorV2()
])


# dataset 
train_dataset = my_customdata("./data/train/", transform=train_transforms) 
val_dataset = my_customdata("./data/val/", transform=val_transforms)

# dataloader
train_loader = DataLoader(train_dataset, batch_size=64, shuffle=True, num_workers=2, pin_memory=True)
val_loader = DataLoader(val_dataset, batch_size=64, shuffle=False, num_workers=2, pin_memory=True)

model = torch.hub.load('facebookresearch/deit:main', 'deit_tiny_patch16_224', pretrained=True)
model.head = nn.Linear(in_features=192, out_features=100)

criterion = LabelSmoothingCrossEntropy()
optimizer = torch.optim.AdamW(model.parameters(), lr=0.001)

exp_lr_Scheduler = torch.optim.lr_scheduler.StepLR(optimizer, step_size=30, gamma=0.1)
# print(model)
import time
def train(model, criterion, train_loader, val_loader, optimizer, scheduler, num_epochs=100, device=device):
    since = time.time()
    total = 0
    best_loss = 9999
    best_model_wts = copy.deepcopy(model.state_dict())
    # best_acc = 0.0
    
    for epoch in range(num_epochs):
        print(f"Epoch {epoch} / {num_epochs -1}")
        print("_"*10)
        
        for index, (image,label) in enumerate(train_loader):
            image, label = image.to(device), label.to(device)
            output = model(image)
            loss = criterion(output, label)
            scheduler.step()
            optimizer.zero_grad()
            loss.backward()
            optimizer.step()
            
            _, argmax = torch.max(output, 1)
            acc = (label == argmax).float().mean()
            total += label.size(0)
            
            if( index+ 1) %10 == 0:
                print("Epoch [{}/{}], Step [{}/{}], Loss = {:.4f}, Acc {:.2f}".format(epoch+1, num_epochs, index+1, len(train_loader), loss.item(), acc.item*100))
                
        avg_loss, val_acc = validation(epoch, model, val_loader, criterion, device)
        if avg_loss < best_loss:
            best_loss = avg_loss
            best_model_wts = copy.deepcopy(model.state_dict())
            save_model(model, save_dir = "./")
            
    time_elapsed = time.time() - since
    print("Training complete in {:.4f}m {:.0f}s".format(time_elapsed//60, time_elapsed%6))
    model.load_state_dict(best_model_wts)
    
    
def validation(epoch, model, val_loader, criterion, device):
    print("Start validation # {}".format(epoch + 1))
    
    model.eval()
    with torch.no_grad():
        total = 0
        correct = 0
        total_loss = 0
        cnt = 0
        batch_loss = 0
        for i, (imgs, labels) in enumerate(val_loader):
            imgs, labels = imgs.to(device), labels.to(device)
            output = model(imgs)
            loss = criterion(output, labels)
            batch_loss += loss.item()
            
            total = imgs.size(0)
            _, argmax = torch.max(output,1)
            correct += (labels == argmax).sum().item()
            total_loss += loss
            cnt += 1
            
    avg_loss =total_loss/ cnt
    val_acc = (correct/ total * 100)
    print("Validation #{} Acc :{:.4f} Average Loss :{:.4f".format(epoch + 1, correct / total * 100, avg_loss))
    
    return avg_loss, val_acc


def save_model(model, save_dir, file_name = "best.pt"):
    output_path = os.path.join(save_dir, file_name)
    torch.save(model.state_dict(), output_path)

if __name__ == "__main__":
    train(model, criterion, train_loader, val_loader, optimizer, scheduler=exp_lr_Scheduler, device=device)