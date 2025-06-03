# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram
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

    class AlertaGDACS {
        +string? Titulo
        +string? Descricao
        +string? Link
        +string? DataPublicacao
    }

    class AlertasExternosController {
        +GetUltimosAlertas(): IActionResult
    }

    CatastrofeMapeada --> CartilhaMapeada : contém
    CartilhaMapeada --> CatastrofeMapeada : pertence a
    AlertasExternosController --> AlertaGDACS : consome
