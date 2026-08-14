# Guia para avanzar Backend + Frontend - PharmaPro

Esta guia explica como coordinar el backend actual con un futuro frontend sin bloquearse entre equipos.

## Recomendacion sobre repositorios

Si, conviene crear otro repositorio para el frontend.

Repositorios sugeridos:

- `pharmaproback`: backend .NET 9 + Supabase.
- `pharmaprofront`: frontend web.

Ventajas de separar:

- Cada proyecto tiene dependencias distintas.
- El backend puede desplegarse como API.
- El frontend puede desplegarse aparte.
- Los commits quedan mas claros.
- Es mas facil trabajar dos personas en paralelo.

Cuando el proyecto crezca mucho, tambien podria existir un monorepo, pero para este caso separar backend y frontend es mas ordenado.

## Stack frontend recomendado

Opcion recomendada:

- React + Vite + TypeScript.
- React Router para rutas.
- TanStack Query o servicios propios para consumir API.
- Tailwind CSS o Bootstrap, segun preferencia visual.

Nombre sugerido del repo:

```bash
pharmaprofront
```

## Relacion entre proyectos

Backend:

```text
https://api.pharmapro.local
http://localhost:5000
```

Frontend:

```text
http://localhost:5173
```

El frontend no debe conectarse directo a la base de datos PostgreSQL. Debe consumir endpoints del backend.

Excepcion: si mas adelante usan Supabase Auth directamente desde el frontend, se puede usar la `AnonKey`, pero nunca la clave de servicio ni la contrasena de PostgreSQL.

## Variables de entorno frontend

Archivo `.env.example` sugerido para el frontend:

```env
VITE_API_BASE_URL=http://localhost:5000
VITE_SUPABASE_URL=https://fkaerrcwxkrjthazgpza.supabase.co
VITE_SUPABASE_ANON_KEY=poner_anon_key_aqui
```

No guardar secretos privados en el frontend.

## Contrato API primero

Antes de que frontend implemente una pantalla, backend debe definir:

- Endpoint.
- Metodo HTTP.
- Request body.
- Response body.
- Estados de error.
- Reglas de validacion.

Ejemplo:

```http
GET /api/productos
```

Respuesta esperada:

```json
[
  {
    "id": 1,
    "codigo": "MED-001",
    "nombre": "Paracetamol 500mg",
    "principioActivo": "Paracetamol",
    "precioVenta": 2.50,
    "requiereReceta": false,
    "estado": true
  }
]
```

## Orden recomendado para avanzar juntos

Sprint 1: Base funcional

- Backend:
  - Confirmar conexion Supabase.
  - CRUD productos.
  - CRUD categorias.
  - Swagger/OpenAPI.

- Frontend:
  - Crear proyecto.
  - Layout base.
  - Login visual temporal.
  - Pantalla de productos consumiendo API.

Sprint 2: Catalogo

- Backend:
  - Laboratorios.
  - Formas farmaceuticas.
  - Presentaciones.
  - Filtros y busqueda de productos.

- Frontend:
  - Listado de productos.
  - Formulario crear/editar producto.
  - Buscador.
  - Estados de carga/error.

Sprint 3: Inventario

- Backend:
  - Lotes.
  - Inventarios.
  - Stock por sucursal.

- Frontend:
  - Vista de stock.
  - Detalle de producto con lotes.
  - Alertas de stock bajo.

Sprint 4: Compras y proveedores

- Backend:
  - CRUD proveedores.
  - Registro de compras.
  - Detalle de compras.

- Frontend:
  - Pantalla proveedores.
  - Crear compra.
  - Historial de compras.

Sprint 5: POS

- Backend:
  - Clientes.
  - Ventas.
  - Venta detalles.
  - Historial de ventas.

- Frontend:
  - Pantalla POS.
  - Carrito.
  - Cobro.
  - Comprobante simple.

## Responsabilidades por tarea

Para cada pantalla, trabajar asi:

1. Backend define endpoint y DTO.
2. Frontend define pantalla y servicios HTTP.
3. Backend prueba en Swagger.
4. Frontend prueba con datos reales.
5. Ambos ajustan contrato si algo no encaja.

## CORS

El backend debe permitir el origen local del frontend durante desarrollo:

```text
http://localhost:5173
```

Evitar `AllowAnyOrigin` en produccion. Para desarrollo esta bien temporalmente, pero debe ajustarse antes de desplegar.

## Manejo de errores

Formato recomendado:

```json
{
  "message": "No se pudo crear el producto",
  "errors": {
    "codigo": ["El codigo ya existe"]
  }
}
```

El frontend debe mostrar:

- Mensaje general.
- Errores por campo cuando existan.
- Estado de carga al enviar formularios.

## Autenticacion

Camino recomendado:

- Usar Supabase Auth para registrar/iniciar sesion.
- Guardar perfil extendido en `usuarios_perfiles`.
- El frontend obtiene token de Supabase.
- El backend valida JWT antes de permitir acciones privadas.

Pendiente tecnico:

- Configurar autenticacion JWT en `PharmaPro.Api`.
- Proteger endpoints por rol.
- Definir permisos por modulo.

## Checklist para crear el repo frontend

```bash
npm create vite@latest pharmaprofront -- --template react-ts
cd pharmaprofront
npm install
npm run dev
```

Archivos iniciales recomendados:

```text
src/
  api/
    httpClient.ts
    productosApi.ts
  components/
  pages/
    ProductosPage.tsx
  routes/
  types/
    producto.ts
```

Primer cliente HTTP:

```ts
const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

export async function getProductos() {
  const response = await fetch(`${apiBaseUrl}/api/productos`);

  if (!response.ok) {
    throw new Error("No se pudieron cargar los productos");
  }

  return response.json();
}
```

## Regla clave

El frontend avanza por pantallas. El backend avanza por contratos. Si ambos respetan el contrato API, pueden trabajar en paralelo sin esperar a que todo este terminado.
