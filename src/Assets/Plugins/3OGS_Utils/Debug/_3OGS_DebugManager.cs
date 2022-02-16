/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _3OGS.Debug
{
    /// <summary>
    /// The manager of the all Debug gameobjects of the plugin. Receive an object with a <c>_3OGS_DebuggerConfig</c> component for set the DebugManager settings. Implements a singleton pattern and when their shared instance is null, a new instance of DebugManager is created automatically using a default configuration built in of the plugin
    /// </summary>
    [DefaultExecutionOrder(-1000)]
    public class _3OGS_DebugManager : MonoBehaviour
    {
        private static _3OGS_DebugManager _sharedInstance;

        /// <summary>
        /// The singleton shared instance
        /// </summary>
        public static _3OGS_DebugManager SharedInstance
        { get 
            { 
                if (_sharedInstance == null)
                {
                    _3OGS_DebugManager newDebugManager = new GameObject("3OGS_DebugManager", typeof(_3OGS_DebugManager)).GetComponent<_3OGS_DebugManager>();
                     newDebugManager.Settings = _3OGS_DebuggerConfig.CreateDefaultSettings();
                     return newDebugManager;
                }
                else
                {
                    return _sharedInstance;
                }
            }
        }

        /// <summary>
        /// The settings required for the Debug plugin
        /// </summary>
        public _3OGS_DebuggerConfig Settings;

        /// <summary>
        /// A gameobject used only for helper purphoses
        /// </summary>
        [HideInInspector]
        public GameObject EmptyObject;

        private GameObject _debugFunctionContainer;

        /// <summary>
        /// A gameobject used for contain all the FunctionUpdater, FunctionTimer and FunctionPeriodic gameobjects
        /// </summary>
        internal GameObject DebugFunctionsContainer
        { 
            get
            {
                if(_debugFunctionContainer == null)
                {
                    _debugFunctionContainer = new GameObject("3OGS_Debug Functions Container");
                    return _debugFunctionContainer;
                }
                else
                {
                    return _debugFunctionContainer;
                }
            }
        }

        private void Awake()
        {
            // Only one instance of DebugManager at a time!
            if (_sharedInstance != null)
            {
                Destroy(gameObject);
                return;
            }
            _sharedInstance = this;

            EmptyObject = new GameObject("LC_EmptyObject");
            EmptyObject.transform.SetParent(this.transform);

            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            CameraSwitcher.SetupCurrentCamera(_3OGS_Utils.GetCurrentCamera());

            FunctionUpdater.Create(_3OGS_Debug.RuntimeDebugObjectsManager.HandleDebugObjectsFarFromCamera);
            if (!Physics.queriesHitTriggers)
                FunctionPeriodic.Create(() => UnityEngine.Debug.LogError("3OGS_Debug ERROR: Please enable Queries Hit Triggers on Project Settings > Physics"), () => Physics.queriesHitTriggers, 2f);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            CameraSwitcher.SetupCurrentCamera(_3OGS_Utils.GetCurrentCamera());
        }
    }
}