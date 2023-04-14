# Catálogo de Productos API

Esta es una API desarrollada en `ASP.NET Framework 4.7` para un catálogo de productos. La API permite a los usuarios obtener información sobre los productos y categorías almacenados en la base de datos.

La API utiliza librerías como `MediatR`, `AutoMapper`, `Serilog`, `EntityFramework`, `Moq` y `Unity` para la inyección de dependencias. También se puede conectar a una base de datos `SQL Server 2014` o superior, 
asi como utilizar una base de datos en memoria.

Los usuarios pueden ordenar los productos por nombre o categoría y también de forma ascendente o descendente.

#### Diagrama de componentes:

![diagram](https://raw.githubusercontent.com/carmc99/products_catalogue/main/docs/components_diagram.svg)


- Para ejecutar la aplicación usando su propio string de conexion, modifiquelo en Web.config

```
  <connectionStrings>
    <add name="SqlServer2017_docker_dev" connectionString="Server=host.docker.internal,1433; Database=Catalogue; User=sa; Password=YourPassword" providerName="System.Data.SqlClient" />
  </connectionStrings>

```



- Para ejecutar la aplicacion usando una base de datos en memoria, siga los siguientes pasos:

1. Habilite las siguientes lineas comentadas en: `App_Start/UnityConfig`:
```
            // In memory database config
            //var builder = new DbContextOptionsBuilder<InMemoryContext>();
            //builder.UseInMemoryDatabase("Catalogue");
            //var options = builder.Options;

            //container.RegisterInstance(options);
```
2. Cambie el dbContext de `SqlServerContext` a `InMemoryContext` en `Infraestructure/Repository/ProductRepository` y `Infraestructure/Repository/CategoryRepository`, asi:

```
        private readonly SqlServerContext dbContext;

        public ProductRepository(SqlServerContext dbContext)
        {
            this.dbContext = dbContext;
        }
```
A
```
        private readonly InMemoryContext dbContext;

        public ProductRepository(InMemoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

```



- Para crear un servidor de base de datos que contenga toda la informacion necesaria que usara la api, ejecute el siguiente comando en `products_catalogue\products_catalogue`, 
asegurese de estar en el mismo directorio donde se encuentra el archivo docker-compose.yml

```
1. docker compose build
```
```
2. docker compose up
```
**Esta opcion puede requerir un alto uso de memoria, debido al tamano de la imagen de **SqlServer 2017**.**

- **Nota**: En el direcotrio scripts/db_scripts.sql se encuentran todas las intrucciones necesarias para crear la db, tablas y registros de ejemplo.

#### Testing, documentacion y trazabilidad

- Para acceder a las rutas de la api y su documentacion, es posible usar swagger, para ello dirijase a la siguiente url, una vez ejecute la aplicacion.
```
https://localhost:puerto/swagger
```

- Para ejecutar las pruebas unitarias, dirijase a `products_catalogue.Test`

- La aplicacion hace uso de la libreria `Serilog` para generar logs y llevar trazabilidad.
**Nota**: Los logs por defecto se almacenan en la ruta **C:/catalogue_logs.txt**.
