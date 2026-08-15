# pharmaproback

Backend API para el sistema de gestión farmacéutica y punto de venta **PharmaPro** (conectado a Supabase).

## 🚀 Descripción

Servicio backend diseñado para gestionar inventario multi-sucursal, punto de venta (POS), lotes de medicamentos, compras, proveedores y control de cajas.

## 🛠️ Tecnologías

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- Npgsql / PostgreSQL
- Supabase (base de datos PostgreSQL gestionada)

## 📊 Arquitectura

Arquitectura **Hexagonal** (Ports & Adapters):

```
src/
  Domain/        → Entidades POCO (generadas desde Supabase via EF Core)
  Application/   → Puertos (interfaces), DTOs, Casos de uso
  Infrastructure/→ Repositorios EF Core, DbContext, configuración Supabase
  Api/           → Controllers, Program.cs, OpenAPI/Swagger
```

Módulos implementados:
- **Catálogo:** Productos, Categorías, Laboratorios, Formas Farmacéuticas, Presentaciones
- **Proveedores:** CRUD completo
- **Inventario:** Lotes, Stock por Sucursal, Ajustes, Traslados (en desarrollo)
- **Punto de Venta (POS):** Ventas, Historial, Clientes (en desarrollo)
- **Caja & Finanzas:** Cajas, Arqueos (en desarrollo)
- **Seguridad & RBAC:** Usuarios, Roles, Permisos (en desarrollo)

## ⚙️ Configuración para desarrollo local

### 1. Clonar el repositorio

```bash
git clone https://github.com/Alexandrohcn/pharmaproback.git
cd pharmaproback
git checkout alexandro
```

### 2. Configurar la conexión a Supabase

El backend se conecta a la base de datos PostgreSQL de Supabase. **Nunca coloques la contraseña en archivos versionados.**

**Opción A — Archivo .env (recomendado para desarrollo)**

```bash
# Copia el ejemplo
cp .env.example .env

# Edita .env con tu cadena real de conexión (el archivo está ignorado por Git)
```

Dentro de `.env`:

```env
ConnectionStrings__SupabaseConnection=Host=db.TU_PROYECTO.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=TU_PASSWORD;Ssl Mode=Require;Trust Server Certificate=true
```

> La cadena de conexión la encuentras en Supabase → Project Settings → Database → Connection string (URI o parámetros).

**Opción B — .NET User Secrets**

```bash
cd src/Api
dotnet user-secrets set "ConnectionStrings:SupabaseConnection" "Host=db.TU_PROYECTO.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=TU_PASSWORD;Ssl Mode=Require;Trust Server Certificate=true"
```

### 3. Restaurar dependencias y compilar

```bash
dotnet restore PharmaPro.slnx
dotnet build PharmaPro.slnx
```

### 4. Ejecutar la API

```bash
dotnet run --project src/Api/PharmaPro.Api.csproj
```

Swagger disponible en: `http://localhost:5083`

## 🌐 Configuración para VPS / Producción

En el servidor, define las siguientes variables de entorno **antes** de ejecutar la app:

```bash
export ConnectionStrings__SupabaseConnection="Host=db.TU_PROYECTO.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=TU_PASSWORD;Ssl Mode=Require;Trust Server Certificate=true"
export PORT=8080
export ASPNETCORE_ENVIRONMENT=Production
export Cors__AllowedOrigins__0=https://tu-dominio-frontend.com
```

> En producción, CORS está configurado para bloquear todos los orígenes si no se define `Cors__AllowedOrigins__*`. Define siempre el dominio real del frontend.

## 🔐 Seguridad — Reglas importantes

| Archivo | Estado |
|---------|--------|
| `.env` | ❌ Nunca subir — está en `.gitignore` |
| `.env.example` | ✅ Versionado — solo con placeholders, sin secretos |
| `appsettings.json` | ✅ Sin secretos — `ConnectionStrings:SupabaseConnection` vacío |
| `bin/`, `obj/` | ❌ Nunca subir — en `.gitignore` |
| `src/Domain/EntitiesBackup/` | ❌ Nunca subir — en `.gitignore` |

## 📚 Guías de desarrollo

- [Guía para trabajar 2 personas](docs/GUIA_TRABAJO_2_PERSONAS.md)
- [Guía para avanzar Backend + Frontend](docs/GUIA_BACKEND_FRONTEND.md)

## 🔄 Regenerar entidades desde Supabase

Si hay cambios en la base de datos:

```bash
dotnet ef dbcontext scaffold "Name=ConnectionStrings:SupabaseConnection" Npgsql.EntityFrameworkCore.PostgreSQL \
  --project src/Infrastructure/PharmaPro.Infrastructure.csproj \
  --startup-project src/Api/PharmaPro.Api.csproj \
  --context PharmaDbContext \
  --context-dir Persistence \
  --output-dir ../Domain/Entities \
  --namespace PharmaPro.Domain.Entities \
  --context-namespace PharmaPro.Infrastructure.Persistence \
  --schema public --force --no-onconfiguring
```
