# 📊 Sistema de Encuestas - Backend

Este es el backend (servidor) de un sistema de encuestas desarrollado para un proyecto de clase.

## ¿Qué hace este proyecto?

Este backend permite:
- Registrar usuarios en el sistema
- Hacer login con usuario y contraseña
- Obtener preguntas de encuestas
- Guardar respuestas de los usuarios

## 🛠️ Tecnologías que usamos

- **C#** - Lenguaje de programación
- **.NET 8** - Framework de Microsoft
- **Entity Framework** - Para trabajar con la base de datos
- **SQL Server** - Base de datos donde guardamos la información
- **Azure Storage** - Para almacenar imágenes del catálogo

## 📋 Lo que necesitas para ejecutar el proyecto

1. **Visual Studio 2022** (gratis) o **Visual Studio Code**
2. **.NET 8 SDK** (descargar desde Microsoft)
3. **Acceso a SQL Server en Azure** (la base de datos está en la nube)
4. **Archivo de credenciales** (proporcionado por el estudiante)

## 🚀 Cómo ejecutar el proyecto

### ⚠️ IMPORTANTE: Configuración de Credenciales

**Este proyecto NO incluye las credenciales por seguridad. Necesitas crear un archivo de configuración.**

### Paso 1: Obtener las credenciales
1. El estudiante debe proporcionarte el archivo `CREDENCIALES_DOCENTE.txt`
2. Abre ese archivo para ver las instrucciones

### Paso 2: Crear archivo de configuración
1. En la carpeta `ms_majiInnovator`, crea un archivo llamado: `appsettings.Development.json`
2. Copia el contenido JSON del archivo `CREDENCIALES_DOCENTE.txt` dentro de ese archivo
3. O usa como referencia el archivo `appsettings.Development.json.example` y reemplaza los valores

**Ubicación del archivo:**
```
ms_majiInnovator/
  └── appsettings.Development.json  ← Crear este archivo aquí
```

### Paso 3: Configurar Azure (si es necesario)
1. Ve al portal de Azure (portal.azure.com)
2. Busca tu servidor SQL Server
3. Ve a "Configuración" → "Firewall y redes virtuales"
4. Agrega tu IP actual a las reglas de firewall

### Paso 4: Abrir el proyecto
1. Abre Visual Studio
2. Selecciona "Abrir proyecto o solución"
3. Busca la carpeta `ms_majiInnovator` y abre el archivo `.csproj`

### Paso 5: Restaurar paquetes
```bash
dotnet restore
```

### Paso 6: Ejecutar
1. Presiona **F5** o haz clic en el botón verde "Start"
2. O desde terminal: `dotnet run`
3. Se abrirá una ventana del navegador con la dirección `https://localhost:7166`

## 📁 Estructura del proyecto (carpetas principales)

```
ms_majiInnovator/
├── Controladores/     # Aquí están las rutas de la API
├── Modelos/          # Las tablas de la base de datos
├── DTOs/             # Los datos que enviamos y recibimos
├── Repositorios/     # Código para acceder a la base de datos
└── Program.cs        # Archivo principal donde empieza todo
```

## 🔗 Rutas principales de la API

### Usuarios
- `GET /api/Usuario` - Ver todos los usuarios
- `POST /api/Usuario` - Crear un usuario nuevo
- `POST /api/Usuario/validar-acceso` - Hacer login

### Encuestas
- `GET /api/Encuesta` - Obtener las preguntas de la encuesta

### Respuestas
- `GET /api/RespuestaEncuesta` - Ver todas las respuestas
- `POST /api/RespuestaEncuesta` - Guardar una respuesta

## 🗄️ Base de datos

La base de datos está alojada en **Azure SQL Server** (en la nube).

### ⚠️ Configuración importante de Azure:

**Antes de ejecutar el proyecto, debes:**
1. **Registrar tu IP** en las reglas de firewall de Azure
2. **Obtener la cadena de conexión** del servidor SQL en Azure
3. **Actualizar** el archivo `appsettings.json` con la cadena correcta

### Tablas principales:
- **Usuarios** - Información de las personas registradas
- **RespuestasEncuesta** - Las respuestas que dan los usuarios

### 📝 Estructura del archivo appsettings.Development.json:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "TU_CADENA_DE_CONEXION_SQL_SERVER"
  },
  "AzureStorage": {
    "ConnectionString": "TU_CONNECTION_STRING_AZURE_STORAGE",
    "BaseUrl": "https://stmajito.blob.core.windows.net",
    "ContainerName": "catalogo"
  }
}
```

**⚠️ Nota**: Los valores reales están en el archivo `CREDENCIALES_DOCENTE.txt` proporcionado por el estudiante.

## 🧪 Cómo probar la API

1. Ejecuta el proyecto (F5)
2. Ve a `https://localhost:7166/swagger`
3. Ahí puedes probar todas las funciones de la API

## 📝 Comandos útiles (si usas terminal)

```bash
# Restaurar paquetes
dotnet restore

# Ejecutar el proyecto
dotnet run

# Compilar el proyecto
dotnet build
```

## 🎯 Objetivo del proyecto

Este backend forma parte de un sistema completo que incluye:
- **Frontend** (Angular) - La parte que ven los usuarios
- **Backend** (este proyecto) - La parte que maneja los datos

## 👥 Para estudiantes

Este es un proyecto de clase que demuestra:
- Cómo crear una API REST
- Cómo conectar con una base de datos
- Cómo estructurar un proyecto de .NET
- Patrones básicos de programación

## ❓ ¿Problemas?

Si algo no funciona:
1. Verifica que tengas .NET 8 instalado
2. Asegúrate de que Visual Studio esté actualizado
3. **Revisa que tu IP esté registrada en Azure** (problema más común)
4. Verifica que la cadena de conexión en `appsettings.json` sea correcta
5. Pregunta al profesor o compañeros

### 🔥 Problema más común: "No se puede conectar al servidor"
- **Solución**: Tu IP no está registrada en el firewall de Azure
- **Pasos**: Ve a Azure → SQL Server → Firewall → Agregar tu IP
