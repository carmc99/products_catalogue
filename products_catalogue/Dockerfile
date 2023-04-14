#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/mssql/server:2017-latest

COPY ./scripts /scripts

WORKDIR /scripts

ENV MSSQL_DATA_DIR /var/opt/mssql/data
ENV MSSQL_LOG_DIR /var/opt/mssql/log

# Ejecutar el script SQL al iniciar el contenedor
CMD /opt/mssql-tools/bin/sqlcmd -S $MSSQL_SERVER -U sa -P $MSSQL_SA_PASSWORD -i /scripts/db_script.sql
