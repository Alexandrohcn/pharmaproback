# pharmaproback

Backend API para el sistema de gestión farmacéutica y punto de venta **PharmaPro** (conectado a Supabase).

## 🚀 Descripción
Servicio backend diseñado para gestionar inventario multi-sucursal, punto de venta (POS), lotes de medicamentos, compras, proveedores y control de cajas.

## 🛠️ Tecnologías
- Node.js / TypeScript
- Supabase (PostgreSQL 17)
- Express / NestJS

## 📊 Arquitectura del Sistema
El sistema interactúa con la base de datos `pharmabackend` en Supabase con los siguientes módulos:
- **Seguridad & RBAC:** Usuarios, Roles, Permisos.
- **Catálogo:** Productos, Categorías, Laboratorios, Formas Farmacéuticas, Presentaciones.
- **Inventario:** Lotes, Stock por Sucursal, Ajustes de Inventario, Traslados.
- **Punto de Venta (POS):** Ventas, Historial de Ventas, Clientes.
- **Caja & Finanzas:** Cajas, Arqueos de Caja, Cuadre diario.
- **Proveedores & Compras:** Proveedores, Registro de Compras y Comprobantes.

## 📝 Configuración e Instalación
```bash
# Clonar el repositorio
git clone https://github.com/Alexandrohcn/pharmaproback.git

# Entrar al directorio
cd pharmaproback

# Instalación de dependencias (próximamente)
npm install
```
