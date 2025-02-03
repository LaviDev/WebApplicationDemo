# API REST con ASP.NET Core usando C# y .Net 6.


## **REST (Representational State Transfer)** Estilo arquitectonico basado en **HTTP** 
1. **Uso de Recursos y URLs**
   - En todo es un recurso (usuarios, productos, pedidos, etc.).
   - Cada recurso tiene una **URI (Uniform Resource Identifier)** única.
   - EJEMPLO: GET /usuarios → Lista todos los usuarios, GET /usuarios/1 → Obtiene el usuario con ID 1 
2. **Uso de Métodos HTTP Correctos (CRUD)**
   - GET → Leer datos (Ejemplo: GET /productos/1 obtiene el producto con ID 1).
   - POST → Crear un nuevo recurso (Ejemplo: POST /productos crea un nuevo producto).
   - PUT → Actualizar un recurso existente (Ejemplo: PUT /productos/1 actualiza el producto con ID 1).
   - PATCH → Actualización parcial de un recurso.
   - DELETE → Eliminar un recurso (Ejemplo: DELETE /productos/1 borra el producto con ID 1).
3. **Uso de JSON o XML como Formato de Respuesta**
   - Se suele usar JSON por su eficiencia y compatibilidad.
4. **Stateless (Sin Estado)**
   - Cada petición HTTP debe contener toda la información necesaria para procesarla.
   - El servidor no almacena información de estado entre solicitudes.
5. **Uso de Código de Estado HTTP**
   - 200 OK → Petición exitosa.
   - 201 Created → Recurso creado exitosamente.
   - 400 Bad Request → Solicitud incorrecta.
   - 401 Unauthorized → No autenticado.
   - 404 Not Found → Recurso no encontrado.
   - 500 Internal Server Error → Error en el servidor.
6. **Versionado de la API**
   - Se pueden usar versiones en la URL o en los headers:
     - En la URL: /api/v1/usuarios
     - En los headers: Accept: application/vnd.company.v1+json
7. **HATEOAS (Hypermedia As The Engine Of Application State)**
   - Permite que la API devuelva enlaces relacionados con los recursos para navegar en la API.
