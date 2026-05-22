# FinancingSimulatorApi

API REST desenvolvida com **ASP.NET Core** para simulação de financiamento imobiliário utilizando os sistemas de amortização **SAC** e **PRICE**.

O projeto começou como uma aplicação Console em C# e foi migrado para uma Web API com banco de dados, autenticação JWT, validações, persistência de usuários e histórico de simulações.

---

## Objetivo

O objetivo do projeto é permitir que usuários realizem simulações de financiamento imobiliário, visualizando informações como:

- valor financiado;
- parcelas;
- amortização;
- juros;
- saldo devedor;
- total pago;
- total de juros;
- total amortizado.

Além da simulação livre, usuários autenticados podem salvar simulações em um histórico pessoal e consultar novamente essas simulações posteriormente.

O projeto também funciona como estudo prático de backend com C#, ASP.NET Core, Entity Framework Core, PostgreSQL, autenticação JWT e arquitetura em camadas.

---

## Tecnologias Utilizadas

### Linguagens

- C#
- SQL
- JSON

### Frameworks e Bibliotecas

- ASP.NET Core Web API
- Entity Framework Core
- Npgsql
- Swagger / OpenAPI
- BCrypt.Net-Next
- JWT Bearer Authentication

### Banco de Dados

- PostgreSQL

### Ferramentas

- VS Code
- Git
- GitHub
- DBeaver
- Postman
- Swagger UI
- dotnet CLI
- dotnet ef

---

## Evolução do Projeto

### 1. Aplicação Console

A primeira versão do projeto foi criada como uma aplicação Console em C#.

Nessa fase:

- os dados eram digitados manualmente no terminal;
- os cálculos eram executados diretamente na aplicação;
- os resultados eram exibidos no console;
- a lógica estava mais centralizada;
- não havia API HTTP;
- não havia banco de dados;
- não havia autenticação.

A lógica principal de simulação já existia nessa etapa, incluindo os cálculos dos sistemas SAC e PRICE.

---

### 2. Migração para ASP.NET Core Web API

Depois, o projeto foi migrado para uma API REST utilizando ASP.NET Core Web API.

Essa etapa teve como objetivo transformar a aplicação em um backend moderno, capaz de:

- receber requisições HTTP;
- retornar respostas em JSON;
- expor endpoints;
- separar responsabilidades;
- permitir testes com Swagger e Postman;
- preparar o projeto para integração com front-end.

---

### 3. Organização em Camadas

O projeto foi reorganizado em uma estrutura mais modular:

```txt
FinancingSimulatorApi/
│
├── Controllers/
├── DTOs/
├── Models/
├── Services/
├── Data/
├── Migrations/
├── Properties/
├── Program.cs
└── SimuladorFinanciamentoApi.csproj
```

As principais responsabilidades ficaram divididas assim:

- **Controllers:** recebem requisições HTTP e retornam respostas da API.
- **DTOs:** definem os dados de entrada e saída da API.
- **Models:** representam entidades do banco e objetos de domínio/cálculo.
- **Services:** concentram regras de negócio, cálculos, autenticação e persistência.
- **Data:** contém o `AppDbContext` e a configuração de acesso ao banco.
- **Migrations:** armazenam o versionamento da estrutura do banco de dados.

---

### 4. Integração com PostgreSQL e Entity Framework Core

O projeto passou a utilizar PostgreSQL como banco de dados relacional.

A integração é feita com Entity Framework Core e Npgsql.

Foram implementados:

- `AppDbContext`;
- `DbSet<Usuario>`;
- `DbSet<Simulacao>`;
- migrations;
- persistência de usuários;
- persistência de simulações;
- relacionamento entre usuário e simulação.

O Entity Framework Core é utilizado para mapear classes C# para tabelas, gerar SQL automaticamente, controlar migrations e persistir dados com `SaveChangesAsync()`.

---

### 5. CRUD de Usuários

Foi implementado um CRUD completo de usuários.

A API permite:

- criar usuários;
- listar usuários;
- buscar usuário por ID;
- atualizar usuário;
- remover usuário.

Nessa etapa foram aplicados conceitos como:

- DTO de criação;
- DTO de atualização;
- DTO de resposta;
- Entity Tracking;
- `FindAsync`;
- `FirstOrDefaultAsync`;
- `SaveChangesAsync`;
- status HTTP;
- separação entre entidade e DTO.

---

### 6. Validações

Foram adicionadas validações nos DTOs usando Data Annotations.

Foram utilizados recursos como:

- `[Required]`;
- `[EmailAddress]`;
- `[StringLength]`;
- `[Range]`.

Com isso, a API passou a validar automaticamente os dados recebidos antes de executar a lógica de negócio.

---

### 7. Hash de Senha com BCrypt

A aplicação passou a armazenar senhas de forma mais segura utilizando BCrypt.

A senha não é salva em texto puro. Durante o cadastro, ela é transformada em hash antes de ser persistida no banco.

O BCrypt foi utilizado por ser adequado para armazenamento de senhas, pois trabalha com:

- salt automático;
- fator de custo;
- hash irreversível;
- verificação segura no login.

A API não retorna senha nem hash de senha nas respostas.

---

### 8. Login e JWT

Foi implementado o login com e-mail e senha.

O processo atual funciona assim:

1. O usuário informa e-mail e senha.
2. A API busca o usuário pelo e-mail.
3. A senha é verificada com BCrypt.
4. Se as credenciais forem válidas, a API gera um token JWT.
5. O cliente usa esse token nas próximas requisições protegidas.

O JWT contém claims básicas do usuário, como:

- ID;
- nome;
- e-mail.

Essas informações permitem que a API identifique o usuário autenticado sem receber o ID manualmente na requisição.

---

### 9. Rotas Protegidas

Foram adicionadas rotas protegidas com `[Authorize]`.

As rotas protegidas exigem que o cliente envie um token JWT válido no cabeçalho da requisição.

O pipeline de autenticação e autorização valida o token, monta o usuário autenticado e permite ou bloqueia o acesso conforme necessário.

Também foi criado um endpoint para consultar os dados do usuário logado com base nas claims do token.

---

### 10. Relacionamento entre Usuário e Simulação

Foi implementado o relacionamento entre usuários e simulações.

A relação atual é:

```txt
Usuario 1 ---- N Simulacoes
```

Ou seja:

- um usuário pode ter várias simulações;
- uma simulação pertence a apenas um usuário.

Esse relacionamento é feito através da chave estrangeira `UsuarioId` na entidade `Simulacao`.

---

### 11. Histórico de Simulações

Foi implementado o histórico de simulações para usuários autenticados.

A API permite:

- realizar uma simulação sem salvar;
- realizar uma simulação e salvar no histórico;
- listar o histórico do usuário logado;
- buscar uma simulação salva;
- recalcular uma simulação salva.

A simulação salva no banco armazena apenas os dados-base necessários para recalcular o financiamento posteriormente.

---

### 12. Remoção de Dados Redundantes

Durante a evolução do projeto, foi decidido que a tabela de simulações não deve armazenar dados derivados.

A tabela `Simulacoes` salva apenas:

- valor do imóvel;
- valor de entrada;
- prazo em meses;
- taxa de juros;
- sistema de amortização;
- data de criação;
- ID do usuário.

Dados como parcelas, total pago, total de juros, total amortizado e valor financiado são recalculados pela camada de serviço quando necessário.

Essa decisão reduz redundância no banco e mantém o modelo mais limpo.

---

## Funcionalidades Implementadas

### Simulação de Financiamento

- cálculo pelo sistema SAC;
- cálculo pelo sistema PRICE;
- cálculo de parcelas;
- cálculo de juros;
- cálculo de amortização;
- cálculo de saldo devedor;
- resumo total do financiamento;
- retorno completo das parcelas.

### Usuários

- cadastro;
- listagem;
- busca por ID;
- atualização;
- remoção;
- validação de dados;
- hash de senha com BCrypt.

### Autenticação

- login com e-mail e senha;
- verificação de senha com BCrypt;
- geração de token JWT;
- recuperação de dados do usuário logado;
- proteção de rotas com `[Authorize]`.

### Histórico de Simulações

- salvar simulação vinculada ao usuário autenticado;
- listar histórico do usuário logado;
- buscar simulação salva;
- recalcular simulação salva;
- impedir acesso a simulações de outros usuários.

---

## Entidades Principais

### Usuario

Representa um usuário cadastrado na aplicação.

Principais dados:

- ID;
- nome;
- e-mail;
- hash da senha;
- lista de simulações.

### Simulacao

Representa uma simulação salva no histórico de um usuário.

Principais dados:

- ID;
- valor do imóvel;
- valor de entrada;
- prazo em meses;
- taxa de juros;
- sistema de amortização;
- data de criação;
- ID do usuário.

### Financiamento, Parcela e ResumoFinanciamento

São models usados para a lógica de cálculo da simulação.

Eles participam do processamento dos dados, mas não representam necessariamente tabelas persistidas no banco.

---

## Endpoints Principais

### Usuários

```txt
POST   /api/Usuarios
GET    /api/Usuarios
GET    /api/Usuarios/{id}
PUT    /api/Usuarios/{id}
DELETE /api/Usuarios/{id}
```

### Autenticação

```txt
POST /api/Auth/login
GET  /api/Auth/me
```

### Simulação

```txt
POST /api/Simulacao
POST /api/Simulacao/salvar
GET  /api/Simulacao/historico
GET  /api/Simulacao/{id}
```

---

## Banco de Dados

O banco de dados atual possui as principais tabelas:

- `Usuarios`;
- `Simulacoes`;
- `__EFMigrationsHistory`.

A tabela `__EFMigrationsHistory` é utilizada pelo Entity Framework Core para controlar quais migrations já foram aplicadas.

---

## Conceitos Aplicados

O projeto aplica conceitos importantes de desenvolvimento backend:

- API REST;
- arquitetura em camadas;
- separação de responsabilidades;
- Controllers;
- Services;
- DTOs;
- Models;
- Entity Framework Core;
- ORM;
- DbContext;
- DbSet;
- Migrations;
- LINQ;
- async/await;
- PostgreSQL;
- relacionamento 1:N;
- chave estrangeira;
- navigation property;
- Data Annotations;
- Model Binding;
- Model Validation;
- hash de senha;
- BCrypt;
- autenticação JWT;
- Bearer Token;
- Claims;
- `[Authorize]`;
- persistência de histórico;
- recálculo de dados derivados.

---

## Status Atual

Atualmente a API está funcional e possui:

- cálculo SAC e PRICE;
- CRUD de usuários;
- validações;
- PostgreSQL configurado;
- Entity Framework Core;
- migrations;
- hash de senha com BCrypt;
- login;
- JWT;
- rotas protegidas;
- endpoint de usuário logado;
- relacionamento entre usuário e simulação;
- histórico de simulações;
- recálculo de simulações salvas.

O projeto está pronto para avançar para a etapa de preparação do front-end e integração com React.

---

## Próximas Etapas

As próximas etapas planejadas são:

1. revisar o fluxo atual da aplicação;
2. padronizar respostas da API;
3. melhorar o tratamento global de erros;
4. adicionar validações mais específicas na simulação;
5. configurar CORS;
6. criar front-end em React;
7. integrar o front-end com a API;
8. implementar cadastro, login, simulação e histórico no front-end;
9. preparar documentação para apresentação acadêmica;
10. estudar deploy da API e do banco em nuvem.

---

## Objetivo Futuro

O objetivo futuro é transformar o projeto em uma aplicação fullstack completa, contendo:

- backend em ASP.NET Core Web API;
- autenticação JWT;
- banco PostgreSQL;
- histórico de simulações;
- front-end React;
- integração com ferramenta de programação assistida por IA;
- documentação técnica;
- deploy em nuvem;
- interface utilizável por usuários reais.

---

## Observação

Este projeto está em desenvolvimento contínuo e também funciona como estudo prático de backend com C#, ASP.NET Core, Entity Framework Core, PostgreSQL e autenticação JWT.
