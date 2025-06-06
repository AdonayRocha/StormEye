# StormEye 🌪️🛰️

API RESTful para monitoramento e gerenciamento de eventos relacionados a catástrofes naturais e cartilhas de sobrevivência, desenvolvida com **.NET 9** e **Entity Framework Core**, utilizando banco de dados Oracle.

---

## ✅ Funcionalidades

- CRUD de Catástrofes  
- CRUD de Cartilhas  
- GET  de Alertas Externos  (GDAC)
- Documentação automática da API via OpenAPI (Swagger)  

---

## 📌 Endpoints Principais

### 🌪️ Catástrofes

- `GET /api/catastrofes` — Lista todas as catástrofes  
- `GET /api/catastrofes/{id}` — Detalha uma catástrofe  
- `POST /api/catastrofes` — Cria uma nova catástrofe  
- `DELETE /api/catastrofes/{id}` — Remove uma catástrofe  
- `POST /api/catastrofes/{catId}/cartilhas/{cartId}` — Associa uma cartilha  
- `DELETE /api/catastrofes/{catId}/cartilhas/{cartId}` — Desassocia uma cartilha  

### 📚 Cartilhas

- `GET /api/cartilhas` — Lista todas as cartilhas  
- `GET /api/cartilhas/{id}` — Detalha uma cartilha  
- `POST /api/cartilhas` — Cria uma nova cartilha  
- `DELETE /api/cartilhas/{id}` — Remove uma cartilha  

### 🔔 Alertas Externos (GDACS)

- `GET /api/gdacs/last` — Retorna os alertas ativos mais recentes  
---

## 📖 Documentação da API - Swagger (OpenAPI)

- Acesse `/swagger` após executar a aplicação  
- Interface interativa para testar endpoints  
- Visualização de modelos, parâmetros e respostas  

---

## 🗂️ Estrutura do Projeto

- `StormEye.Domain`: Entidades de domínio  
- `StormEye.Infrastructure`: EF Core, Migrations e Contexto  
- `StormEyeApi`: Controllers, configuração e Swagger  
- `StormEyeWeb`: Front-end Razor 
---

## 🚀 Como Executar

### Pré-requisitos

- .NET 9 SDK  
- Banco de dados Oracle  
- Git

### Passos

```bash
git clone https://github.com/AdonayRocha/StormEye.git
cd StormEye
```

```bash
cd StormEyeApi
dotnet ef database update --project ../StormEye.Infrastructure/StormEye.Infrastructure.csproj --startup-project .
dotnet run
```

Acesse no navegador: [https://localhost:7137/swagger](https://localhost:7137/swagger)

---
Diagram Model


```mermaid
classDiagram
    direction TB
    class CatastrofeMapeada {
        +int IdCatastrofeM
        +string NomeCatastrofeM
        +DateTime Data
        +string Descricao
        +string Localizacao
        +string Tipo
        +string Gravidade
        +bool Ativo
        +List~CartilhaMapeada~ Cartilhas
    }

    class CartilhaMapeada {
        +int IdCartilhaM
        +int IdCatastrofeM
        +string Nome
        +string Descricao
        +string Categoria
        +bool Ativo
        +CatastrofeMapeada Catastrofe
    }

    class StormEyeContext {
        +DbSet~CatastrofeMapeada~ Catastrofes
        +DbSet~CartilhaMapeada~ Cartilhas
        +DbSet~AlertaExterno~ AlertasExternos
    }

    class IGdacsService {
        +Task~string~ GetActiveEventsJsonAsync()
    }

    class GdacsService {
        -HttpClient _httpClient
        -string _feedUrl
        +Task~string~ GetActiveEventsJsonAsync()
    }

    class ICatastrofeService {
        +Task~IEnumerable~ GetTodasAsync()
        +Task~CatastrofeMapeada~ GetPorIdAsync(int)
        +Task~CatastrofeMapeada~ CriaAsync(CatastrofeMapeada)
        +Task~bool~ AtualizaAsync(int, CatastrofeMapeada)
        +Task~bool~ DeletaAsync(int)
        +Task~bool~ AssociaCartilhaAsync(int, int)
        +Task~bool~ DesassociaCartilhaAsync(int, int)
    }

    class CatastrofeService {
        -StormEyeContext _context
        +... // métodos implementados
    }

    class CatastrofesController {
        +GetAll()
        +GetById(int)
        +Create(CatastrofeMapeada)
        +Delete(int)
        +LinkCartilha(int, int)
        +UnlinkCartilha(int, int)
    }

    class CartilhasController {
        +GetAll()
        +GetById(int)
        +Create(CartilhaMapeada)
        +Delete(int)
    }

    class GdacsController {
        +GetLastEvents()
    }

    GdacsService ..|> IGdacsService
    CatastrofeService ..|> ICatastrofeService
    CatastrofesController --> StormEyeContext
    CartilhasController --> StormEyeContext
    GdacsController --> IGdacsService
    StormEyeContext --> CatastrofeMapeada
    StormEyeContext --> CartilhaMapeada
    CatastrofeMapeada "1" --> "many" CartilhaMapeada : contém
    CartilhaMapeada --> CatastrofeMapeada : pertence
```




---

## 🛠 Tecnologias Utilizadas

- .NET 9 / ASP.NET Core  
- Entity Framework Core  
- Oracle Database  
- Swagger / Swashbuckle  
- C# 9  
- Razor Pages 
- JavaScript / CSS  

---

## 📄 Licença

Este projeto está sob a [MIT License](LICENSE).
