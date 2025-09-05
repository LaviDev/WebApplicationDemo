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

