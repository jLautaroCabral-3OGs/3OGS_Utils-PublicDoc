/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Debug;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _3OGS.Utils
{
    /// <summary>
    /// Utility class that executes a function once per frame
    /// </summary>
    public class FunctionUpdater : MonoBehaviour
    {
        /*
         * Class to hook Actions into MonoBehaviour
         * */
        private class MonoBehaviourHook : MonoBehaviour
        {

            internal Action OnUpdate { get; set; }

            private void Update()
            {
                if (OnUpdate != null) OnUpdate();
            }

        }

        private static List<FunctionUpdater> _updaterList; // Holds a reference to all active updaters
        private static GameObject _initGameObject; // Global game object used for initializing class, is destroyed on scene change

        private static void InitIfNeeded()
        {
            if (_initGameObject == null)
            {
                _initGameObject = new GameObject("FunctionUpdater_Global");
                _updaterList = new List<FunctionUpdater>();
            }
        }

        /// <summary>
        /// Trigger <paramref name="updateFunc"/> once per frame, like <c>MonoBehaviour.Update</c>
        /// </summary>
        /// <param name="updateFunc">The Action to be executed</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionUpdater Create(Action updateFunc)
        {
            return Create(() => { updateFunc(); return false; }, "", true, false);
        }

        /// <summary>
        /// Trigger <paramref name="updateFunc"/> once per frame, like <c>MonoBehaviour.Update</c>
        /// </summary>
        /// <param name="updateFunc">The Action to be executed, if it returns true then the loop will be terminated</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionUpdater Create(Func<bool> updateFunc)
        {
            return Create(updateFunc, "", true, false);
        }

        /// <summary>
        /// Trigger <paramref name="updateFunc"/> once per frame called <paramref name="functionName"/> , like <c>MonoBehaviour.Update</c>
        /// </summary>
        /// <param name="updateFunc">The Action to be executed, if it returns true then the loop will be terminated</param>
        /// <param name="functionName">The function updater name</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionUpdater Create(Func<bool> updateFunc, string functionName)
        {
            return Create(updateFunc, functionName, true, false);
        }

        /// <summary>
        /// Trigger <paramref name="updateFunc"/> once per frame called <paramref name="functionName"/> , like <c>MonoBehaviour.Update</c>
        /// </summary>
        /// <param name="updateFunc">The Action to be executed, if it returns true then the loop will be terminated</param>
        /// <param name="functionName">The function updater name</param>
        /// <param name="active">Set the function updater status, can be active or paused</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionUpdater Create(Func<bool> updateFunc, string functionName, bool active)
        {
            return Create(updateFunc, functionName, active, false);
        }

        /// <summary>
        /// Trigger <paramref name="updateFunc"/> once per frame called <paramref name="functionName"/> , like <c>MonoBehaviour.Update</c>
        /// </summary>
        /// <param name="updateFunc">The Action to be executed, if it returns true then the loop will be terminated</param>
        /// <param name="functionName">The function updater name</param>
        /// <param name="active">Set the function updater status, can be active or paused</param>
        /// <param name="stopAllWithSameName">Stop all the function updater objects with the same name when <paramref name="updateFunc"/> returns true</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionUpdater Create(Func<bool> updateFunc, string functionName, bool active, bool stopAllWithSameName)
        {
            InitIfNeeded();

            if (stopAllWithSameName)
            {
                StopAllUpdatersWithName(functionName);
            }
            GameObject gameObject = new GameObject("FunctionUpdater Object " + functionName, typeof(MonoBehaviourHook));

            FunctionUpdater functionUpdater = gameObject.AddComponent<FunctionUpdater>();
            functionUpdater.SetFuctionUpdaterData(gameObject, updateFunc, functionName, active);

            gameObject.GetComponent<MonoBehaviourHook>().OnUpdate = functionUpdater.Update;

            gameObject.transform.parent = _3OGS_DebugManager.SharedInstance.DebugFunctionsContainer.transform;

            _updaterList.Add(functionUpdater);
            return functionUpdater;
        }

        private static void RemoveUpdater(FunctionUpdater funcUpdater)
        {
            InitIfNeeded();
            _updaterList.Remove(funcUpdater);
        }

        /// <summary>
        /// Destroy a function updater
        /// </summary>
        /// <param name="funcUpdater">Function updater to destroy</param>
        public static void DestroyUpdater(FunctionUpdater funcUpdater)
        {
            InitIfNeeded();
            if (funcUpdater != null)
            {
                funcUpdater.DestroySelf();
            }
        }

        /// <summary>
        /// Stop and destroy a function updater object filtered by name
        /// </summary>
        /// <param name="functionName">Function updater name to destroy</param>
        public static void StopUpdaterWithName(string functionName)
        {
            InitIfNeeded();
            for (int i = 0; i < _updaterList.Count; i++)
            {
                if (_updaterList[i]._functionName == functionName)
                {
                    _updaterList[i].DestroySelf();
                    return;
                }
            }
        }

        /// <summary>
        /// Stop and destroy all the function updater objects with the same name
        /// </summary>
        /// <param name="functionName">Function updater name to destroy</param>
        public static void StopAllUpdatersWithName(string functionName)
        {
            InitIfNeeded();
            for (int i = 0; i < _updaterList.Count; i++)
            {
                if (_updaterList[i]._functionName == functionName)
                {
                    _updaterList[i].DestroySelf();
                    i--;
                }
            }
        }

        /// <summary>
        /// Remove function updater and destroy the gameobject
        /// </summary>
        public void DestroySelf()
        {
            RemoveUpdater(this);
            if (_gameObject != null)
            {
                UnityEngine.Object.Destroy(_gameObject);
            }
        }

        /// <summary>
        /// Set the function updater data
        /// </summary>
        /// <param name="gameObject">Function updater gameobject</param>
        /// <param name="updateFunc">Function updater funtion</param>
        /// <param name="functionName">Function updater name</param>
        /// <param name="active">Function updater status</param>
        public void SetFuctionUpdaterData(GameObject gameObject, Func<bool> updateFunc, string functionName, bool active)
        {
            this._gameObject = gameObject;
            this._updateFunc = updateFunc;
            this._functionName = functionName;
            this._active = active;
        }

        /// <summary>
        /// Set the active status to false
        /// </summary>
        public void Pause()
        {
            _active = false;
        }

        /// <summary>
        /// Set the active status to true
        /// </summary>
        public void Resume()
        {
            _active = true;
        }

        private GameObject _gameObject;
        private string _functionName;
        private bool _active;
        private Func<bool> _updateFunc; // Destroy Updater if return true;

        private void Update()
        {
            if (!_active) return;
            if (_updateFunc())
                DestroySelf();
        }
    }
}