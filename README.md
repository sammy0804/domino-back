# Domino Chain Builder

Este es un programa que construye una cadena de fichas de dominó a partir de una lista de fichas dadas. 
Las fichas de dominó se pueden conectar si sus números coinciden con los de las fichas adyacentes en la cadena.

## Requisitos del sistema
Este programa requiere los siguientes componentes para ejecutarse:

#### .NET Core SDK 3.1 o superior

## Instrucciones de instalación
1. Descargue o clone este repositorio en su máquina local.
2. Abra una terminal y navegue hasta el directorio raíz del repositorio.
3. Ejecute el siguiente comando para compilar el programa:
`dotnet build`
4. Ejecute el siguiente comando para ejecutar el programa:
`dotnet run`

## Uso
Para usar este programa, siga los siguientes pasos:

1. Abra Postman u otra herramienta de prueba de API.
2. Cree una solicitud POST para la URL http://localhost:5000/api/domino.
3. En el cuerpo de la solicitud, proporcione una lista de fichas de dominó en formato JSON.
4. Envíe la solicitud y espere la respuesta.

La respuesta será una lista de cadenas que representan las fichas de dominó encadenadas, en el orden en que se deben colocar para formar la cadena. Si la lista de fichas de dominó no se puede encadenar, la respuesta será un mensaje de error que indica que no se encontró una cadena válida.
