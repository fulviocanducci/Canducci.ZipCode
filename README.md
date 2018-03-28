# Canducci ZipCode and AddressCode

[![Canducci.Zip](https://6w6tag.bn1304.livefilestore.com/y4mfIUSRjndxz0Gi9liAONy94MJIAT5Fi_FBeeiT-TBjpBQV6SID2wt8PVRcaJ68sz4FxlbzfMJ_SynJEy5C_-iR_WAuNo7_sAFtiDCV7_ZrXH6LabC6yTWbZ0L7NSPvDO8tPjHNMdZcKL7q7UXl6q2F7437Tqks0aK7vPCTiVIviUdOIx8vfx9kS2-LRSElFP4Vg0CTftpqKEX-k0F_UOjC1C7TXVb777pX7YD-XCqyAk/if_Facebook_UI-08_2344308.png)](https://www.nuget.org/packages/Canducci.Zip/)

[![Version](https://img.shields.io/nuget/v/Canducci.Zip.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.Zip/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.Zip.svg)](https://www.nuget.org/packages/Canducci.Zip/)
[![Build Status](https://travis-ci.org/fulviocanducci/Canducci.Zip.svg?branch=master)](https://travis-ci.org/fulviocanducci/Canducci.Zip)

## Instalação do Pacote


```
PM> Install-Package Canducci.Zip
```

## Utilização

### Busca de CEP

Para a busca de dados de um determinado número de **CEP** instancie a classe `ZipCodeLoad` e no seu método `Find` ou (`FindAsync` a partir do `NET 4.5`) passe o número e se a resposta estiver satisfatória os dados estão na classe de resultado `ZipCodeResult`, ***exemplo***:

```csharp
IZipCodeLoad zipCodeLoad = new ZipCodeLoad();
ZipCodeResult result0 = zipCodeLoad.Find("19200000");
if (result0)
{
    ZipCodeItem zipCodeItem = result0;
}
```
### Busca de uma lista de CEP
