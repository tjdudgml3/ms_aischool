import torch
import os
import glob
from torch.utils.data import Dataset
from torchvision import datasets

def get_classes(data_dir):
    all_data = datasets.ImageFolder(data_dir)
    return all_data.classes

test = get_classes("./data/train/")
print(test)

label_dict = {}
for i, (labels) in enumerate(test):
    label_dict[labels] = int(i)

print(label_dict)

class my_customdata(Dataset):
    def __init__(self, path, transform=None):
        self.all_path = glob.glob(os.path.join(path, "*", "*.jpg"))
        self.transform = transform
