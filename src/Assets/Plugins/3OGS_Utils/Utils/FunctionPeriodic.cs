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
    /// Utility class that executes a function periodically every so often
    /// </summary>
    public class FunctionPeriodic
    {
        /// <summary>
        /// Class to hook Actions into MonoBehaviour 
        /// </summary>
        private class FPMonoBehaviourHook : MonoBehaviour
        {
            internal Action OnUpdate { get; set; }

            private void Update()
            {
                if (OnUpdate != null) OnUpdate();
            }
        }

        private static List<FunctionPeriodic> _funcList; // Holds a reference to all active timers
        private static GameObject _initGameObject; // Global game object used for initializing class, is destroyed on scene change

        private static void InitIfNeeded()
        {
            if (_initGameObject == null)
            {
                _initGameObject = new GameObject("FunctionPeriodic_Global");
                _funcList = new List<FunctionPeriodic>();
            }
        }

        /// <summary>
        /// Create a function periodic that persists across scene loads
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="testDestroy">The function that will evaluate if the loop is still running, if it returns true then the loop will be terminated</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create_Global(Action action, Func<bool> testDestroy, float timer)
        {
            FunctionPeriodic functionPeriodic = Create(action, testDestroy, timer, "", false, false, false);
            MonoBehaviour.DontDestroyOnLoad(functionPeriodic._gameObject);
            return functionPeriodic;
        }


        /// <summary>
        /// Trigger <paramref name="action"/> every <paramref name="timer"/>, execute <paramref name="testDestroy"/> after triggering action, destroy if returns <c>true</c> 
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="testDestroy">The function that will evaluate if the loop is still running, if it returns true then the loop will be terminated</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create(Action action, Func<bool> testDestroy, float timer)
        {
            return Create(action, testDestroy, timer, "", false);
        }

        /// <summary>
        /// Trigger <paramref name="action"/> every <paramref name="timer"/>
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create(Action action, float timer)
        {
            return Create(action, null, timer, "", false, false, false);
        }

        /// <summary>
        /// Trigger <paramref name="action"/> every <paramref name="timer"/> called <paramref name="functionName"/>
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function periodic name</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create(Action action, float timer, string functionName)
        {
            return Create(action, null, timer, functionName, false, false, false);
        }

        /// <summary>
        /// Trigger <paramref name="callback"/> every <paramref name="timer"/> called <paramref name="functionName"/>, execute <paramref name="testDestroy"/> after triggering action, destroy if returns <c>true</c> 
        /// </summary>
        /// <param name="callback">The Action to be executed</param>
        /// <param name="testDestroy">The function that will evaluate if the loop is still running, if it returns true then the loop will be terminated</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function periodic name</param>
        /// <param name="stopAllWithSameName">Stop all the function periodic objects with the same name when <paramref name="testDestroy"/> returns true</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create(Action callback, Func<bool> testDestroy, float timer, string functionName, bool stopAllWithSameName)
        {
            return Create(callback, testDestroy, timer, functionName, false, false, stopAllWithSameName);
        }

        /// <summary>
        /// Trigger <paramref name="callback"/> every <paramref name="timer"/> called <paramref name="functionName"/>, execute <paramref name="testDestroy"/> after triggering action, destroy if returns <c>true</c> 
        /// </summary>
        /// <param name="action">The Action to be executed</param>
        /// <param name="testDestroy">The function that will evaluate if the loop is still running, if it returns true then the loop will be terminated</param>
        /// <param name="timer">Delay between the execution of <paramref name="action"/></param>
        /// <param name="functionName">The function periodic name</param>
        /// <param name="useUnscaledDeltaTime">The timer will be use unscaledDeltaTime</param>
        /// <param name="triggerImmediately">Immediately executes the function when created</param>
        /// <param name="stopAllWithSameName">Stop all the function periodic objects with the same name when <paramref name="testDestroy"/> returns true</param>
        /// <returns>The FunctionUpdater object containing the Action</returns>
        public static FunctionPeriodic Create(Action action, Func<bool> testDestroy, float timer, string functionName, bool useUnscaledDeltaTime, bool triggerImmediately, bool stopAllWithSameName)
        {
            InitIfNeeded();

            if (stopAllWithSameName)
            {
                StopAllFunc(functionName);
            }

            GameObject gameObject = new GameObject("FunctionPeriodic Object " + functionName, typeof(FPMonoBehaviourHook));
            FunctionPeriodic functionPeriodic = new FunctionPeriodic(gameObject, action, timer, testDestroy, functionName, useUnscaledDeltaTime);
            gameObject.GetComponent<FPMonoBehaviourHook>().OnUpdate = functionPeriodic.Update;

            gameObject.transform.parent = _3OGS_DebugManager.SharedInstance.DebugFunctionsContainer.transform;

            _funcList.Add(functionPeriodic);

            if (triggerImmediately) action();

            return functionPeriodic;
        }

        /// <summary>
        /// Use this function to remove the function periodic of the function periodic cached list
        /// </summary>
        /// <param name="funcTimer">Function periodic to remove</param>
        public static void RemoveTimer(FunctionPeriodic funcTimer)
        {
            InitIfNeeded();
            _funcList.Remove(funcTimer);
        }

        /// <summary>
        /// Stop a function periodic objects in the runtime
        /// </summary>
        /// <param name="_name">Function periodic to stop</param>
        public static void StopTimer(string _name)
        {
            InitIfNeeded();
            for (int i = 0; i < _funcList.Count; i++)
            {
                if (_funcList[i]._functionName == _name)
                {
                    _funcList[i].DestroySelf();
                    return;
                }
            }
        }

        /// <summary>
        /// Stop all the function periodic objects with the same name in the runtime
        /// </summary>
        /// <param name="_name">Function periodic name to stop</param>
        public static void StopAllFunc(string _name)
        {
            InitIfNeeded();
            for (int i = 0; i < _funcList.Count; i++)
            {
                if (_funcList[i]._functionName == _name)
                {
                    _funcList[i].DestroySelf();
                    i--;
                }
            }
        }

        /// <summary>
        /// Gets the status of a function periodic object
        /// </summary>
        /// <param name="name">Name of the function periodic</param>
        /// <returns><c>true</c> if the function is active</returns>
        public static bool IsFuncActive(string name)
        {
            InitIfNeeded();
            for (int i = 0; i < _funcList.Count; i++)
            {
                if (_funcList[i]._functionName == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Set a new timer for the function periodic
        /// </summary>
        /// <param name="timer">Time to trigger</param>
        public void SkipTimerTo(float timer)
        {
            this._timer = timer;
        }

        /// <summary>
        /// Remove function periodic and destroy the gameobject
        /// </summary>
        public void DestroySelf()
        {
            RemoveTimer(this);
            if (_gameObject != null)
            {
                UnityEngine.Object.Destroy(_gameObject);
            }
        }

        private GameObject _gameObject;
        private float _timer;
        private float _baseTimer;
        private bool _useUnscaledDeltaTime;
        private string _functionName;
        public Action _action;
        public Func<bool> _testDestroy;

        private FunctionPeriodic(GameObject gameObject, Action action, float timer, Func<bool> testDestroy, string functionName, bool useUnscaledDeltaTime)
        {
            this._gameObject = gameObject;
            this._action = action;
            this._timer = timer;
            this._testDestroy = testDestroy;
            this._functionName = functionName;
            this._useUnscaledDeltaTime = useUnscaledDeltaTime;
            _baseTimer = timer;
        }

        private void Update()
        {
            if (_useUnscaledDeltaTime)
                _timer -= Time.unscaledDeltaTime;
            else
                _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _action();
                if (_testDestroy != null && _testDestroy())
                    DestroySelf(); //Destroy
                else 
                    _timer += _baseTimer; //Repeat
            }
        }
    }
}