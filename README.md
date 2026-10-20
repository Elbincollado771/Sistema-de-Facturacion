# Sistema de Facturación – Natür (Empresa Abc)

Aplicación de escritorio en **C# (Windows Forms, .NET Framework 4.7.2)** con base de datos **SQL Server**, para gestionar la facturación de una empresa.

## Funcionalidades

- Inicio de sesión de usuarios
- Gestión de **clientes** y **productos**
- **Facturación** (cabecera y detalle de facturas) y registro de ventas
- **Usuarios, roles y permisos** (Vendedor, Cajero, Supervisor, Administrador)
- **Informes**

## Requisitos

- Windows
- Visual Studio 2019 o superior, con la carga de trabajo *Desarrollo de escritorio con .NET*
- SQL Server Express (instancia `SQLEXPRESS`) y SQL Server Management Studio (SSMS)

## Cómo ejecutarlo

1. **Clona el repositorio**
   ```
   git clone https://github.com/Elbincollado771/Sistema-de-Facturacion.git
   ```
2. **Crea la base de datos.** Abre SSMS, conéctate a tu instancia (por ejemplo `.\SQLEXPRESS`), abre el archivo `BaseDeDatos_EmpresaAbc.sql` y ejecútalo (F5). Esto crea la base `EmpresaAbc` con sus tablas y datos de prueba.
   > Si el script falla por la ruta de los archivos `.mdf`/`.ldf` en la instrucción `CREATE DATABASE`, crea primero una base vacía llamada `EmpresaAbc` y ejecuta solo el resto del script.
3. **Revisa la cadena de conexión.** El proyecto usa:
   ```
   Data Source=.\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True
   ```
   Si tu instancia tiene otro nombre, cámbialo en los archivos de clases y formularios (puedes usar *Editar > Buscar y reemplazar > Reemplazar en archivos*).
4. Abre `Empresa Abc.sln` en Visual Studio y pulsa **Iniciar** (F5).

## Usuario de prueba

| Usuario | Contraseña | Rol |
|---------|-----------|-----|
| admin   | admin123  | Administrador |

> Datos de demostración. Cámbialos si usas el sistema en un entorno real.

## Estructura de la base de datos

`Clientes`, `Productos`, `Cabecera_Factura`, `Cabecera_Detalle`, `Ventas`, `Usuarios`, `Roles`, `Permisos`, `Roles_Permisos`.

## Estructura del proyecto

- `Empresa Abc/` – código fuente (formularios `Frm*` y clases `Cla*`)
- `BaseDeDatos_EmpresaAbc.sql` – script de la base de datos (esquema y datos)
