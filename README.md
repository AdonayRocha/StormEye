# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram

%% ===== ENTIDADES PRINCIPAIS =====
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
  +string Fonte (GDACS)
  +string TipoEvento
  +DateTime DataAlerta
  +string Descricao
  +string Localizacao
  +decimal Latitude
  +decimal Longitude
  +string Severidade
}

%% ===== CONTEXT =====
class StormEyeContext {
  +DbSet~CatastrofeMapeada~ Catastrofes
  +DbSet~CartilhaMapeada~ Cartilhas
  +DbSet~AlertaExterno~ AlertasExternos
}

%% ===== SERVIÇOS =====
class GDACSService {
  +string ApiUrl
  +string ApiKey
  +Task~List~AlertaExterno~~ GetLatestAlertsAsync()
  +Task ProcessarAlertasPeriodicamente()
}

class NotificationService {
  +Task EnviarAlertaWebHook(string url, AlertaExterno alerta)
}

%% ===== CONTROLLERS =====
class CatastrofeMapeadaController {
  "+GET /api/catastrofes"
  "+GET /api/catastrofes/{id}"
  "+POST /api/catastrofes"
  "+PUT /api/catastrofes/{id}"
  "+DELETE /api/catastrofes/{id}"
}

class AlertasExternosController {
  "+GET /api/alertas-externos"
  "+GET /api/alertas-externos/{id}"
  "+POST /api/alertas-externos/processar-gdacs"
  "+POST /api/alertas-externos/enviar-notificacao"
}

%% ===== RELACIONAMENTOS =====
StormEyeContext --> CatastrofeMapeada : contém
StormEyeContext --> CartilhaMapeada : contém
StormEyeContext --> AlertaExterno : contém

GDACSService --> AlertaExterno : cria
GDACSService --> NotificationService : usa
GDACSService --> StormEyeContext : persiste

AlertasExternosController --> GDACSService
AlertasExternosController --> NotificationService
AlertasExternosController --> StormEyeContext

NotificationService --> AlertaExterno : envia
