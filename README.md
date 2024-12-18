# Canducci ZipCode and AddressCode

[![Canducci.Zip](https://raw.githubusercontent.com/fulviocanducci/Canducci.ZipCode/master/images/base.png)](https://www.nuget.org/packages/Canducci.Zip/)

[![Version](https://img.shields.io/nuget/v/Canducci.Zip.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.Zip/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.Zip.svg)](https://www.nuget.org/packages/Canducci.Zip/)
![Github Workflows](https://github.com/fulviocanducci/Canducci.ZipCode/workflows/.NET%20Core/badge.svg)
## Instalação do Pacote


```
PM> Install-Package Canducci.Zip
```

## Utilização

### Busca de CEP

Para a busca de dados de um determinado número de **CEP** instancie a classe `ZipCodeLoad` e no seu método `Find` ou `FindAsync` passe o número e se a resposta estiver satisfatória os dados estão na classe de resultado `ZipCodeResult`, ***exemplo***:

```csharp
IZipCodeLoad zipCodeLoad = new ZipCodeLoad();
ZipCodeResult result0 = zipCodeLoad.Find("01001000");
if (result0) // ou result0.IsValid
{
    ZipCodeItem zipCodeItem = result0; //ou zipCodeItem zipCodeItem = result0.Value;
}
```

A saída da classe `ZipCodeItem` é a seguir:

```
ZipCodeItem.Zip        // cep
ZipCodeItem.Address    // logradouro
ZipCodeItem.District   // bairro
ZipCodeItem.City       // localidade
ZipCodeItem.Uf         // uf
ZipCodeItem.Ibge       // Ibge
ZipCodeItem.Complement // complemento
ZipCodeItem.Gia        // gia
ZipCodeItem.Siafi      // siafi
ZipCodeItem.Ddd        // ddd
ZipCodeItem.Unity      // unidade
ZipCodeItem.State      // estado
ZipCodeItem.Region     // região
```

### Busca de uma lista de CEP

```csharp
IAddressCodeLoad addressCodeLoad = new AddressCodeLoad();
AddressCode addressCode = AddressCode.Parse(ZipCodeUf.SP, "SÃO PAULO", "AVE");
AddressCodeResult result1 = addressCodeLoad.Find(addressCode);
if (result1) // ou result1.IsValid
{
    AddressCodeItem items = result1; // ou  AddressCodeItem items = result1.Value;
}
```
Note que a saída da classe `AddressCodeItem` é uma enumeração (`List<>`) de `ZipCodeItem`, ou seja, `List<ZipCodeItem>`.

### Lista de Unidade Federativa

Tanto no objeto de instancia das classes `AddressCodeLoad` e `ZipCodeLoad` existe um método de extensão que retorna um `IDictionary<string, string>` que pode ser utilizado em suas telas para padronização da informação, ***exemplo***: 

```
IZipCodeLoad zipCodeLoad = new ZipCodeLoad();
IAddressCodeLoad addressCodeLoad = new AddressCodeLoad();

System.Collections.Generic.IDictionary<string, string> items0_List = zipCodeLoad.UFToList(); 
System.Collections.Generic.IDictionary<string, string> items1_List = addressCodeLoad.UFToList();
```
Essas duas variaveis (`items0_List` e `items1_List`) são da mesma instância e são geradas a partir do `Enum` `ZipCodeUf` o mesmo para facilitar na criação de suas `interfaces` de programação.

### Aplicação MVC Core

No exemplo do `controller` `TestController` tem dois métodos:

```c#
[HttpPost]
public async Task<IActionResult> Index([FromBody] ZipCodeData data)
{
 if (ModelState.IsValid)
 {
	if (ZipCode.TryParse(data.Value, out ZipCode zipCode))
	{
	   ZipCodeResult zipCodeResult = await ZipCodeLoad.FindAsync(zipCode);
	   return Json(zipCodeResult);
	}
 }
 return Json(new { IsValid = false });
}

[HttpPost]
public async Task<IActionResult> Address([FromBody] AddressCodeData data)
{
 if (AddressCode.TryParse(ParseZipCodeUf(data.Uf), data.City, data.Address, out AddressCode addressCode))
 {
	AddressCodeResult addressCodeResult = await AddressCodeLoad.FindAsync(addressCode);
	return Json(addressCodeResult);
 }
 return Json(new { IsValid = false });
}

private ZipCodeUf ParseZipCodeUf(string uf) => Enum.Parse<ZipCodeUf>(uf);
```

com o código que retornar um `json` para `Front-End` de como utilizar o pacote [Canducci.Zip](https://www.nuget.org/packages/Canducci.Zip/) e [nesse link todo o projeto exemplo](https://github.com/fulviocanducci/Canducci.ZipCode/tree/master/WebAppTest).