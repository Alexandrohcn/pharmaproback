# Guia de trabajo para 2 personas - PharmaPro Backend

Esta guia define una forma simple y ordenada para desarrollar PharmaPro entre dos personas sin pisarse el codigo, manteniendo estable la rama principal y avanzando por modulos.

## Objetivo

Trabajar el backend de PharmaPro en equipo usando:

- GitHub como repositorio central.
- La rama `alexandro` como rama de desarrollo principal.
- Ramas cortas por tarea.
- Pull requests para revisar antes de integrar.
- Supabase como base de datos compartida.
- .NET 9, EF Core y PostgreSQL/Npgsql.

## Roles recomendados

Persona 1: Backend API y arquitectura

- Controladores.
- Servicios de aplicacion.
- Repositorios.
- Validaciones.
- Manejo de errores.
- Swagger/OpenAPI.

Persona 2: Base de datos, entidades y pruebas

- Supabase.
- Tablas, relaciones e indices.
- Reverse engineering con EF Core cuando cambie la base.
- Pruebas manuales con Swagger/Postman/HTTP files.
- Documentacion de endpoints.

Los roles pueden intercambiarse, pero conviene que cada tarea tenga un responsable claro.

## Ramas

Ramas base:

- `main`: version estable.
- `alexandro`: rama de desarrollo activa.

Ramas de trabajo:

```bash
git checkout alexandro
git pull origin alexandro
git checkout -b feature/productos-crud
```

Convencion de nombres:

- `feature/catalogo-productos`
- `feature/inventario-stock`
- `feature/ventas-pos`
- `fix/error-crear-producto`
- `docs/guia-desarrollo`

## Flujo diario

Antes de empezar:

```bash
git checkout alexandro
git pull origin alexandro
git checkout -b feature/nombre-tarea
```

Durante el trabajo:

```bash
dotnet build PharmaPro.slnx
git status
git add src docs README.md
git commit -m "feat: implementar modulo productos"
```

Antes de subir:

```bash
dotnet build PharmaPro.slnx
git pull origin alexandro
git push origin feature/nombre-tarea
```

Luego crear un Pull Request hacia `alexandro`.

## Reglas para evitar conflictos

- No trabajar los dos sobre el mismo archivo grande al mismo tiempo.
- No modificar `PharmaDbContext.cs` manualmente salvo que sea necesario.
- Cada tabla debe tener su entidad en archivo propio dentro de `src/Domain/Entities`.
- Si cambia la base en Supabase, regenerar entidades con EF Core y avisar al equipo.
- No subir `bin/`, `obj/`, `.env`, secretos ni contrasenas.
- Antes de abrir PR, compilar siempre.

## Cuando cambien tablas en Supabase

Si se crea o modifica una tabla en Supabase, actualizar el backend con reverse engineering:

```bash
dotnet ef dbcontext scaffold "Name=ConnectionStrings:SupabaseConnection" Npgsql.EntityFrameworkCore.PostgreSQL --project src/Infrastructure/PharmaPro.Infrastructure.csproj --startup-project src/Api/PharmaPro.Api.csproj --context PharmaDbContext --context-dir Persistence --output-dir ../Domain/Entities --namespace PharmaPro.Domain.Entities --context-namespace PharmaPro.Infrastructure.Persistence --schema public --force --no-onconfiguring
```

Despues revisar:

- Que cada entidad este en su propio archivo.
- Que los nombres de clases sean claros en singular.
- Que `dotnet build PharmaPro.slnx` compile sin errores.
- Que los servicios existentes sigan usando los nombres correctos.

Nota: la FK hacia `auth.users` de Supabase puede aparecer como advertencia si solo se genera el esquema `public`. Es aceptable mientras el backend no necesite modelar directamente las tablas internas de Auth.

## Estructura de trabajo por capas

Domain:

- Entidades generadas desde Supabase.
- Reglas de dominio puras si aparecen mas adelante.

Application:

- DTOs.
- Interfaces/puertos.
- Casos de uso.
- Reglas de negocio de aplicacion.

Infrastructure:

- EF Core.
- Repositorios.
- Conexion a Supabase.
- Implementaciones externas.

Api:

- Controllers.
- OpenAPI.
- Configuracion HTTP.
- Autenticacion/autorizacion cuando se agregue.

## Orden recomendado de modulos

1. Catalogo base:
   - categorias
   - laboratorios
   - formas_farmaceuticas
   - presentaciones
   - productos

2. Sucursales y stock:
   - sucursales
   - lotes
   - inventarios

3. Seguridad:
   - roles
   - permisos
   - usuarios_perfiles

4. Proveedores y compras:
   - proveedores
   - compras
   - compra_detalles

5. POS y caja:
   - clientes
   - cajas
   - arqueos
   - ventas
   - venta_detalles
   - venta_historial

6. Inventario avanzado:
   - ajustes_inventario
   - traslados

## Definicion de terminado

Una tarea esta terminada cuando:

- Compila con `dotnet build PharmaPro.slnx`.
- Tiene endpoints probados.
- No sube archivos generados `bin/` u `obj/`.
- El PR explica que cambio y como probarlo.
- El frontend sabe que endpoint puede consumir, con request y response esperados.

## Formato de Pull Request

```md
## Que cambia
-

## Como probar
1.
2.

## Endpoints afectados
- GET /api/productos

## Notas para frontend
-
```
