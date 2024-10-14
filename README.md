# 123 Vendas API
![](https://github.com/hudson-nttdata/123Vendas/blob/main/docs/github-thumb-readme-123-vendas.png?raw=true?raw=true?w=200)

## Descrição
Este projeto é uma [API](https://pt.wikipedia.org/wiki/Interface_de_programa%C3%A7%C3%A3o_de_aplica%C3%A7%C3%B5es) de ([CRUD](https://pt.wikipedia.org/wiki/CRUD) completo) que manipula os registros de vendas. Foi construída usando .NET Core 8.

Não existe base de dados para este projeto, as dados serão criados em memória portanto não serão persistidos.

## Pré requisitos
* [Instalar o GIT](https://git-scm.com/downloads/win) - Sistema de controle de versões;
* [Instalar o .NET SDK](https://dotnet.microsoft.com/en-us/download) - Plataforma de desenvolvimento.

Use preferencialmente as [IDEs](https://www.alura.com.br/artigos/o-que-e-uma-ide) Visual Studio ou Visual Code.

## Configuração
### Comandos para executar a API em ambiente local

Abra um terminal

Crie um clone do projeto com o comando abaixo:
```shell
$ git clone https://github.com/hudson-nttdata/123Vendas.git
```
Acesse o diretório do código fonte da API
```shell
$ cd .\src\123Vendas.Api
```

## Execução
Execute os comandos para restaurar as dependencias, compilar e executar o projeto.
```shell
$ dotnet restore
$ dotnet build
$ dotnet run
```
Neste projeto foram habilitados o [Swagger UI](https://swagger.io/tools/swagger-ui/) e o [Redoc](https://github.com/Redocly/redoc) para visualizar as operações da API 123 Vendas, portanto
para acessar a documentação da API via browser use uma das url:
* http://localhost:5173/swagger
* http://localhost:5173/redoc

## Teste
### Bibliotecas para Teste de unidade
* [Bogus]();
* [FluentAssertions]();
* [NSubstitute]();
* [XUnit]();

### Executar o teste
```shell
$ dotnet tests
```

## Tecnologia e padrões
### Bibliotecas

* [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-8.0)
* [Serilog]();

### Princípios de Design de Software

* [APIs REST]();
* [Clean Code]();
* [Convencional commit ou Commit semântico]();
* [DRY](t.ly/FXtcJ);
* [Git Flow]();
* [Object Calisthenics](t.ly/97BhJ);
* [S.O.L.I.D.]();
* [YAGNI](t.ly/0i4y8);


## Equipe

Hudson Nascimento