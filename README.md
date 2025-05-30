# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram
    class CatastrofeMapeada {
        +int idCatastrofeM @Not Null
        +String nomeCatastrofeM @Not Null
        +String sintomaCatastrofeM
        +Boolean ativoM
        +json exibeCatastrofeMapeada(get)
        +json alteraCatastrofeMapeada(put)
        +json removeCatastrofeMapeada(put)
        +json exibeCatastrofeMapeadaId(get)
    }
 
    class CartilhaMapeada {
        +int idCatastrofeM @Not Null
        +String nomeCatastrofeM @Not Null
        +String sintomaCatastrofeM
        +Boolean ativo
        +json exibeCatastrofeMapeada(get)
        +json alteraCatastrofeMapeada(put)
        +json removeCatastrofeMapeada(put)
        +json exibeCatastrofeMapeadaId(get)
    }
 
    CatastrofeMapeada --> OracleDB : usa
    CartilhaMapeada --> OracleDB : usa
    OracleDB --> OpenAPI : conecta
    OpenAPI : External Services
 
    class OracleDB {
        LocalHost
    }
 
    class OpenAPI {
        External Services
    }
