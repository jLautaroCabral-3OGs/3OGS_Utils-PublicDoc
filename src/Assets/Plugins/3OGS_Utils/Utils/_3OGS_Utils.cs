/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Debug;
using System;
using UnityEngine;

namespace _3OGS.Utils
{
    /// <summary>
    /// This class contains several utility methods
    /// </summary>
    public static class _3OGS_Utils
    {
        /// <summary>
        /// Field used for set sorting order layer of some plugin debug game objects components
        /// </summary>
        internal const int SortingOrderDefault = 5000;

        // Get Main Canvas Transform
        private static Transform cachedCanvasTransform;

        /// <summary>
        /// Get the Canvas transform cached from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The Canvas transform
		/// </returns>
        public static Transform GetCanvasTransform()
        {
            if (cachedCanvasTransform == null)
            {
                Canvas canvas = MonoBehaviour.FindObjectOfType<Canvas>();
                if (canvas != null)
                {
                    cachedCanvasTransform = canvas.transform;
                }
            }
            return cachedCanvasTransform;
        }

        /// <summary>
        /// Get the mouse position in pixel coordinates
        /// </summary>
        /// <returns>
		/// The mouse position 
		/// </returns>
        public static Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }

        /// <summary>
        /// Get the mouse position in World with Z = 0f
        /// </summary>
        /// <returns>
		/// The mouse position in World with Z = 0f
		/// </returns>
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            Vector3 vec = GetMouseWorldPosition(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }


        /// <summary>
        /// Get the mouse position in World
        /// </summary>
        /// <param name="screenPosition">Position in the screen to obtain world position</param>
        /// <param name="worldCamera">Camera of the <paramref name="screenPosition"/></param>
        /// <returns>
        /// The mouse position in World
        /// </returns>
        public static Vector3 GetMouseWorldPosition(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        /// <summary>
        /// Create an Action that will be called by holding down a key
        /// </summary>
        /// <param name="keyCode">KeyCode trigger</param>
        /// <param name="onKeyDown">Action to execute on <paramref name="keyCode"/> trigger</param>
        /// <returns>
        /// The FunctionUpdater object containing the Action
        /// </returns>
        public static FunctionUpdater CreateKeyCodeAction(KeyCode keyCode, Action onKeyDown)
        {
            return FunctionUpdater.Create(() => {
                if (Input.GetKey(keyCode))
                {
                    onKeyDown();
                }
                return false;
            });
        }


        /// <summary>
        /// Create an Action that will be called when a key is released
        /// </summary>
        /// <param name="keyCode">KeyCode trigger</param>
        /// <param name="onKeyDown">Action to execute on <paramref name="keyCode"/> trigger</param>
        /// <returns>
        /// The FunctionUpdater object containing the Action
        /// </returns>
        public static FunctionUpdater CreateKeyCodeUpAction(KeyCode keyCode, Action onKeyDown)
        {
            return FunctionUpdater.Create(() => {
                if (Input.GetKeyUp(keyCode))
                {
                    onKeyDown();
                }
                return false;
            });
        }

        /// <summary>
        /// Create an Action that will be called when a key is pressed
        /// </summary>
        /// <param name="keyCode">KeyCode trigger</param>
        /// <param name="onKeyDown">Action to execute on <paramref name="keyCode"/> trigger</param>
        /// <returns>
        /// The FunctionUpdater object containing the Action
        /// </returns>
        public static FunctionUpdater CreateKeyCodeDownAction(KeyCode keyCode, Action onKeyDown)
        {
            return FunctionUpdater.Create(() => {
                if (Input.GetKeyDown(keyCode))
                {
                    onKeyDown();
                }
                return false;
            });
        }

        /// <summary>
        /// Get the camera that is currently rendering from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The camera that is currently rendering
		/// </returns>
        public static Camera GetCurrentCamera()
        {
            foreach(Camera cam in Camera.allCameras)
            {
                if (cam == Camera.current)
                    return cam;
            }
            return Camera.main;
        }

        /// <summary>
        /// Get the support empty game object from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The support empty game object
		/// </returns>
        public static GameObject GetDeafultEmptyObject()
        {
            return _3OGS_DebugManager.SharedInstance.EmptyObject;
        }

        /// <summary>
        /// Get the default font from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default font
		/// </returns>
        public static Font GetDefaultFont()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultFont;
        }

        /// <summary>
        /// Get the default square sprite from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default square sprite
		/// </returns>
        public static Sprite GetDefaultSquareSprite()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonSprite;
        }

        /// <summary>
        /// Get the default button color from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default button color
		/// </returns>
        public static Color GetDefaultButtonColor()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonColor;
        }

        /// <summary>
        /// Get the default button color on click from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default button color on mouse click
		/// </returns>
        public static Color GetButtonColorOnClick()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonColorOnClick;
        }

        /// <summary>
        /// Get the default button color on mouse over from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default button color on mouse over
		/// </returns>
        public static Color GetButtonColorOnOver()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonColorOnOver;
        }

        /// <summary>
        /// Get the default button size from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default button size
		/// </returns>
        public static Vector3 GetButtonSize()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonSize;
        }

        /// <summary>
        /// Get the default font size from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default font size
		/// </returns>
        public static int GetFontSize()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultFontSize;
        }

        /// <summary>
        /// Get the default button panel offset from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The default button panel offset
		/// </returns>
        public static float GetButtonPanelOffset()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.DefaultButtonPanelOffset;
        }

        /// <summary>
        /// Get settings from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
		/// The DebugManager settings <c>_3OGS_DebugManager.Settings</c>
		/// </returns>
        public static _3OGS_DebuggerConfig GetSettings()
        {
            return _3OGS_DebugManager.SharedInstance.Settings;
        }

        /// <summary>
        /// Get the IsBuildForProduction from _3OGS_DebugManager.Settings
        /// </summary>
        /// <returns>
        /// <c>true</c> if the build is for production
        /// </returns>
        public static bool IsBuildForProduction()
        {
            return _3OGS_DebugManager.SharedInstance.Settings.IsBuildForProduction;
        }

        /// <summary>
        /// Translate from int to hexadecimal channel string
        /// </summary>
        /// <param name="value"> An integer between 0 -> 255</param>
        /// <returns>
        /// A hex string based on a number between 0 -> 255
        /// </returns>
        public static string Dec_to_Hex(int value)
        {
            return value.ToString("X2");
        }

        /// <summary>
        /// Translate from hexadecimal channel string to int 0 -> 255
        /// </summary>
        /// <param name="hex">Two characters string 'FF'</param>
        /// <returns>
        /// An integer between 0 -> 255
        /// </returns>
        public static int Hex_to_Dec(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        /// <summary>
        /// Translate from float to hexadecimal channel string 'FF'
        /// </summary>
        /// <param name="value">Float between 0.0 -> 1.0 </param>
        /// <returns>
        /// A hex string based on a number between 0.0 -> 1.0
        /// </returns>
        public static string Dec01_to_Hex(float value)
        {
            return Dec_to_Hex((int)Mathf.Round(value * 255f));
        }

        /// <summary>
        /// Translate from hexadecimal channel string to decimal 0.0 -> 1.0
        /// </summary>
        /// <param name="hex">Two characters string 'FF'</param>
        /// <returns>
        /// A float between 0.0 -> 1.0
        /// </returns>
        public static float Hex_to_Dec01(string hex)
        {
            return Hex_to_Dec(hex) / 255f;
        }

        /// <summary>
        /// Translate from color to hexadecimal string
        /// </summary>
        /// <param name="color">Color to translate</param>
        /// <returns>
        /// A hex string FF00FF
        /// </returns>
        public static string GetStringFromColor(Color color)
        {
            string red = Dec01_to_Hex(color.r);
            string green = Dec01_to_Hex(color.g);
            string blue = Dec01_to_Hex(color.b);
            return red + green + blue;
        }

        /// <summary>
        /// Translate from color to hexadecimal string with alpha
        /// </summary>
        /// <param name="color">Color to translate</param>
        /// <returns>
        /// A hex string FF00FFAA
        /// </returns>
        public static string GetStringFromColorWithAlpha(Color color)
        {
            string alpha = Dec01_to_Hex(color.a);
            return GetStringFromColor(color) + alpha;
        }

        /// <summary>
        /// Gets out values to Hex String 'FF'
        /// </summary>
        /// <param name="color">Color to translate</param>
        /// <param name="red">FF Red channel out string</param>
        /// <param name="green">FF Green channel out string</param>
        /// <param name="blue">FF Blue channel out string</param>
        /// <param name="alpha">FF Aplha channel out string</param>
        public static void GetStringFromColor(Color color, out string red, out string green, out string blue, out string alpha)
        {
            red = Dec01_to_Hex(color.r);
            green = Dec01_to_Hex(color.g);
            blue = Dec01_to_Hex(color.b);
            alpha = Dec01_to_Hex(color.a);
        }

        /// <summary>
        /// Translate a <paramref name="r"/><paramref name="g"/><paramref name="b"/> color values to string
        /// </summary>
        /// <param name="r">Red channel</param>
        /// <param name="g">Green channel</param>
        /// <param name="b">Blue channel</param>
        /// <returns>
        /// A hex string FF00FF
        /// </returns>
        public static string GetStringFromColor(float r, float g, float b)
        {
            string red = Dec01_to_Hex(r);
            string green = Dec01_to_Hex(g);
            string blue = Dec01_to_Hex(b);
            return red + green + blue;
        }

        /// <summary>
        /// Translate a <paramref name="r"/><paramref name="g"/><paramref name="b"/><paramref name="a"/> color values to string
        /// </summary>
        /// <param name="r">Red channel</param>
        /// <param name="g">Green channel</param>
        /// <param name="b">Blue channel</param>
        /// <param name="a">Alpha channel</param>
        /// <returns>
        /// A hex string FF00FFAA
        /// </returns>
        public static string GetStringFromColor(float r, float g, float b, float a)
        {
            string alpha = Dec01_to_Hex(a);
            return GetStringFromColor(r, g, b) + alpha;
        }

        /// <summary>
        /// Translate a hexadecimal string to a color
        /// </summary>
        /// <param name="color">Hex string FF00FF or FF00FFAA</param>
        /// <returns>
        /// A Color from string
        /// </returns>
        public static Color GetColorFromString(string color)
        {
            float red = Hex_to_Dec01(color.Substring(0, 2));
            float green = Hex_to_Dec01(color.Substring(2, 2));
            float blue = Hex_to_Dec01(color.Substring(4, 2));
            float alpha = 1f;
            if (color.Length >= 8)
            {
                // Color string contains alpha
                alpha = Hex_to_Dec01(color.Substring(6, 2));
            }
            return new Color(red, green, blue, alpha);
        }
    }
}