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

## 📋 Lo que necesitas para ejecutar el proyecto

1. **Visual Studio 2022** (gratis) o **Visual Studio Code**
2. **.NET 8 SDK** (descargar desde Microsoft)
3. **Acceso a SQL Server en Azure** (la base de datos está en la nube)

## 🚀 Cómo ejecutar el proyecto

### Paso 1: Configurar Azure (IMPORTANTE)
1. Ve al portal de Azure (portal.azure.com)
2. Busca tu servidor SQL Server
3. Ve a "Configuración" → "Firewall y redes virtuales"
4. Haz clic en "Agregar IP del cliente" o agrega tu IP manualmente
5. Copia la cadena de conexión del servidor
6. Abre el archivo `appsettings.json` en el proyecto
7. Reemplaza la cadena de conexión con la de Azure

### Paso 2: Abrir el proyecto
1. Abre Visual Studio
2. Selecciona "Abrir proyecto o solución"
3. Busca la carpeta `ms_majiInnovator` y abre el archivo `.csproj`

### Paso 3: Ejecutar
1. Presiona **F5** o haz clic en el botón verde "Start"
2. Se abrirá una ventana del navegador con la dirección `https://localhost:7166`

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

### 🔧 Cómo configurar la conexión a Azure:

1. Ve al portal de Azure (portal.azure.com)
2. Busca tu servidor SQL Server
3. Ve a "Configuración" → "Firewall y redes virtuales"
4. Agrega tu IP actual a las reglas de firewall
5. Copia la cadena de conexión
6. Pégala en el archivo `appsettings.json`

### 📝 Ejemplo de cadena de conexión de Azure:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:tu-servidor.database.windows.net,1433;Initial Catalog=MajiInnovatorDB;Persist Security Info=False;User ID=tu-usuario;Password=tu-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

**⚠️ Nota**: Reemplaza `tu-servidor`, `tu-usuario` y `tu-password` con los valores reales de tu servidor Azure.

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
