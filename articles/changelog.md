# 3OGS_Utils v0.1.1

Build date: 14/02/22

[Ir al  changelog de la versión anterior](https://www.notion.so/3OGS_Utils-v0-1-0-ccb44303d2cb408982c170d2873d0e14)

---

# Changelog

- Se ha cambiado el nombre del plugin de LC_Utils a 3OGS_Utils
- Ahora el desarrollador debe comprobar él mismo si la versión del juego es de producción antes de ejecutar código correspondiente a una versión de desarrollo
- La configuración del plugin ahora se asigna con un prefab que contenga el componente _3OGS_DebuggerConfig, da como resultado mayor compatibilidad con versiones anteriores de Unity
- Se han hecho cambios para que el DebugManager obtenga una configuración default cuando no tenga asignada una configuración particular
- Se han hecho ajustes de rendimiento para el uso de DebugCameras
- Se han hecho modificaciones al DebugButtonPanel para permitir agregar un botón que instancie un mensaje a su lado al ser presionado
- Las DebugFunction ahora se instancian dentro de un gameobject creado por runtime por el DebugManager
- La currentCamera del CameraSwitcher ahora se asigna al cargar la escena
- Se han hecho correcciones de nombres
- Se han eliminado instrucciones using innecesarias
- Se han documentado un gran número de métodos públicos
- Se ha cambiado el modificador de accesibilidad en variedad de métodos

# Know Issues

- Quedan algunos métodos que documentar
- Quedan mejoras de uso de recursos pendiente
- Hay que reestructurar algo de código
- Hay que cambiar el retorno de algunos métodos de 3OGS_Debug para que el desarrollo sea más ágil
- Puede que la asignación de la current camera en el DebugManager no funcione en todos los casos