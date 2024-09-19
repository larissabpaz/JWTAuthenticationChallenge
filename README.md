# API de Autentica��o JWT

## Descri��o

Este projeto � uma API simples constru�da com ASP.NET Core que implementa autentica��o usando JSON Web Tokens (JWT). A API permite registrar usu�rios, fazer login para obter um token JWT e acessar endpoints protegidos usando esse token.

## Pr�-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started) (opcional, para containeriza��o)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/) (para desenvolvimento)

## Instala��o e Execu��o

1. **Clonar o Reposit�rio**

   Clone este reposit�rio para sua m�quina local com o comando `git clone https://github.com/larissabpaz/JWTAuthenticationChallenge.git`;
   Navegue at� o diret�rio do projeto com `cd your-repo-name`. 	
   Execute `dotnet restore` para restaurar as depend�ncias do projeto e, em seguida, inicie a aplica��o com `dotnet run`.
   A API estar� dispon�vel em `https://localhost:7105`.


## Endpoints

A API oferece tr�s principais endpoints:

1. **Registro de Usu�rio:** O endpoint para registrar um novo usu�rio est� dispon�vel no m�todo `POST` na URL `/api/Auth/register`. 

2. **Login:** Para fazer login e obter um token JWT, use o m�todo `POST` na URL `/api/Auth/login`. 

3. **Endpoint Protegido:** O m�todo `GET` na URL `/api/Auth/protected` permite acesso protegido que requer um token JWT v�lido. 
   O token deve ser enviado no cabe�alho da requisi��o com o formato `Authorization: Bearer <your.jwt.token.here>`. 

