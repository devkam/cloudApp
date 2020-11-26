## WebApi side
Implement WebApi following endpoints:

- `POST /api/images` - creates image in the system

Request body specification:
|Name|Description|
|-|-|
|name|Image's name|
|description|Specifies description of image|
|author|Specifies author of image|
|imageContent|Base64 content of image|

Sample payload:
```
{ 
  "name": "Question Mark", 
  "description": "Image showing red question mark", 
  "author": "Picasso", 
  "imageContent": "iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAALEgAACxIB0t1+/AAAABx0RVh0U29mdHdhcmUAQWRvYmUgRmlyZXdvcmtzIENTNui8sowAAAAWdEVYdENyZWF0aW9uIFRpbWUAMDEvMjgvMTVur1KVAAAFDElEQVRYhc2ZTYiVVRjHf+f9mO8PR5vMKxnhgIIWYdqi6YPARYuwlZBBUSAJElkLxV1BizaFiwqKWgjiqGREiS7CgpE0sJKsjUaaOvQhziyccXTGuff+W5zz3jv33vfrzgziA+fel/eej995znme85znGkk0LcaEwCCwEVgHrAKWAp2uxiRwFTgPnAGOAyeRZpoeS1L+AgOCDwWjAjVZRl3bgWbGzAtWEOwXFOcAVl+Krq/CwgDCNsH4AoDVl3HBtrkDQptgKHGAILTFCyTjSZjaYjzJ+JIfZoEOCdqSOEyskRjTC3wDPFXz3g/BuOeyoFyyzy0h9HRBeydgYOoWTIzD9G2LYHzwPVu3GGsnJ4BNSNezjcRqbjh2tn4oBS1WMyD19Uovb5G+PiRNjqgipTFp+Kj01nbp/mWuvbFtg0SNDsdpslGDxgwBWxpm4odgDJRKoBI89gh8dRgKK+HXM/DLCfjtIgSChwdgzSCsX2/bbt4EXx61GEEIxduxHgU4gPRisgatQSTvOS+wz48/ajV16Q/p6Sel1lbJmGpdY6SWVmnDOun0KVt3+ytub/pZe7LGcGbDFVKtNWix34v7pKuXpZGL0rL+WXUiw4gMxr3v7pRO/2AhH1pd3Srp1l2IA9yfqr1o5rvfsIMNbnDa8tzeqivhrL266kHb5uM9klc3gfiyvxbQnhDJTjjSXleX9Pcl6ewpKQztQKHb+H5dCUL7G8Y+nx6Wxi5bw5rdZ7IzH5CEs312AH7SzgVnSP39UHgAPt0LxSJ4nusyoYkExoNyGY4dgcUroLOnts948R0Tnjv4G602kiCs9rV8sf2+Nu7emYRGMbTTN+1j3iawBWNCDxuVLEnv3xF2djvAKzVjZ7b1PHjiGRi9ApMT5CRdAgwG2JApZQCs//MDOPETLLkHJm+A76cPYiL4MixbChufg32fw/WJPHCRbAyw8Vy6GPcxNQW3blqNeF6y9qL6pdsQ+PDRB9DSBp/ttY7eD8lWPQDrEFzIMPlay4yz2AYLdtaLkXY5t/T+u9bFRG4pO4iQ4AKCG7kB85QIzhjp9a3SzIx05KDU2V71qVHdbMAb5KjUBJzzjX4g7XpTKs1I3x62p0k9XD5ALRxgpDnPl97ZbZf16EGpu6PaxxwB57/ElRDMSK+9ZOH2fSK1tVY1F7d3cy5xfiNJKyCtXW3hvjsmtWfA5TQSD3s1TJdSym0xihGDAN7eBf9dgVe3wq1p507yepRYOe9h763zlDIsWgTPbobDX8DIv4AHnkmGS5t0Vc542Ev13CU6Bu/rs5Hyz79bqCiQmJ8c94CTwFhm1bgZm1mAK1ZCRxdc/QuQXfr5yRhw0sOmIw7MrY/KgQt9/dDSAtdGG35qkHzLewBpxl6ajBkAzpEaEzqJNn4EUXb2tvxeWDMAP56FCRdMzB2wBKxG+pNcIX+aywnCxug4SIiy87uXSshfvXYaU3Ba7M6tQdvOXuDLZehoh6lpO4QfAGrUYrb2Jpz2/gEqIT/uxc6s1rVwWB8I8MLz8P1x2L0DwgBKxcb6+fbezgjOcTVkFpLzMfXLXLlM9Ugjl1xWYdre4qKlbm5ph7KTR2mpjwbA0MV3obTnPQt45JDU3a3KbS4/XGzqoxHQQvbmhvTdnbm9Q1q7SurpqWa18gMOC3oXNv0WQQazIKPsQnOhVWr6LRmwCnqXJjBrIe/iFHAt6B1PosdnWDP93537G+J/WYYMciWSwvcAAAAASUVORK5CYII=" 
}
```

- `GET /api/images/:id` - retrievies specirfic image by ID/Guid

Sample response (**without miniatrue**):
```
{
  "name": "Question Mark", 
  "description": "Image showing red question mark", 
  "author": "Picasso", 
  "created": "2020-11-02T12:58:28.069Z",   
  "imageLink": "https://fpcloudstorageacc.blob.core.windows.net/images/028a4b01-973a-4e21-8f96-d66278250f93.jpg" 
}
```

- `GET /api/images` - retrieves list of images

Sample response (**with miniature**):
```
[{
  "name": "Question Mark", 
  "description": "Image showing red question mark", 
  "author": "Picasso", 
  "created": "2020-11-02T12:58:28.069Z", 
  "imageLink": "https://fpcloudstorageacc.blob.core.windows.net/images/028a4b01-973a-4e21-8f96-d66278250f93.jpg", 
  "miniatureLink": "https://fpcloudstorageacc.blob.core.windows.net/miniatures/028a4b01-973a-4e21-8f96-d66278250f93.png" 
}, {
  "name": "Another image", 
  "description": "Sample description"
  "author": "Sample author", 
  "created": "2020-12-01T10:00:00.000Z", 
  "imageLink": "https://fpcloudstorageacc.blob.core.windows.net/images/440c7e53-e493-4214-b765-b3b1e07d55f4.jpg", 
  "miniatureLink": "https://fpcloudstorageacc.blob.core.windows.net/miniatures/440c7e53-e493-4214-b765-b3b1e07d55f4.png" 
}]
```
### Processing images 
During `POST` image request you should:
- generate current datetime and save it to metadata (**created** property),
- decode base64's image content and store it as file (with `*.png` for example) in the Azure Blob Storage,
- add link to stored image to the metadata (**imageLink** field),
- store metadata (without **imageContent**) in the relational database (for example you can use `Azure SQL Database` or `Azure Database for PostgreSQL`),
- send new message to the Azure Queue, with id of image stored in database.

## Serverless side
Create and implement Azure Function to fit following criteria:
- retrieve image metadata from database by provided id,
- get image from Azure Blob Storage container, based on tje **imageLink** field,
- generate image miniature of requested size (for example 100x100),
- save generated thumbnail in the Azure Blob Storage,
- update database metadata, adding link to miniature (**miniatureLink** property).
