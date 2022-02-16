/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using System;
using UnityEngine;
using System.Collections.Generic;
using _3OGS.Debug;

namespace _3OGS.Utils
{
    /// <summary>
    /// Utility class that executes a function after a certain time
    /// </summary>
    public class FunctionTimer
    {

        /*
         * Class to hook Actions into MonoBehaviour
         * */
        private class FTMonoBehaviourHook : MonoBehaviour
        {
            internal Action OnUpdate { get; set; }

            private void Update()
            {
                if (OnUpdate != null) OnUpdate();
            }

        }

        private static List<FunctionTimer> _timerList; // Holds a reference to all active timers
        private static GameObject _initGameObject; // Global game object used for initializing class, is destroyed on scene change

        private static void InitIfNeeded()
        {
            if (_initGameObject == null)
            {
                _initGameObject = new GameObject("FunctionTimer_Global");
                _timerList = new List<FunctionTimer>();
            }
        }

        /// <summary>
        /// Create a function timer that persists across scene loads
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay until the execution of <paramref name="action"/></param>
        /// <returns>The FunctionTimer object containing the Action</returns>
        public static FunctionTimer Create(Action action, float timer)
        {
            return Create(action, timer, "", false, false);
        }

        /// <summary>
        /// Trigger <paramref name="action"/> after <paramref name="timer"/> called <paramref name="functionName"/> has elapsed
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay until the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function timer name</param>
        /// <returns>The FunctionTimer object containing the Action</returns>
        public static FunctionTimer Create(Action action, float timer, string functionName)
        {
            return Create(action, timer, functionName, false, false);
        }

        /// <summary>
        /// Trigger <paramref name="action"/> after <paramref name="timer"/> called <paramref name="functionName"/> has elapsed
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay until the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function timer name</param>
        /// <param name="useUnscaledDeltaTime">The timer will be use unscaledDeltaTime</param>
        /// <returns>The FunctionTimer object containing the Action</returns>
        public static FunctionTimer Create(Action action, float timer, string functionName, bool useUnscaledDeltaTime)
        {
            return Create(action, timer, functionName, useUnscaledDeltaTime, false);
        }

        /// <summary>
        /// Trigger <paramref name="action"/> after <paramref name="timer"/> called <paramref name="functionName"/> has elapsed
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay until the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function timer name</param>
        /// <param name="useUnscaledDeltaTime">The timer will be use unscaledDel</param>
        /// <param name="stopAllWithSameName">Stop all the function timer objects with the same name after <paramref name="timer"/> has elapsed</param>
        /// <returns>The FunctionTimer object containing the Action</returns>
        public static FunctionTimer Create(Action action, float timer, string functionName, bool useUnscaledDeltaTime, bool stopAllWithSameName)
        {
            InitIfNeeded();

            if (stopAllWithSameName)
            {
                StopAllTimersWithName(functionName);
            }

            GameObject obj = new GameObject("FunctionTimer Object " + functionName, typeof(FTMonoBehaviourHook));
            FunctionTimer funcTimer = new FunctionTimer(obj, action, timer, functionName, useUnscaledDeltaTime);
            obj.GetComponent<FTMonoBehaviourHook>().OnUpdate = funcTimer.Update;

            obj.transform.parent = _3OGS_DebugManager.SharedInstance.DebugFunctionsContainer.transform;

            _timerList.Add(funcTimer);

            return funcTimer;
        }

        /// <summary>
        /// Use this function to remove the function timer of the function timer cached list
        /// </summary>
        /// <param name="funcTimer">Function periodic to remove</param>
        public static void RemoveTimer(FunctionTimer funcTimer)
        {
            InitIfNeeded();
            _timerList.Remove(funcTimer);
        }

        /// <summary>
        /// Stop and destroy all the function timer objects with the same name in the runtime
        /// </summary>
        /// <param name="functionName">Function timer name to stop</param>
        public static void StopAllTimersWithName(string functionName)
        {
            InitIfNeeded();
            for (int i = 0; i < _timerList.Count; i++)
            {
                if (_timerList[i]._functionName == functionName)
                {
                    _timerList[i].DestroySelf();
                    i--;
                }
            }
        }

        /// <summary>
        /// Stop and destroy the first function timer object in the function timer cached list
        /// </summary>
        /// <param name="functionName">Function timer name to stop</param>
        public static void StopFirstTimerWithName(string functionName)
        {
            InitIfNeeded();
            for (int i = 0; i < _timerList.Count; i++)
            {
                if (_timerList[i]._functionName == functionName)
                {
                    _timerList[i].DestroySelf();
                    return;
                }
            }
        }

        private GameObject _gameObject;
        private float _timer;
        private string _functionName;
        private bool _active;
        private bool _useUnscaledDeltaTime;
        private Action _action;

        public FunctionTimer(GameObject gameObject, Action action, float timer, string functionName, bool useUnscaledDeltaTime)
        {
            this._gameObject = gameObject;
            this._action = action;
            this._timer = timer;
            this._functionName = functionName;
            this._useUnscaledDeltaTime = useUnscaledDeltaTime;
        }

        private void Update()
        {
            if (_useUnscaledDeltaTime)
                _timer -= Time.unscaledDeltaTime;
            else
                _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                // Timer complete, trigger Action
                _action();
                DestroySelf();
            }
        }
        private void DestroySelf()
        {
            RemoveTimer(this);
            if (_gameObject != null)
            {
                UnityEngine.Object.Destroy(_gameObject);
            }
        }

        /*
         * Class to trigger Actions manually without creating a GameObject
         * */
        private class FunctionTimerObject
        {

            private float timer;
            private Action callback;

            public FunctionTimerObject(Action callback, float timer)
            {
                this.callback = callback;
                this.timer = timer;
            }

            internal void Update()
            {
                Update(Time.deltaTime);
            }
            internal void Update(float deltaTime)
            {
                timer -= deltaTime;
                if (timer <= 0)
                {
                    callback();
                }
            }
        }

        // Create a Object that must be manually updated through Update();
        private static FunctionTimerObject CreateObject(Action callback, float timer)
        {
            return new FunctionTimerObject(callback, timer);
        }
    }
}