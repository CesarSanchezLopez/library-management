# 📚 Library Management System (.NET)


El sistema permite registrar **autores** y **libros**, aplicando reglas de negocio y buenas prácticas de desarrollo como arquitectura en capas, uso de DTOs, inyección de dependencias y una API REST consumida desde una aplicación Web MVC.

---


# 🏗️ Arquitectura del Proyecto

La solución está dividida en dos proyectos principales:

LibraryManagement
│
├── LibraryManagement.API
│     API REST (.NET Framework 4.8)
│
├── LibraryManagement.Web
│     Aplicación Web MVC (.NET Framework 4.8)
│
├── Database
│     Scripts SQL para crear la base de datos
│
└── LibraryManagement.slnx
Solución de Visual Studio

---

# ⚙️ Tecnologías utilizadas

* C#
* .NET Framework 4.8
* ASP.NET Web API
* ASP.NET MVC
* Entity Framework
* SQL Server
* Swagger
* Dependency Injection
* Git / GitHub

---

# 📊 Base de Datos

Base de datos utilizada:

SQL Server
Database: **LibraryDB**


---

# 🗄️ Creación de la Base de Datos

Ejecutar los scripts ubicados en la carpeta:

Database/

### 1️⃣ Crear la base de datos

```sql
CREATE DATABASE LibraryDB
GO
USE LibraryDB
```

### 2️⃣ Ejecutar los scripts de tablas

Ejecutar en este orden:

Autores.sql
Libros.sql

Estos scripts crearán las tablas y la relación entre **Autores** y **Libros**.

---

# 🔌 Configuración de conexión

Archivo:

LibraryManagement.API/Web.config

Cadena de conexión de ejemplo:

```xml
<connectionStrings>
  <add name="LibraryConnection"
       connectionString="Server=localhost;Database=LibraryDB;Trusted_Connection=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Ajustar el **Server** según la instalación de SQL Server.

Ejemplo:

Server=localhost
Server=localhost\SQLEXPRESS

---

# 🚀 Ejecución del sistema

## 1️⃣ Ejecutar la API

Abrir el proyecto:

LibraryManagement.API

Ejecutar la aplicación.

Swagger estará disponible en:

https://localhost:44302/swagger

---

## 2️⃣ Ejecutar la aplicación Web

Abrir el proyecto:

LibraryManagement.Web

ELa aplicación Web consume la API REST utilizando HttpClient mediante el servicio:

Services/ApiService.cs

La URL base de la API se configura en el archivo:

Web.config

Configuración:

<appSettings>
  <add key="ApiBaseUrl" value="https://localhost:44302/api/" />
</appSettings>

---

# 📌 Funcionalidades

## Gestión de Autores

✔ Registrar autores
✔ Editar autores
✔ Listar autores
✔ Eliminar autores

## Gestión de Libros

✔ Registrar libros
✔ Editar libros
✔ Listar libros
✔ Eliminar libros



# ⭐ Repositorio

https://github.com/CesarSanchezLopez/library-management
