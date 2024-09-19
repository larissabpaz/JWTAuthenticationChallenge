# API de Autenticação JWT

## Descrição

Este projeto é uma API simples construída com ASP.NET Core que implementa autenticação usando JSON Web Tokens (JWT). A API permite registrar usuários, fazer login para obter um token JWT e acessar endpoints protegidos usando esse token.

## Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started) (opcional, para containerização)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/) (para desenvolvimento)

## Instalação e Execução

1. **Clonar o Repositório**

   Clone este repositório para sua máquina local com o comando `git clone https://github.com/yourusername/your-repo-name.git`;
   Navegue até o diretório do projeto com `cd your-repo-name`. 	
   Execute `dotnet restore` para restaurar as dependências do projeto e, em seguida, inicie a aplicação com `dotnet run`.
   A API estará disponível em `https://localhost:7105`.


## Endpoints

A API oferece três principais endpoints:

1. **Registro de Usuário:** O endpoint para registrar um novo usuário está disponível no método `POST` na URL `/api/Auth/register`. 

2. **Login:** Para fazer login e obter um token JWT, use o método `POST` na URL `/api/Auth/login`. 

3. **Endpoint Protegido:** O método `GET` na URL `/api/Auth/protected` permite acesso protegido que requer um token JWT válido. 
   O token deve ser enviado no cabeçalho da requisição com o formato `Authorization: Bearer <your.jwt.token.here>`. 

