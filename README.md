# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram
direction LR
    class CatastrofeMapeada {
	    +int Id
	    +string Nome
	    +DateTime Data
	    +string Descricao
	    +string Localizacao
	    +string Tipo
	    +string Gravidade
    }

    class CartilhaMapeada {
	    +int Id
	    +string Titulo
	    +string Conteudo
	    +string Categoria
    }

    class AlertaExterno {
	    +int Id
	    +string Fonte
	    +string TipoEvento
	    +DateTime DataAlerta
	    +string Descricao
	    +string Localizacao
	    +decimal Latitude
	    +decimal Longitude
	    +string Severidade
    }

    class StormEyeContext {
	    +CatastrofeMapeada[] Catastrofes
	    +CartilhaMapeada[] Cartilhas
	    +AlertaExterno[] AlertasExternos
    }

    class GDACSService {
	    +string ApiUrl
	    +string ApiKey
	    +Task GetLatestAlertsAsync()
	    +Task ProcessarAlertasPeriodicamente()
    }

    class AlertasExternosController {
      <<Controller>>
      +getAll()
      +getById(id: int)
      +processarGDACS()
    }


    StormEyeContext --> CatastrofeMapeada : contém
    StormEyeContext --> CartilhaMapeada : contém
    StormEyeContext --> AlertaExterno : contém
    GDACSService --> StormEyeContext : consulta/atualiza
    AlertasExternosController --> GDACSService : utiliza
