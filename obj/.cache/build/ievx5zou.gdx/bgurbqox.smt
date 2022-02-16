﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>3OGS_Utils v0.1.1 </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="3OGS_Utils v0.1.1 ">
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
<h1 id="3ogs_utils-v011">3OGS_Utils v0.1.1</h1>

<p>Build date: 14/02/22</p>
<p><a href="https://www.notion.so/3OGS_Utils-v0-1-0-ccb44303d2cb408982c170d2873d0e14">Ir al  changelog de la versión anterior</a></p>
<hr>
<h1 id="changelog">Changelog</h1>
<ul>
<li>Se ha cambiado el nombre del plugin de LC_Utils a 3OGS_Utils</li>
<li>Ahora el desarrollador debe comprobar él mismo si la versión del juego es de producción antes de ejecutar código correspondiente a una versión de desarrollo</li>
<li>La configuración del plugin ahora se asigna con un prefab que contenga el componente _3OGS_DebuggerConfig, da como resultado mayor compatibilidad con versiones anteriores de Unity</li>
<li>Se han hecho cambios para que el DebugManager obtenga una configuración default cuando no tenga asignada una configuración particular</li>
<li>Se han hecho ajustes de rendimiento para el uso de DebugCameras</li>
<li>Se han hecho modificaciones al DebugButtonPanel para permitir agregar un botón que instancie un mensaje a su lado al ser presionado</li>
<li>Las DebugFunction ahora se instancian dentro de un gameobject creado por runtime por el DebugManager</li>
<li>La currentCamera del CameraSwitcher ahora se asigna al cargar la escena</li>
<li>Se han hecho correcciones de nombres</li>
<li>Se han eliminado instrucciones using innecesarias</li>
<li>Se han documentado un gran número de métodos públicos</li>
<li>Se ha cambiado el modificador de accesibilidad en variedad de métodos</li>
</ul>
<h1 id="know-issues">Know Issues</h1>
<ul>
<li>Quedan algunos métodos que documentar</li>
<li>Quedan mejoras de uso de recursos pendiente</li>
<li>Hay que reestructurar algo de código</li>
<li>Hay que cambiar el retorno de algunos métodos de 3OGS_Debug para que el desarrollo sea más ágil</li>
<li>Puede que la asignación de la current camera en el DebugManager no funcione en todos los casos</li>
</ul>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/jLautaroCabral-3OGs/3OGS_Utils-Doc/blob/master/articles/changelog.md/#L1" class="contribution-link">Improve this Doc</a>
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
