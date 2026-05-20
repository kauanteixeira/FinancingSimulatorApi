# FinancingSimulatorApi

API REST desenvolvida com ASP.NET Core para simulação de financiamento imobiliário utilizando os sistemas SAC e PRICE.

O projeto começou originalmente como uma aplicação Console em C# e posteriormente foi migrado para uma arquitetura Web API moderna, com foco em:

- separação de responsabilidades
- arquitetura em camadas
- integração com banco de dados
- escalabilidade
- boas práticas de backend
- persistência de dados
- futura integração com front-end React

---

# Objetivo do Projeto

O principal objetivo do projeto é permitir que usuários realizem simulações de financiamento imobiliário, visualizando:

- valor das parcelas
- amortização
- juros pagos
- saldo devedor
- totais do financiamento

Além disso, o projeto também serve como estudo prático de:

- ASP.NET Core Web API
- arquitetura em camadas
- Entity Framework Core
- PostgreSQL
- DTOs
- Services
- Controllers
- Injeção de Dependência
- validações
- persistência de dados
- fluxo HTTP
- autenticação JWT
- integração futura com React

---

# Evolução do Projeto

## Versão Inicial — Console Application

O projeto começou como uma aplicação Console em C#, onde:

- o usuário digitava os dados manualmente no terminal
- toda lógica ficava centralizada
- as validações eram feitas manualmente
- os cálculos de SAC e PRICE eram executados diretamente na aplicação
- os resultados eram exibidos formatados no console

A estrutura inicial possuía:

- Financiamento
- Parcela
- ResumoFinanciamento
- SimuladorService
- Program.cs

---

## Migração para ASP.NET Core Web API

Posteriormente o sistema foi migrado para uma API REST utilizando ASP.NET Core Web API.

Durante a migração foram realizadas diversas refatorações arquiteturais para tornar o projeto mais organizado, modular e próximo de aplicações reais de mercado.

---

# Arquitetura Atual

O projeto foi reorganizado utilizando separação de responsabilidades.

## Controllers

Responsáveis por:

- receber requisições HTTP
- validar dados automaticamente
- chamar os Services
- retornar respostas HTTP em JSON

---

## DTOs

Responsáveis pela transferência de dados entre cliente e servidor.

Foram criados DTOs específicos para:

- entrada de dados
- saída de dados
- respostas da API

Isso evita expor diretamente as entidades internas da aplicação.

---

## Services

Responsáveis pela lógica de negócio.

Atualmente o projeto possui:

- SimuladorService
- SacService
- PriceService
- UsuarioService

Cada Service possui uma responsabilidade específica.

---

## Models

Representam as entidades do domínio da aplicação.

Atualmente o projeto possui:

- Financiamento
- Parcela
- ResumoFinanciamento
- Usuario

---

## Data

Responsável pela integração com banco de dados através do Entity Framework Core.

Contém:

- AppDbContext
- DbSets
- configuração de conexão com PostgreSQL

---

# Persistência de Dados

O projeto agora possui integração completa com PostgreSQL utilizando Entity Framework Core como ORM.

Foi implementado:

- AppDbContext
- DbSet para entidades
- migrations automáticas
- persistência real de dados
- CRUD inicial de usuários
- integração completa entre API e banco de dados

Atualmente a aplicação já consegue:

- cadastrar usuários
- listar usuários
- salvar dados no PostgreSQL
- utilizar consultas com LINQ
- utilizar operações assíncronas com async/await

O Entity Framework Core é responsável por:

- mapear entidades C# para tabelas
- gerar SQL automaticamente
- controlar migrations
- rastrear alterações das entidades
- persistir dados utilizando SaveChangesAsync()

---

# Funcionalidades Implementadas

## Simulação de Financiamento

- Sistema SAC
- Sistema PRICE
- cálculo de juros
- cálculo de amortização
- cálculo do saldo devedor
- resumo total do financiamento
- retorno completo das parcelas

---

## API REST

- Controllers
- endpoints HTTP
- retorno JSON estruturado
- Swagger/OpenAPI
- validações automáticas
- tratamento de exceções
- arquitetura modular
- Injeção de Dependência

---

## Banco de Dados

- PostgreSQL
- Entity Framework Core
- migrations
- persistência de dados
- CRUD de usuários
- integração completa API ↔ banco

---

# Tecnologias Utilizadas

## Linguagens

- C#
- SQL
- JSON

---

## Frameworks e Bibliotecas

- ASP.NET Core Web API
- Entity Framework Core
- Npgsql
- Swagger / OpenAPI

---

## Banco de Dados

- PostgreSQL

---

## Ferramentas

- Git
- GitHub
- DBeaver
- Postman
- VS Code

---

# Estrutura do Projeto

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
├── appsettings.json
└── FinancingSimulatorApi.csproj
```

---

# Fluxo da Aplicação

```txt
Cliente/Postman
↓
Controller
↓
Service
↓
DbContext
↓
Entity Framework Core
↓
PostgreSQL
```

---

# Fluxo da API

1. O cliente envia uma requisição HTTP  
2. O Controller recebe os dados  
3. O Controller chama o Service  
4. O Service executa a lógica de negócio  
5. O Entity Framework Core gera SQL automaticamente  
6. O PostgreSQL executa as operações  
7. A API retorna respostas em JSON  

---

# Conceitos Aplicados

O projeto utiliza diversos conceitos importantes de desenvolvimento backend:

- API REST
- arquitetura em camadas
- ORM
- Entity Framework Core
- Dependency Injection
- DTOs
- Services
- Controllers
- LINQ
- async/await
- migrations
- persistência de dados
- PostgreSQL
- separação de responsabilidades

---

# Próximos Passos

O projeto continuará evoluindo com:

- relacionamento entre usuários e simulações
- persistência de histórico de simulações
- autenticação JWT
- hash de senha com BCrypt
- autorização por usuário
- validações avançadas
- front-end React
- deploy em nuvem
- documentação completa da API

---

# Objetivo Futuro

O objetivo final é transformar o projeto em uma aplicação completa contendo:

- API REST
- autenticação JWT
- PostgreSQL
- Entity Framework Core
- persistência de simulações
- front-end React
- arquitetura profissional
- deploy completo
- autenticação de usuários
- histórico de simulações
- aplicação fullstack completa
