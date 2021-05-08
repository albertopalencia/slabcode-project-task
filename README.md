# slabcode-project-task
Prueba técnica de programación El objetivo de la presente prueba es evaluar el nivel de conocimiento y habilidades de programación de potenciales aspirantes al cargo de desarrollador backend. Para todo problema de programación existen múltiples soluciones, pero usualmente hay mejores prácticas a la hora de abordar un determinado desafío. Con esta prueba se busca no solo recibir por parte del aspirante un código funcional, sino también un código implementado adecuadamente.


Descripción de la prueba
Usted debe implementar un API REST para un nuevo proyecto de desarrollo que busca crear
una aplicación web para que los usuarios puedan crear proyectos, donde cada proyecto tiene
un listado de tareas asociadas. Los roles de usuario del sistema son los siguientes:
● Administrador: Puede deshabilitar a otros usuarios para evitar que inicien sesión en la
aplicación. Además tiene permisos de consulta a toda la información en la plataforma.
Además puede borrar tanto tareas o proyectos de cualquier usuario.
● Operador: Tiene la potestad de crear proyectos y de crear tareas vinculadas a cada
proyecto. Además puede cambiar el estado de una tarea de Pendiente a Realizada, y de
cambiar el Estado de un proyecto de En Proceso a Finalizado.
Este proyecto tiene el siguiente conjunto de funcionalidades:
● Autenticación de usuarios: Los usuarios se autentican con un nombre de usuario y
contraseña, y el backend retorna un token JTW.
● Creación de usuario: El rol administrador podrá crear usuarios operadores, con una
contraseña, esto debe disparar un correo al usuario indicando las credenciales de
autenticación.
● Cambiar la contraseña: Endpoint para cambiar la contraseña del usuario, necesita de la
contraseña actual para realizar el cambio de contraseña.
● Crear proyecto: Los operadores consumen un endpoint para crear un proyecto con la
siguiente información:
○ Nombre del proyecto (campo obligatorio)
○ Descripción (campo obligatorio)
○ Fecha de inicio (debe ser posterior o igual al día presente, campo obligatorio)
○ Fecha de finalización (debe ser posterior al día inicial)
● Editar proyecto: Los operadores consumen un endpoint para modificar alguno de los
siguientes campos de un proyecto:
○ Nombre del proyecto
○ Descripción
○ Fecha de finalización (no se puede modificar si existen tareas con fechas de
ejecución posteriores a la nueva fecha de finalización).
● Borrar proyecto: Los operadores consumen un endpoint para borrar un proyecto y
todas sus tareas asociadas.
● Completar proyecto: Los operadores consumen un endpoint para completar un
proyecto, con lo cual su estado cambia de En Proceso a Finalizado. La petición solo
debe ser exitosa si todas las tareas del proyecto ya están en estado Realizada, esto
dispara un correo a los administradores indicando la finalización del proyecto.
● Crear tarea: Los operadores consumen un endpoint para crear una tarea asociada a un
proyecto con la siguiente información:
○ Nombre de la tarea (campo obligatorio)
○ Descripción (campo opcional)
○ Fecha de ejecución (debe estar en el rango de fechas de inicio y final del
proyecto)
● Editar tarea: Los operadores consumen un endpoint para modificar alguno de los
siguientes campos de un proyecto:
○ Nombre de la tarea
○ Descripción
○ Fecha de ejecución (debe estar en el rango de fechas de inicio y final del
proyecto)
● Borrar tarea: Los operadores consumen un endpoint para borrar una tarea.
● Completar tarea: Los operadores consumen un endpoint para completar una tarea, con
lo cual su estado cambia de En Proceso a Finalizado.
● Habilitar / Deshabilitar operadores: Los administradores consumen un endpoint para
habilitar o deshabilitar operadores del sistema. Un operador deshabilitado no debe
poder autenticarse.
Implementación
Construya una aplicación WEB API utilizando la tecnología de su elección con su solución al
problema planteado. Debe subir la solución a un repositorio de GitHub y también enviar un
video con el funcionamiento del API, se debe usar swagger o postman para documentar el api.
Indicaciones y recomendaciones
● Por simplicidad se recomienda usar un ORM para las operaciones con la DB, pero se
deja abierta la opción de usar SPs. Si opta por esta opción entonces enviar los
correspondientes scripts de SQL y mostrar su uso en el video.
Habilidades a evaluar
● Adecuado conocimiento y familiaridad con el framework.
● Sólidos conocimientos en lenguaje del framework.
● Capacidad de seguir instrucciones y satisfacer un requerimiento real de un cliente.
● Capacidad de análisis y resolución de problemas ante una lógica de negocio compleja.
● Manejo de estructuras de datos.
