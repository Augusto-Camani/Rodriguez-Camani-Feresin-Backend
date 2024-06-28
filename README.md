# Proyecto Final 2TUP4
### Alumnos: Augusto Camani, Fernando Rodriguez

## Descripción del Proyecto

Nuestro proyecto es una aplicación web para una barbería situada en la localidad de Rosario. La aplicación permite a los usuarios realizar diversas acciones, tales como:

- **Sacar turnos:** Los clientes pueden agendar citas con sus barberos favoritos.
- **Dejar reseñas:** Después de un servicio, los clientes pueden dejar reseñas y calificaciones.
- **Modificar perfil:** Los usuarios pueden ver y editar su perfil, así como revisar sus turnos y reseñas pasadas.

## Tecnologías Utilizadas

Al desarrollar el proyecto, se utilizó varias tecnologías y librerías modernas, algunas son:

- **Automapper:** Nuget para hacer el pasaje automático de los DTO a las entidades.
- **EntityFramework:** ORM para mapear entidades a bases de datos.
- **Moq:** Nuget para ejecutar tests.
- **Swashbuckle Annotations && Filters:** Nugets que permiten modificar y perfilar cómo se ve el JSON en el Swagger.
- **Microsoft Authentication Bearer** Nuget que nos permite enviar un JWT como bearer.

## Instalación

Para instalar y ejecutar la aplicación localmente, debes seguir estos pequeños pasos:

1. Clona este repositorio:
    ```sh
    git clone https://github.com/Augusto-Camani/Rodriguez-Camani-Feresin-Backend
    ```

2. Navega al directorio del proyecto:
    ```sh
    cd tu-repositorio
    ```

3. Instala las dependencias:
    ```sh
    dotnet build
    ```

4. Inicia la aplicación (Asegurate de modificar los puertos LocalHost, donde correrá la app, por el puerto deseado):
    ```sh
    dotnet run
    ```
