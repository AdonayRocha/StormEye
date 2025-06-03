# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram

%% ===== ENTIDADES =====
class CatastrofeMapeada {
  +int Id
  +string Nome
  +DateTime Data
  +string Descricao
  +string Localizacao
}

class CartilhaMapeada {
  +int Id
  +string Titulo
  +string Conteudo
  +string Categoria
}

%% ===== CONTEXT =====
class StormEyeContext {
  +DbSet~CatastrofeMapeada~ Catastrofes
  +DbSet~CartilhaMapeada~ Cartilhas
}

StormEyeContext --> CatastrofeMapeada : contém
StormEyeContext --> CartilhaMapeada : contém

%% ===== CONTROLLERS =====
class CatastrofeMapeadaController {
  +GET /api/catastrofes
  +GET /api/catastrofes/{id}
  +POST /api/catastrofes
  +PUT /api/catastrofes/{id}
  +DELETE /api/catastrofes/{id}
}

class CartilhaMapeadaController {
  +GET /api/cartilhas
  +GET /api/cartilhas/{id}
  +POST /api/cartilhas
  +PUT /api/cartilhas/{id}
  +DELETE /api/cartilhas/{id}
}

CatastrofeMapeadaController --> CatastrofeMapeada
CatastrofeMapeadaController --> StormEyeContext

CartilhaMapeadaController --> CartilhaMapeada
CartilhaMapeadaController --> StormEyeContext

WeatherForecastController --> WeatherForecast



