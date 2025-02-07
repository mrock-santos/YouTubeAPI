**YouTubeAPI**

Este projeto é uma API desenvolvida em **.NET 8.0** que permite buscar vídeos na API do YouTube, armazenar os dados em um banco de dados SQLite e fornecer endpoints para gerenciar esses dados. A API foi projetada para seguir boas práticas de desenvolvimento, como o uso de injeção de dependência, Entity Framework Core para acesso a dados e padrões RESTful para os endpoints.

-----
**Funcionalidades Principais**

1. **Buscar Vídeos na API do YouTube**:
   1. Realiza buscas na API do YouTube com base em um termo de pesquisa e uma data de publicação.
   1. Armazena os vídeos retornados no banco de dados SQLite.
1. **Endpoints para Gerenciamento de Vídeos**:
   1. **Inserir**: Adiciona um novo vídeo ao banco de dados.
   1. **Atualizar**: Atualiza os dados de um vídeo existente.
   1. **Excluir (Lógico)**: Marca um vídeo como excluído sem removê-lo fisicamente do banco de dados.
   1. **Buscar e Popular**: Busca vídeos na API do YouTube e os insere automaticamente no banco de dados.
1. **Banco de Dados SQLite**:
   1. Utiliza o Entity Framework Core para gerenciar o banco de dados SQLite.
   1. Migrações automáticas para criar e atualizar o esquema do banco de dados.
-----
**Frameworks e Pacotes Utilizados**

Abaixo estão os principais frameworks e pacotes utilizados no projeto:

**Frameworks**

- **.NET 8.0**: Versão do .NET utilizada para desenvolvimento.
- **ASP.NET Core**: Framework para construção de APIs web.

**Pacotes Principais**

- **Microsoft.EntityFrameworkCore.Sqlite**: Fornece suporte ao SQLite no Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Design**: Necessário para criar e aplicar migrações.
- **Microsoft.AspNetCore.Mvc.Core**: Fornece funcionalidades para criação de controllers e endpoints.
- **Microsoft.Extensions.Configuration**: Utilizado para acessar configurações do appsettings.json.
- **Newtonsoft.Json**: Utilizado para deserializar respostas JSON da API do YouTube.
- **Microsoft.EntityFrameworkCore.Tools**: Ferramentas para gerenciar migrações via CLI.

**Outros Pacotes**

- **Microsoft.Extensions.Http**: Para configurar o HttpClient usado na integração com a API do YouTube.
- **Swashbuckle.AspNetCore**: Para gerar documentação automática da API via Swagger (opcional).
-----
**Como Configurar o Projeto**

**Pré-requisitos**

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [SQLite](https://sqlite.org/index.html) (já incluído no projeto via Entity Framework Core)

**Passos para Configuração**

1. **Clone o Repositório**:

bash

Copy

git clone https://github.com/seu-usuario/YouTubeAPI.git

cd YouTubeAPI

1. **Configure o appsettings.json**:
   1. Adicione sua chave da API do YouTube no arquivo appsettings.json:

json

Copy

{

`  `"YouTubeApi": {

`    `"ApiKey": "SUA\_CHAVE\_DE\_API\_DO\_YOUTUBE",

`    `"BaseUrl": "https://www.googleapis.com/youtube/v3/"

`  `},

`  `"ConnectionStrings": {

`    `"DefaultConnection": "Data Source=YouTubeApiDb.sqlite"

`  `}

}

1. **Aplique as Migrações**:
   1. Execute o seguinte comando para criar o banco de dados SQLite:

bash

Copy

dotnet ef database update

1. **Execute o Projeto**:
   1. Inicie a API com o comando:

bash

Copy

dotnet run

1. A API estará disponível em http://localhost:5000 ou https://localhost:5001.
-----
**Endpoints da API**

A API fornece os seguintes endpoints:

**1. Buscar e Popular Vídeos**

- **Método**: GET
- **URL**: /api/videos/search-and-populate
- **Parâmetros**:
  - query: Termo de busca (ex: "manipulação de medicamentos").
  - publishedAfter: Filtra vídeos publicados após uma data específica (ex: 2025-01-01T00:00:00Z).
- **Exemplo**:

bash

Copy

GET /api/videos/search-and-populate?query=manipulação+de+medicamentos&publishedAfter=2025-01-01T00:00:00Z

**2. Inserir Vídeo**

- **Método**: POST
- **URL**: /api/videos/inserir
- **Corpo da Requisição** (JSON):

json

Copy

{

`  `"titulo": "Como manipular medicamentos",

`  `"descricao": "Vídeo sobre boas práticas na manipulação de medicamentos.",

`  `"canal": "Canal Saúde",

`  `"dataPublicacao": "2025-01-01T00:00:00",

`  `"duracao": "PT10M30S"

}

**3. Atualizar Vídeo**

- **Método**: PUT
- **URL**: /api/videos/atualizar/{id}
- **Corpo da Requisição** (JSON):

json

Copy

{

`  `"id": 1,

`  `"titulo": "Como manipular medicamentos - Atualizado",

`  `"descricao": "Vídeo atualizado sobre boas práticas na manipulação de medicamentos.",

`  `"canal": "Canal Saúde",

`  `"dataPublicacao": "2025-01-01T00:00:00",

`  `"duracao": "PT10M30S"

}

**4. Excluir Vídeo (Lógico)**

- **Método**: DELETE
- **URL**: /api/videos/excluir/{id}
- **Exemplo**:

bash

Copy

DELETE /api/videos/excluir/1

