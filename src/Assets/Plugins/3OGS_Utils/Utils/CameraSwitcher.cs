/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _3OGS.Utils
{
    /// <summary>
    /// This class handles the camera switching in the plugin.
    /// </summary>
    public class CameraSwitcher
    {
        private CameraSwitcher() { }
        /// <summary>
        /// Camera currently rendering
        /// </summary>
        internal static Camera CurrentCamera { get; private set; }
        private static Camera _previousCamera;
        private static Action _returnToPreviousCameraAction;

        /// <summary>
        /// Caches and setup the current camera we are currently rendering with <paramref name="camera"/>
        /// </summary>
        /// <param name="camera">Camera to set</param>
        public static void SetupCurrentCamera(Camera camera)
        {
            CurrentCamera = camera;
            Camera.SetupCurrent(camera);
        }

        /// <summary>
        /// Caches the Action to be executed when calling the <c>ReturnToOriginalCamera</c>. function.
        /// </summary>
        /// <param name="returnToPreviousCameraAction">The action to be executed</param>
        public static void SetupReturnAction(Action returnToPreviousCameraAction)
        {
            _previousCamera = CurrentCamera;
            CameraSwitcher._returnToPreviousCameraAction = returnToPreviousCameraAction;
        }

        /// <summary>
        /// Caches the Action to be executed and caches the camera to set when calling the <c>ReturnToOriginalCamera</c> function.
        /// </summary>
        /// <param name="camera">The action to be executed</param>
        /// <param name="returnToPreviousCameraAction">The camera to set</param>
        public static void SetupReturnAction(Camera camera, Action returnToPreviousCameraAction)
        {
            _previousCamera = camera;
            CameraSwitcher._returnToPreviousCameraAction = returnToPreviousCameraAction;
        }

        /// <summary>
        /// The cached previous camera will be setted
        /// </summary>
        public static void ReturnToOriginalCamera()
        {
            SetupCurrentCamera(_previousCamera);
            _returnToPreviousCameraAction();
        }
    }
}

