# MOTIVACION / JUSTIFICACION DEL PROYECTO  

Esta Filmografia del Studio Ghibli esta inspirada y empujada por querer mejorar e implementar diferentes funcionaldades al proyecto ya desarrollado durante el primer curso para demostrar nuestra evoluación

**Descripción breve**  
Esta aplicación ASP .NET Core MVC es una “Filmografia” de Studio Ghibli que:

1. **Seed inicial**:  
   - Al arrancar, si la tabla de `Films` (o `People`) está vacía, hace una única llamada a la API pública de Studio Ghibli (`/films` y `/people`), descarga los datos y los almacena en una base de datos SQLite local.  
   - Después de ese seed, **toda la aplicación** consume datos **desde las tablas** de SQLite, **no** vuelve a llamar a la API en cada petición.

2. **Funcionalidades**:  
   - **Listado de películas** 
   - **Valoraciones de usuarios**: formulario que guarda nombre y comentario en la tabla `Ratings`  
   - **Carrusel** de imágenes en la página About, con posicionamiento dinámico de texto  
   - **Página de Contacto** con formulario de contacto  
   - **Encabezados** claro/oscuro seleccionables por vista  
   - **Tipografía**: Outfit, sans-serif (Google Fonts)  

3. **Tecnologías**  
   - ASP .NET Core MVC (.NET 7)  
   - Entity Framework Core + SQLite (migrations en `Migrations/`)  
   - SeedData en `Program.cs`, ejecutado una única vez si la BD está vacía  
   - JavaScript puro para el slider (`wwwroot/js/hero-slider.js`)  
   - CSS en `wwwroot/css/site.css`, con gradientes, Google Fonts y estilos BEM-light  

---

## Estructura principal

