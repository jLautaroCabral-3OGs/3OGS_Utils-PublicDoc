# ¿Por qué salió esta nueva versión?

Antes de agregar nuevas características al plugin se corrigieron algunas que ya tiene.

La versión anterior le daba la posibilidad al desarrollador de usar DebugObjects sin preocuparse en comprobar por código si la versión es o no de producción. Aunque esta característica pareció buena fue removida porque modifica tanto el comportamiento y uso del plugin que puede ser incómodo desarrollarlo o hasta usarlo. Ahora el desarrollador deberá hacer las comprobaciones.

El plugin necesitaba ser bien documentado para generar una API reference, además necesitaba algunas correcciones de nombres y un par de correcciones menores.

# ¿Qué habrá en futuras versiones?

Mejores herramientas para juegos 2D, mejora en el uso de recursos, cambio en algunos métodos públicos para que el uso del plugin sea más ágil.

Las herramientas de este plugin son principalmente para juegos 3D. En futuras versiones el plugin contará con nuevas herramientas útiles para entornos 2D.

Esta versión aún tiene pendientes algunas mejoras de rendimiento en cuanto a las herramientas de prototipado y algunas de Debug.

Muchos métodos públicos de la clase 3OGS_Debug retornan gameobjects en vez de components, esto es así por la manera en la que el plugin comprobaba si la versión del juego es o no de producción, como esta característica fue removida queda corregir el retorno de las funciones para una programación más ágil.