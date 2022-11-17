import bs4
import requests

for page in range(1,38):

    url = f"https://maplestory.nexon.com/Ranking/World/Total?page={page}&j=3&d=12&w=2"

    result = requests.get(url).text
    parser = bs4.BeautifulSoup(result,'html.parser')
    dt = parser.find_all('td', {'class' : 'left'})
    with open("reboot_name.txt",'a', encoding= 'utf-8') as f:
        
        for a in dt:
            a = a.find('a').text
            print(a)
            f.write(a)
            f.write('\n')

# url = f"https://maplestory.nexon.com/Ranking/World/Total?page={1}&j=3&d=12"

# result = requests.get(url).text
# parser = bs4.BeautifulSoup(result,'html.parser')
# dt = parser.find_all('td', {'class' : 'left'})
# with open("names.txt",'a') as f:
    
#     for a in dt:
#         a = a.find('a').text
#         print(a)
#         # f.write(a)