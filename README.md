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

    class NotificationService {
	    +Task EnviarAlertaWebHook(string url, AlertaExterno alerta)
    }

    class AlertasExternosController {
	    +getAll()
	    +getById(id: int)
	    +processarGDACS()
	    +enviarNotificacao(alerta: AlertaExterno)
    }

    StormEyeContext --> CatastrofeMapeada : contém
    StormEyeContext --> CartilhaMapeada : contém
    StormEyeContext --> AlertaExterno : contém
    GDACSService --> NotificationService : usa
    AlertasExternosController --> GDACSService : busca
    AlertasExternosController --> NotificationService
    AlertasExternosController --> StormEyeContext
    NotificationService --> AlertaExterno : envia
