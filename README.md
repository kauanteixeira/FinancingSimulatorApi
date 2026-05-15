# FinancingSimulatorApi

API REST desenvolvida com ASP.NET Core para simulação de financiamento imobiliário utilizando os sistemas SAC e PRICE.

O projeto começou originalmente como uma aplicação de console em C# e posteriormente foi migrado para uma arquitetura Web API com foco em escalabilidade, organização de código, separação de responsabilidades e integração futura com banco de dados e front-end React.

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
- DTOs
- Services
- Controllers
- Injeção de Dependência
- validações
- fluxo HTTP
- integração futura com PostgreSQL e Entity Framework

---

# Evolução do Projeto

## Versão Inicial — Console Application

O projeto começou como uma aplicação console em C# puro, onde:

- o usuário digitava os dados manualmente no terminal
- toda lógica ficava centralizada em uma única estrutura
- as validações eram feitas utilizando loops e leitura de Console
- os cálculos de SAC e PRICE eram executados diretamente na classe de financiamento
- os resultados eram exibidos formatados no terminal

A aplicação possuía:

- classe `Financiamento`
- classe `Parcela`
- classe `ResumoFinanciamento`
- `SimuladorService`
- `Program.cs`

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
- validar automaticamente os dados enviados
- chamar os Services
- retornar respostas HTTP em JSON

---

## DTOs

Responsáveis pela transferência de dados entre cliente e servidor.

Foram criados DTOs específicos para:

- entrada de dados da simulação
- saída de resultados da simulação

Isso evita expor diretamente as entidades internas da aplicação.

---

## Services

Responsáveis pela regra de negócio.

A lógica foi separada em:

- `SimuladorService`
- `SacService`
- `PriceService`

Cada Service possui uma responsabilidade específica.

---

## Models

Representam as entidades do domínio da aplicação.

Atualmente o projeto possui modelos como:

- `Financiamento`
- `Parcela`
- `ResumoFinanciamento`

---

# Funcionalidades Implementadas

- Simulação de financiamento imobiliário
- Sistema SAC
- Sistema PRICE
- Cálculo de juros
- Cálculo de amortização
- Cálculo do saldo devedor
- Retorno completo das parcelas
- Resumo total do financiamento
- API REST
- Swagger/OpenAPI
- Validações automáticas
- Tratamento de exceções
- Injeção de dependência
- Arquitetura modular

---

# Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- Swagger / OpenAPI
- .NET
- Git
- GitHub

---

# Estrutura do Projeto

```txt
FinancingSimulatorApi/
│
├── Controllers/
├── DTOs/
├── Models/
├── Services/
├── Properties/
├── Program.cs
├── appsettings.json
└── FinancingSimulatorApi.csproj
```

---

# Fluxo da API

1. O cliente envia uma requisição HTTP para o Controller
2. O Controller recebe os dados da simulação
3. O Controller envia os dados para o Service
4. O Service executa as regras de negócio
5. Os cálculos são realizados
6. A API retorna os resultados em JSON

---

# Próximos Passos

O projeto continuará evoluindo com:

- integração com PostgreSQL
- Entity Framework Core
- autenticação JWT
- login de usuários
- salvamento de simulações
- front-end React
- deploy em nuvem
- documentação completa da API

---

# Objetivo Futuro

O objetivo final é transformar o projeto em uma aplicação completa, contendo:

- API REST
- autenticação
- banco de dados
- front-end React
- persistência de simulações
- arquitetura profissional
- deploy completo
