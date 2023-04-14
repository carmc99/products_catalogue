FROM mcr.microsoft.com/mssql/server:2017-latest

ENV MSSQL_DATA_DIR /var/opt/mssql/data
ENV MSSQL_LOG_DIR /var/opt/mssql/log
# Crea un directorio nuevo
#WORKDIR /scripts
# Copiar el script de configuración de la base de datos al contenedor
COPY scripts/db_script.sql scripts/db_script.sql

# Crear un archivo de script de entrada
COPY scripts/entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Ejecutar el script de entrada al iniciar el contenedor
ENTRYPOINT ["/entrypoint.sh"]