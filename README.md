# pharmaproback

Backend API para el sistema de gestión farmacéutica y punto de venta **PharmaPro** (conectado a Supabase).

## 🚀 Descripción
Servicio backend diseñado para gestionar inventario multi-sucursal, punto de venta (POS), lotes de medicamentos, compras, proveedores y control de cajas.

## 🛠️ Tecnologías
- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- Npgsql / PostgreSQL
- Supabase

## 📊 Arquitectura del Sistema
El sistema interactúa con la base de datos `pharmabackend` en Supabase con los siguientes módulos:
- **Seguridad & RBAC:** Usuarios, Roles, Permisos.
- **Catálogo:** Productos, Categorías, Laboratorios, Formas Farmacéuticas, Presentaciones.
- **Inventario:** Lotes, Stock por Sucursal, Ajustes de Inventario, Traslados.
- **Punto de Venta (POS):** Ventas, Historial de Ventas, Clientes.
- **Caja & Finanzas:** Cajas, Arqueos de Caja, Cuadre diario.
- **Proveedores & Compras:** Proveedores, Registro de Compras y Comprobantes.

## 📚 Guías de desarrollo

- [Guía para trabajar 2 personas](docs/GUIA_TRABAJO_2_PERSONAS.md)
- [Guía para avanzar Backend + Frontend](docs/GUIA_BACKEND_FRONTEND.md)

## 📝 Configuración e Instalación
```bash
# Clonar el repositorio
git clone https://github.com/Alexandrohcn/pharmaproback.git

# Entrar al directorio
cd pharmaproback

# Restaurar dependencias
dotnet restore PharmaPro.slnx

# Configurar variables locales
# Copiar .env.example como .env y completar la cadena nueva de Supabase.
# El archivo .env esta ignorado por Git.

# Compilar
dotnet build PharmaPro.slnx

# Ejecutar API
dotnet run --project src/Api/PharmaPro.Api.csproj
```
