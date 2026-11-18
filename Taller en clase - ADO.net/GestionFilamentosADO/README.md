<div align="center">

# GestionFilamentosADO

Aplicación de consola para gestionar un inventario de filamentos 3D con ADO.NET y SQLite.

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C# 12](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-3-003B57?logo=sqlite&logoColor=white)
![ADO.NET](https://img.shields.io/badge/ADO.NET-Data%20Access-0078D4)

</div>

## Resumen técnico

En cada ejecución, la aplicación crea la tabla si no existe, limpia los registros anteriores, inserta tres filamentos con parámetros y consulta el inventario.

```text
App C# -> SqliteConnection -> SqliteCommand/Parameters -> inventario_3d.db -> SqliteDataReader
```

La conexión, los comandos y el lector se liberan mediante bloques `using`.

## Esquema de la base de datos

Tabla: `Filamentos`

| Columna | Tipo | Restricciones |
|---|---|---|
| `Id` | INTEGER | Clave primaria, autoincremental |
| `Material` | TEXT | — |
| `Color` | TEXT | — |
| `PesoGramos` | INT | — |

## Requisitos

- .NET SDK 8.0

## Clonar y ejecutar

```bash
git clone https://github.com/sebas269/Taller-en-clase---ADO.net.git
cd Taller-en-clase---ADO.net/GestionFilamentosADO
dotnet restore
dotnet run
```

La base de datos `inventario_3d.db` se crea en el directorio de trabajo.

### Salida esperada

```text
Inventario de filamentos:
Material | Color | Peso (g)
PLA | Rojo | 1000
PETG | Azul | 750
ABS | Negro | 500
```

## Créditos

**Sebastián Tobón Uribe** · [@sebax667](https://github.com/sebax667)
