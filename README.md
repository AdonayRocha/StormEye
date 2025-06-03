# Diagrama de Classes – Catástrofes
 
```mermaid
classDiagram

%% ===== ENTIDADES PRINCIPAIS =====
classDiagram
class CatastrofeMapeadaController {
  +getAll() GET /api/catastrofes
  +getById(id: int) GET /api/catastrofes/{id}
  +create(CatastrofeMapeada catastrofe) POST /api/catastrofes
  +update(id: int, CatastrofeMapeada catastrofe) PUT /api/catastrofes/{id}
  +delete(id: int) DELETE /api/catastrofes/{id}
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
  +getAll() GET /api/catastrofes
  +getById() GET /api/catastrofes/{id}
  +create() POST /api/catastrofes
  +update() PUT /api/catastrofes/{id}
  +delete() DELETE /api/catastrofes/{id}
}

class AlertasExternosController {
  +getAll() GET /api/alertas-externos
  +getById() GET /api/alertas-externos/{id}
  +processarGDACS() POST /api/alertas-externos/processar-gdacs
  +enviarNotificacao() POST /api/alertas-externos/enviar-notificacao
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
