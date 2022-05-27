# Fullstack Challenge 🏅 2022 - Covid Daily Cases

# Introdução

Aplicação feita em .NET e ReactJS, que exibe em um mapa-múndi, a quantidade de casos de COVID e suas variantes.

## Tecnologias usadas

### Backend

 - .NET 5
 - ASP.NET Core
 - Microsoft.EntityFrameworkCore
 - FluentValidation.AspNetCore
 - FluentValidation.DependencyInjectionExtension
 - MediatR.Extensions.Microsoft.DependencyInjection
 - Pomelo.EntityFrameworkCore.MySql
 - Microsoft.EntityFrameworkCore.Sqlite
 - xunit
 - Moq
 - CsvHelper

### Frontend

 - ReactJS 17
 - TypeScript
 - swr
 - chakra-ui/react
 - react-simple-maps
 
## Instruções para executar o projeto

Primeiramente, clone o repositório:

    git clone https://github.com/sidyjw/CovidDailyCases.git

Caso deseje utilizar o docker-compose, dentro do diretório do projeto execute:

     docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
 

> **Importante:** Talvez seja necessário reiniciar o container da API. O motivo pra isso é que, no setup inicial o container da API tenta se conectar ao container do Banco de Dados, e caso o banco não esteja pronto, irá gerar falha nas migrations. Feito isso, não será mais necessário reiniciar a API.
> 
> 
Se prefirir executar de forma manual, dentro da pasta raiz do projeto execute:

    dotnet run --project API

Por fim, mude para o diretório do projeto ReactJS e inicie a aplicação:

     cd ReactClientApp/app
     npm i
     npm start

> **Importante:** Não esqueça de ajustar a string de conexão do banco de dados no arquivo appsettings.{AMBIENTE}.json
> 
> 
Confira as aplicações nos endereços:

 - **API** -  http://localhost:5000/
 - **Frontend** - http://localhost:3000/

<<<<<<< HEAD
> This is a challenge by [Coodesh](https://coodesh.com/)
=======
> This is a challenge by [Coodesh](https://coodesh.com/)`
>>>>>>> 07df1412ef3f23e4e3c0a3ac91676d649b38b993
