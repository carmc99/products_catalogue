#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

# Microsoft SQL Server 2017
FROM mcr.microsoft.com/mssql/server:2017-latest AS sql_server

# Ejecutar el script SQL al iniciar el contenedor
CMD /opt/mssql-tools/bin/sqlcmd -S $MSSQL_SERVER -U sa -P $MSSQL_SA_PASSWORD -i /scripts/db_script.sql
