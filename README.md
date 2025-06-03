# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram
    class OracleDB {
        +Tabela: TGS_CATASTROFE_MAPEADA
        +Tabela: TGS_CARTILHA_MAPEADA
    }

    class CatastrofeMapeada {
        +int IdCatastrofeM
        +string NomeCatastrofeM
        +string? SintomaCatastrofeM
        +bool Ativo
        +List~CartilhaMapeada~ Cartilhas
    }

    class CartilhaMapeada {
        +int IdCartilhaM
        +int IdCatastrofeM
        +string Nome
        +string? Descricao
        +bool Ativo
        +CatastrofeMapeada Catastrofe
    }

    class AlertasExternosController {
        +GetUltimosAlertas(): IActionResult
    }

    class AlertaGDACS {
        +string? Titulo
        +string? Descricao
        +string? Link
        +string? DataPublicacao
    }

    class StormEyeAPI {
        +Exposição via Swagger
        +Acesso por HTTP
    }

    OracleDB <.. CatastrofeMapeada : lê/escreve
    OracleDB <.. CartilhaMapeada : lê/escreve

    CatastrofeMapeada --> CartilhaMapeada : contém
    CartilhaMapeada --> CatastrofeMapeada : pertence a

    AlertasExternosController --> AlertaGDACS : consome XML
    AlertasExternosController --> StormEyeAPI : integra-se

    StormEyeAPI --> "Serviços externos" : fornece dados mapeados

