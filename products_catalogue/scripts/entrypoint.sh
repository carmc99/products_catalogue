#!/bin/bash

# Iniciar SQL Server en segundo plano
/opt/mssql/bin/sqlservr &

# Esperar a que SQL Server esté listo para aceptar conexiones
sleep 15s

# Ejecutar los comandos SQL
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Secret123*+" -i /scripts/db_script.sql

# Mantener el contenedor en ejecución
tail -f /dev/null