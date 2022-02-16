<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Features </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Features ">
    <meta name="generator" content="docfx 2.59.0.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="">
<h1 id="features" sourcefile="articles/index.md" sourcestartlinenumber="1">Features</h1>

<h3 id="3ogs_utils-createkeycodeaction" sourcefile="articles/index.md" sourcestartlinenumber="2">3OGS_Utils: CreateKeyCodeAction</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="3">Esta función es muy tan útil como simple, su primer parámetro es una KeyCode y el segundo un Action que se llamará al presionar dicha tecla.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="5">Retorna una instancia de FunctionUpdater, un monobehaviour que viene con el plugin y se explicará más adelante, por el momento podemos ignorarlo.</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="7">public static FunctionUpdater 3OGS_Utils.CreateKeyCodeAction(KeyCode key, Action onKeyDown)
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="10">Ejemplo de uso:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="12">void Start() {
	3OGS_Utils.CreateKeyCodeAction(KeyCode.A, () =&gt; Debug.Log(&quot;Hello (:-D)&quot;));
}
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="18"><img src="images/freeLookCamera_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="18" alt="FreeLookCamera_sample"></p>
<h3 id="3ogs_utils-cameras--cameraswitcher" sourcefile="articles/index.md" sourcestartlinenumber="20">3OGS_Utils: Cameras &amp; CameraSwitcher</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="21">Con el objetivo de navegar rápidamente por la escena, este plugin te permite instanciar dos tipos de cámara de espectador en tiempo de ejecución y con apenas unas líneas de código. Esto es principalmente útil en Dev Builds para recorrer la escena libremente y asegurarse de que todo funciona como debe, ya que en una Dev Build no podrás usar la vista de escena del editor.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="23">En esta versión existen dos tipos de cámaras;</p>
<h4 id="freelookcamera" sourcefile="articles/index.md" sourcestartlinenumber="25"><strong sourcefile="articles/index.md" sourcestartlinenumber="25">FreeLookCamera</strong></h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="26">Una cámara de vista libre que se maneja con WASD, el ratón, Q y E, al mantener click derecho la cámara deja de moverse y el cursor del mouse aparece, el cursor del mouse está oculto por defecto en esta cámara. Es parecida a la cámara de vista libre en Counter Strike.</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="28">public static void _3OGS_Debug.UseFreeLookCamera()
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="32">Ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="34">void Start() {
    if(Input.GetMouseButtonDown(0))
        _3OGS_Debug.UseFreeLookCamera();
}
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="41">Un mejor ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="43">void Start() {
    _3OGS_Utils.CreateKeyCodeAction(KeyCode.F1,
        () =&gt; {
            if (_3OGS_Utils.IsBuildForProduction()) return; // Do nothing
            _3OGS_Debug.UseFreeLookCamera();
        });
}
</code></pre>
<hr sourcefile="articles/index.md" sourcestartlinenumber="53">
<p sourcefile="articles/index.md" sourcestartlinenumber="54">💡 Momento de imaginación: Desarrollas un videojuego FPS multijugador online, necesitas probar en una Dev Build que al presionar el botón de un bunker, 4 puertas(a las que tardarías
mucho en llegar si caminaras) se cierren, en ese momento puedes activar la FreeLookCamera para comprobar el estado y comportamiento de las puertas y otros jugadores al tratar de
usarlas. Entonces no tendrás que caminar a ellas cada vez que pruebes. Seguro ya se te ocurrirán muchos escenarios dónde se puede ahorrar mucho tiempo usando una free look camera.</p>
<hr sourcefile="articles/index.md" sourcestartlinenumber="58">
<h4 id="rotatearoundcamera" sourcefile="articles/index.md" sourcestartlinenumber="60"><strong sourcefile="articles/index.md" sourcestartlinenumber="60">RotateAroundCamera</strong></h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="61">Una cámara que sigue un objetivo y puede rotar al rededor de él, siempre mirando al mismo. Para rotar la cámara se utiliza el botón central del ratón, para hacer zoom se utiliza la rueda. Es parecida a la cámara que sigue los personajes en Counter Strike.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="63"><img src="images/rotateAround_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="63" alt="RotateAroundCamera_sample"></p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="65">public static void _3OGS_Debug.UseRotateAroundTargetCamera(Transform target)
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="69">Ejemplos de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="71">GameObject anyObject = GameObject.Find(&quot;AnyObject&quot;);

_3OGS_Utils.CreateKeyCodeAction(KeyCode.F2,
    () =&gt; {
        if (_3OGS_Utils.IsBuildForProduction()) return;
        _3OGS_Debug.UseRotateAroundTargetCamera(anyObject.transform);
    });
</code></pre>
<hr sourcefile="articles/index.md" sourcestartlinenumber="80">
<p sourcefile="articles/index.md" sourcestartlinenumber="81">💡 Momento de imaginación: Desarrollas un videojuego de aviones de combate multijugador online, necesitas probar en una Dev Build que los aviones y misiles se comporten correctamente, ahí es dónde entra esta cámara. Cuando un avión enemigo dispara un misil utilizas la RotateAroundCamera para seguir el objeto misil y evaluar que su comportamiento sea el planeado. Esta cámara es perfecta para el debug de objetos que se mueven muy rápido o que se teletransportan.</p>
<hr sourcefile="articles/index.md" sourcestartlinenumber="83">
<h4 id="cameraswitcher" sourcefile="articles/index.md" sourcestartlinenumber="85"><strong sourcefile="articles/index.md" sourcestartlinenumber="85">CameraSwitcher</strong></h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="86">El CameraSwitcher es una pequeña clase encargada de manejar el cambio de cámara en el plugin. Esta clase tiene apenas 3 métodos;</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="88">public static void SetupCurrentCamera(Camera camera)

public static void SetupReturnAction(Action returnToPreviousCameraAction)

public static void SetupReturnAction(Camera camera, Action returnToPreviousCameraAction)

public static void ReturnToOriginalCamera()
</code></pre>
<h5 id="cameraswitchersetupcurrentcameracamera-camera" sourcefile="articles/index.md" sourcestartlinenumber="98"><strong sourcefile="articles/index.md" sourcestartlinenumber="98">CameraSwitcher.SetupCurrentCamera(Camera camera)</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="99">Este método es para establecer la current camera, el plugin lo utiliza al crear la FreeLookCamera y RotateAroundCamera.</p>
<h5 id="cameraswitchersetupreturnactionaction-returntopreviouscameraaction" sourcefile="articles/index.md" sourcestartlinenumber="102"><strong sourcefile="articles/index.md" sourcestartlinenumber="102">CameraSwitcher.SetupReturnAction(Action returnToPreviousCameraAction)</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="103">Esté método es para establecer un callback que se llamará luego de llamar al método ReturnToOriginalCamera()</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="105">El callback podría usarse para restablecer objetos al volver a la cámara original del jugador. Por ejemplo, quizás quieras desactivar la GUI del jugador antes de pasar a la FreeLookCamera, pero al volver a la cámara original querrías volver a activar la GUI, para esto podrías usar el callback.</p>
<h5 id="cameraswitchersetupreturnactioncamera-camera-action-returntopreviouscameraaction" sourcefile="articles/index.md" sourcestartlinenumber="108"><strong sourcefile="articles/index.md" sourcestartlinenumber="108">CameraSwitcher.SetupReturnAction(Camera camera, Action returnToPreviousCameraAction)</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="109">Este método es el mismo pero puedes especificar otra cámara a la que volver en vez de la original.</p>
<h5 id="cameraswitcherreturntooriginalcamera" sourcefile="articles/index.md" sourcestartlinenumber="112"><strong sourcefile="articles/index.md" sourcestartlinenumber="112">CameraSwitcher.ReturnToOriginalCamera()</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="113">Este método regresa a la cámara original, se considera a cámara original a la cámara por defecto al inicio de la escena.</p>
<h3 id="_3ogs_debug-debugbutton--debugbuttonpanel" sourcefile="articles/index.md" sourcestartlinenumber="116">_3OGS_Debug: DebugButton &amp; DebugButtonPanel</h3>
<h4 id="debugbutton" sourcefile="articles/index.md" sourcestartlinenumber="117">DebugButton</h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="118">Un DebugButton es un botón en el mundo(es decir que no es parte de la UI, no está dentro de un canvas). Los DebugButton tienen un Action onClickFunction que se llama al ser presionados. También se les puede asignar un objeto padre de modo que los botones siempre estén con el objeto en caso de ser un objeto en movimiento.</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="120">public static GameObject _3OGS_Debug.CreateDebugButton(
                                                    string btnLabel,
                                                    Vector3 position,
                                                    Action onClickFunction,
                                                    bool rotateToCamera = true
                                                    )

public static GameObject _3OGS_Debug.CreateDebugButton(
                                                    Transform parent,
                                                    string btnLabel,
                                                    Vector3 position,
                                                    Action onClickFunction,
                                                    bool rotateToCamera = true
                                                    )
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="137">Ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="139">GameObject btnObj = _3OGS_Debug.CreateDebugButton(&quot;Example&quot;,
                                                Vector3.up,
                                                () =&gt; Debug.Log(&quot;Example log&quot;));
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="144"><img src="images/debugButton_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="144" alt="DebugButton_sample"></p>
<h4 id="debugbuttonpanel" sourcefile="articles/index.md" sourcestartlinenumber="146">DebugButtonPanel</h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="147">El DebugButtonPanel es simplemente un contenedor para asignar un conjunto de botones a un objeto particular de manera prolija. También puedes asignarle un parent.</p>
<h5 id="debugbuttonpanelcreatebuttonpanel" sourcefile="articles/index.md" sourcestartlinenumber="149"><strong sourcefile="articles/index.md" sourcestartlinenumber="149">DebugButtonPanel.CreateButtonPanel</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="151">Primero debes crear un DebugButtonPanel con cualquiera de esos métodos.</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="153">public static GameObject DebugButtonPanel.CreateButtonPanel(Vector3 position)

public static GameObject DebugButtonPanel.CreateButtonPanel(Transform parent, Vector3 position)
</code></pre>
<h5 id="debugbuttonpaneladdbutton" sourcefile="articles/index.md" sourcestartlinenumber="159"><strong sourcefile="articles/index.md" sourcestartlinenumber="159">DebugButtonPanel.AddButton</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="161">Luego debes añadirle un botón con uno de estos métodos</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="163">public static void DebugButtonPanel.AddButton(DebugButtonPanel btnPanel, string btnLabel, Action onClickFunction)

public static void DebugButtonPanel.AddButton(DebugButtonPanel btnPanel, string btnLabel, string btnMessage)
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="169">Ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="171">GameObject btnPanel = _3OGS_Debug.CreateButtonPanel(Vector3.up);
DebugButtonPanel.AddButton(
                  btnPanel.GetComponent&lt;DebugButtonPanel&gt;(),
                  &quot;Test 1&quot;,
                  () =&gt; _3OGS_Debug.TextPopup(&quot;Test1&quot;, Vector3.up));
                  
DebugButtonPanel.AddButton(
                  btnPanel.GetComponent&lt;DebugButtonPanel&gt;(),
                  &quot;Test 2&quot;,
                  () =&gt; _3OGS_Debug.TextPopup(&quot;Test2&quot;, Vector3.up));
                  
DebugButtonPanel.AddButton(
                  btnPanel.GetComponent&lt;DebugButtonPanel&gt;(),
                  &quot;Test 3&quot;,
                  &quot;This is a add button test!&quot;);
</code></pre>
<hr sourcefile="articles/index.md" sourcestartlinenumber="188">
<p sourcefile="articles/index.md" sourcestartlinenumber="189">💡 Momento de imaginación: Tienes un Orco que en su AI implementa una finite state machine, el orco tiene 4 estados; descansar, patrullar, moverse y atacar. Para entrar a cada uno de estos estados se deben cumplir distintas condiciones que pueden o no involucrar al jugador. Testear todos los estados puede ser tedioso si para hacerlo necesitamos hacer que el personaje cumpla las condiciones para entrar en el estado que necesitamos. Hay diversas soluciones a este problema, un DebugButtonPanel es una de ellas que sólo lleva tantas líneas de código como estados en la state machine tengas. Al a hacer click en un botón en el mundo podrás cambiar a antojo el estado de la state machine.</p>
<hr sourcefile="articles/index.md" sourcestartlinenumber="191">
<h3 id="_3ogs_debug-worldtext--textpopup" sourcefile="articles/index.md" sourcestartlinenumber="193">_3OGS_Debug: WorldText &amp; TextPopup</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="194">Como he dicho anteriormente, la consola en algunos proyectos puede estar llena de logs de distintos orígenes haciendo difícil trackear tus propios logs. Para evitar esto y poder loggear información sin necesidad si quiera de mover tu vista de la ventana “Game” existen WorldText &amp; TextPopup. Además gracias a ellos puedes loggear información en una Dev Build.</p>
<h4 id="worldtext" sourcefile="articles/index.md" sourcestartlinenumber="196"><strong sourcefile="articles/index.md" sourcestartlinenumber="196">WorldText</strong></h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="197">Es un TextMesh(no TextMeshPro) en el mundo, es estático.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="199"><img src="images/worldText_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="199" alt="WorldText_sample"></p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="201">public static GameObject _3OGS_Debug.WorldText(
                                            string text,
                                            Transform parent = null,
                                            Vector3 localPosition = default(Vector3),
                                            int fontSize = 40,
                                            Color? color = null,
                                            TextAnchor textAnchor = TextAnchor.UpperLeft,
                                            TextAlignment textAlignment = TextAlignment.Left,
                                            int sortingOrder = _3OGS_Utils.sortingOrderDefault
                                            )
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="214">Ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="216">_3OGS_Debug.WorldText(
                    text: &quot;Door &quot; + door.name,
                    localPosition: door.position + Vector.up * 0.5f,
                    fontSize: 20,
                    color: Color.red,
                    textAnchor: TextAnchor.MiddleCenter
                    );
</code></pre>
<h4 id="textpopup" sourcefile="articles/index.md" sourcestartlinenumber="226"><strong sourcefile="articles/index.md" sourcestartlinenumber="226">TextPopup</strong></h4>
<p sourcefile="articles/index.md" sourcestartlinenumber="227">Es un WorldText que al instanciarlo sube hacía arriba un poco hasta destruirse luego de un segundo.</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="229">public static void TextPopup(string text, Vector3 position)

public static void TextPopup(string text, Vector3 position, float popupTime)
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="235">Ejemplo de implementación:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="237">GameObject btnObj = _3OGS_Debug.CreateDebugButton(
                                    &quot;Example&quot;,
                                    Vector3.up,
                                    () =&gt; _3OGS_Debug.TextPopup(&quot;Example log&quot;, Vector3.up * 1.5f)
                                    );
</code></pre>
<h3 id="_3ogs_utils-monobehaviour-functions" sourcefile="articles/index.md" sourcestartlinenumber="245">_3OGS_Utils: MonoBehaviour Functions</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="246">Las MonoBehaviour Functions son clases de utilería que heredan de MonoBehaviour, el plugin las utiliza y están disponibles para que cualquiera las use. Sin embargo cubriré su explicación de una mejor manera en la version 0.1.1 del plugin. Por ahora dejaré un pequeño resumen de cada una:</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="248"><strong sourcefile="articles/index.md" sourcestartlinenumber="248">FunctionUpdater:</strong> Ejecuta una función como si la hubieras puesto dentro de un void Update()</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="249">FunctionUpdater.Create(() =&gt; { 
                            if(GameManager.PlayerDead)
                                Debug.Log(&quot;Player is dead&quot;);
                        });
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="256"><strong sourcefile="articles/index.md" sourcestartlinenumber="256">FunctionTimer:</strong> Ejecuta una función luego de un temporizador</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="257">FunctionTimer.Create(() =&gt; { 
                        bomb.Explode();
                    }, 5f);
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="263"><strong sourcefile="articles/index.md" sourcestartlinenumber="263">FunctionPeriodic:</strong> Ejecuta una función periódicamente cada X tiempo</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="264">FunctionPeriodic.Create(() =&gt; { 
                            enemyAI.TryAttack();
                        }, enemyAI.AttackVelocity);
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="270">Estas funciones son muy útiles para hacer prototipos rápido, pero no deberían usarse para juegos construir un juego completo ya que no son muy eficientes en el uso de recursos.</p>
<h3 id="runtimedebugobjectsmanager" sourcefile="articles/index.md" sourcestartlinenumber="272">RuntimeDebugObjectsManager</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="273">Puede llegar un punto en el que tengas tantos botones y textos en tu mundo que no puedas ver correctamente la escena, para resolver esto existen los métodos:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="275">public static void _3OGS_Debug.RuntimeDebugObjectsManager.DisableDebugObjects()

public static void _3OGS_Debug.RuntimeDebugObjectsManager.EnableDebugObjects()
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="281">Estos sirven para ocultar o mostrar los DebugObjects en tu mundo, una buena implementación de ellos sería:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="283">_3OGS_Utils.CreateKeyCodeAction(KeyCode.T,
        () =&gt; {
            if (_3OGS_Utils.IsBuildForProduction()) return;
            _3OGS_Debug.RuntimeDebugObjectsManager.DisableDebugObjects();
        });

_3OGS_Utils.CreateKeyCodeAction(KeyCode.R,
        () =&gt; {
            if (_3OGS_Utils.IsBuildForProduction()) return;
            _3OGS_Debug.RuntimeDebugObjectsManager.EnableDebugObjects();
        });
</code></pre>
<p sourcefile="articles/index.md" sourcestartlinenumber="297">Ahora puedes ver lo útil que puede ser también CreateKeyCodeAction cuando lo combinas con otros métodos del plugin, vale la pena pensar en este tipo de combinaciones.</p>
<h3 id="_3ogs_debugmanager" sourcefile="articles/index.md" sourcestartlinenumber="299">_3OGS_DebugManager</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="300">Para usar el plugin debes tener un objeto con el script 3OGS_DebugManager en tu escena inicial. El manager hace una pequeña pero importante configuración de inicio. El plugin se configura con la referencia a un prefab en la variable Settings dentro del manager, este prefab debe contener el componente _3OGS_DebuggerConfig.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="302"><img src="images/debugger_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="302" alt="Debugger_sample"></p>
<p sourcefile="articles/index.md" sourcestartlinenumber="304">En la versión anterior se utilizaba un Scriptable Object para asignar la configuración, pero por razones de compatibilidad para viejas versiones de Unity ahora se configura el plugin de esta manera.</p>
<h3 id="configuración-del-plugin" sourcefile="articles/index.md" sourcestartlinenumber="306">Configuración del plugin</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="307">La configuración default del plugin está en la siguiente ruta:</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="309"><img src="images/pluginConfig_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="309" alt="PluginConfig_sample"></p>
<p sourcefile="articles/index.md" sourcestartlinenumber="311">Recomiendo crear una propia basándote en la existente.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="313">La configuración default tiene los siguientes valores, sólo explicare los que considero necesarios porque sus nombres son suficiente para entender a qué pertenecen y para que sirven.</p>
<p sourcefile="articles/index.md" sourcestartlinenumber="315"><img src="images/defaultConfig_sample.png" sourcefile="articles/index.md" sourcestartlinenumber="315" alt="DefaultConfig_sample"></p>
<h5 id="isbuildforproduction" sourcefile="articles/index.md" sourcestartlinenumber="317"><strong sourcefile="articles/index.md" sourcestartlinenumber="317">IsBuildForProduction</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="319">Este checkbox se describe solo y es muy importante, permite al programador hacer comprobaciones de versiones de producción del juego antes de ejecutar código correspondiente a las versiones de desarrollo los de proyectos que usen el plugin.
Un ejemplo:</p>
<pre><code sourcefile="articles/index.md" sourcestartlinenumber="322">void Start {
  if (_3OGS_Utils.IsBuildForProduction()) return;
  FunctionPeriodic.Create(() =&gt; { 
                        LogBossAIState();
                       }, 1f);
}
</code></pre>
<h5 id="defaultbuttonsize" sourcefile="articles/index.md" sourcestartlinenumber="331"><strong sourcefile="articles/index.md" sourcestartlinenumber="331">DefaultButtonSize</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="333">Dado que la escala de los objetos varía según proyecto, es importante saber que puedes configurar el tamaño de los botones. Al igual que el tamaño de fuente con DefaultFontSize.</p>
<h5 id="defaultbuttonpaneloffset" sourcefile="articles/index.md" sourcestartlinenumber="335"><strong sourcefile="articles/index.md" sourcestartlinenumber="335">DefaultButtonPanelOffset</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="337">Sencillamente el espacio entre los botones de un DebugButtonPanel.</p>
<h5 id="buttonlayermask" sourcefile="articles/index.md" sourcestartlinenumber="339"><strong sourcefile="articles/index.md" sourcestartlinenumber="339">ButtonLayerMask</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="341">Los botones tienen hacen uso de un BoxCollider para funcionar. Puedes configurar en que layer estarán los objetos para que no tengas colisiones no deseadas con ellos.</p>
<h5 id="debugobjectsdrawdistance" sourcefile="articles/index.md" sourcestartlinenumber="343"><strong sourcefile="articles/index.md" sourcestartlinenumber="343">DebugObjectsDrawDistance</strong></h5>
<p sourcefile="articles/index.md" sourcestartlinenumber="345">Los objetos de _3OGS_Debug desaparecen si la distancia es mayor a la establecida.</p>
<h3 id="ejemplos" sourcefile="articles/index.md" sourcestartlinenumber="347">Ejemplos</h3>
<p sourcefile="articles/index.md" sourcestartlinenumber="348">_3OGS_Utils viene con un script de ejemplo y un prefab con el script _3OGS_DebuggerManager para que puedas usar el plugin sólo agregando un objeto a la escena.</p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/jLautaroCabral-3OGs/3OGS_Utils-Doc/blob/master/articles/index.md/#L1" class="contribution-link">Improve this Doc</a>
                  </li>
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>
