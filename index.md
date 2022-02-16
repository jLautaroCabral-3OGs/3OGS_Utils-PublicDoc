
# This is the **3OGS_Utils** plugin!
3OGS_Utils es un pequeño pero muy práctico plugin para el desarrollo de prototipos y debugging de proyectos Unity

## ¿Por qué existe?
Si bien Unity ya cuenta con métodos de debugging nativos, desde la consola hasta la vista de escena, en distintos escenarios me han resultado herramientas tediosas.

#### **La consola**

Los proyectos grandes pueden hacer tanto uso del Debug.Log que luego se hace difícil trackear un log particular, la consola se llena de logs o de excepciones y puede llegar a ser molesto. Otra desventaja del Debug.Log es que al hacer una Dev Build y probar el juego no puedes ver los logs de consola salvo si son excepciones, que por cierto también puede ser difícil trackearlas si son muchas.

Esto también puede pasar con proyectos pequeños o medianos si estos utilizan varios plugins, la mayoría siempre imprime algún log y si los sumas a los ya existentes en el proyecto la consola también se te puede llenar fácil.

#### **La vista de escena**

La principal desventaja es que no podemos hacer uso de esta vista en una Dev Build. También puede tener desventajas menores para debug según el contexto, por ejemplo si quieres hacer debugging en un juego VR mientras se ejecuta, el frame rate de esta vista puede reducirse bastante y puede ser molesto trabajar así.

Sé que tiene un gran número de desventajas menores pero son tan contextuales que no las voy a describir, ya que aún cuando no te imagines cuáles son, luego de probar este plugin probablemente te darás cuenta de lo limitada que puede ser la vista de escena en algunos proyectos.