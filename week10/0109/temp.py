import torch
import torchvision
import torch.nn as nn 
from customdata import my_customdata
import os
import copy

os.environ['KMP_DUPLICATE_LIB_OK']='True'
import albumentations as A
# from albumentations.pytorch.transforms import ToTensorV2
# from torch.utils.data import DataLoader
# from timm.loss import LabelSmoothingCrossEntropy
import os
import copy


os.environ['KMP_DUPLICATE_LIB_OK']='True'
# device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
