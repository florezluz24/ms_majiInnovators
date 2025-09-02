# Maji Innovator - Backend

API REST desarrollada en .NET 8 para el sistema de encuestas Maji Innovator.

## 🚀 Tecnologías

- **.NET 8.0** - Framework principal
- **Entity Framework Core 8.0.0** - ORM para acceso a datos
- **SQL Server** - Base de datos
- **Swagger/OpenAPI 6.4.0** - Documentación de API
- **CORS** - Configurado para frontend Angular

## 📋 Prerrequisitos

- .NET 8.0 SDK
- SQL Server (LocalDB, Express o Developer Edition)
- Visual Studio 2022 o Visual Studio Code

## 🛠️ Instalación

1. Clona el repositorio:
```bash
git clone <url-del-repositorio>
cd ms_majiInnovator
```

2. Restaura las dependencias:
```bash
dotnet restore
```

3. Configura la cadena de conexión en `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MajiInnovatorDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

## 🏃‍♂️ Ejecución

### Desarrollo
```bash
dotnet run
```
La API estará disponible en `https://localhost:5000` y `http://localhost:5000`

### Con Visual Studio
Presiona F5 o usa el botón "Start Debugging"

## 📊 Base de Datos

### Migraciones
El proyecto usa Entity Framework Code First. La base de datos se crea automáticamente al ejecutar la aplicación.

Para crear una nueva migración:
```bash
dotnet ef migrations add NombreMigracion
```

Para aplicar migraciones:
```bash
dotnet ef database update
```

## 📁 Estructura del Proyecto

```
ms_majiInnovator/
├── Controladores/           # Controladores de la API
│   ├── EncuestaController.cs
│   ├── RespuestaEncuestaController.cs
│   └── UsuarioController.cs
├── DTOs/                   # Data Transfer Objects
│   ├── RespuestaEncuestaDTO.cs
│   ├── UsuarioDTO.cs
│   └── ValidarAccesoDTO.cs
├── Modelos/                # Entidades del dominio
│   ├── CatalogoTelefono.cs
│   ├── RespuestaEncuesta.cs
│   └── Usuario.cs
├── Persistencia/           # Configuración de Entity Framework
│   ├── ApplicationDbContextFactory.cs
│   ├── ConfiguracionConexion.cs
│   ├── ConfiguracionServicios.cs
│   └── ModeladoTablas.cs
├── Repositorios/           # Patrón Repository
│   ├── RepositorioCatalogoTelefono.cs
│   ├── RepositorioRespuestaEncuesta.cs
│   └── RepositorioUsuario.cs
├── Encuestas/              # Lógica de negocio
│   └── RespuestasGeneralesEncuesta.cs
├── Migrations/             # Migraciones de Entity Framework
└── Program.cs              # Punto de entrada de la aplicación
```

## 🔧 Configuración

### CORS
La API está configurada para aceptar peticiones desde:
- `http://localhost:4200` (Frontend Angular en desarrollo)
- `https://localhost:4200` (Frontend Angular con HTTPS)

### Swagger
En modo desarrollo, la documentación de la API está disponible en:
- `https://localhost:5000/swagger`
- `http://localhost:5000/swagger`

## 📡 Endpoints Principales

### Usuarios
- `GET /api/Usuario` - Obtener todos los usuarios
- `POST /api/Usuario` - Crear nuevo usuario
- `POST /api/Usuario/validar-acceso` - Validar credenciales

### Encuestas
- `GET /api/Encuesta` - Obtener encuestas
- `POST /api/Encuesta` - Crear nueva encuesta

### Respuestas
- `GET /api/RespuestaEncuesta` - Obtener respuestas
- `POST /api/RespuestaEncuesta` - Guardar respuesta

## 🏗️ Arquitectura

El proyecto sigue los siguientes patrones:

- **Repository Pattern** - Para el acceso a datos
- **DTO Pattern** - Para transferencia de datos
- **Dependency Injection** - Para la inyección de dependencias
- **Code First** - Para el modelado de la base de datos

## 🧪 Testing

Para ejecutar las pruebas:
```bash
dotnet test
```

## 📝 Scripts Útiles

- `dotnet run` - Ejecutar la aplicación
- `dotnet build` - Compilar el proyecto
- `dotnet test` - Ejecutar pruebas
- `dotnet ef migrations add <nombre>` - Crear migración
- `dotnet ef database update` - Aplicar migraciones

## 🔒 Seguridad

- CORS configurado para orígenes específicos
- Validación de entrada en controladores
- Uso de DTOs para transferencia de datos

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.
