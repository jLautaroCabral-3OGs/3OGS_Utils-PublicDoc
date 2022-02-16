using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _3OGS.Debug.Cameras
{
    /// <summary>
    /// The free view camera is used to travel the world without restrictions.
    /// </summary>
    /// <remarks>
    /// You can control the camera with WASD.
    /// Use Q and E to move up or down using the local position vector.
    /// You can hold right click to show the cursor so you can left click freely, to press DebugButtons, for example.
    /// </remarks>
    public class _3OGS_FreeLookCamera : MonoBehaviour
    {
        private _3OGS_FreeLookCamera() { }

        [Header("Camera Config")]
        [SerializeField]
        private float _cameraSpeed = 10;

        [Header("Look Sensibility")]
        private float _lookSensibilityX = 10;
        private float _lookSensibilityY = 10;

        [Header("Clamping")]
        private float _minY = -90;
        private float _maxY = 90;

        private float _rotX;
        private float _rotY;

        private bool _isSpectator = true;
        private static readonly string _cameraGameObjName = "_3OGS_Debug FreeLookCamera";

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Update()
        {
            if(LockMode())
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        private void LateUpdate()
        {
            if(!LockMode())
            {
                _rotX += Input.GetAxis("Mouse X") * _lookSensibilityX;
                _rotY += Input.GetAxis("Mouse Y") * _lookSensibilityY;

                _rotY = Mathf.Clamp(_rotY, _minY, _maxY);

                if (_isSpectator)
                {
                    transform.rotation = Quaternion.Euler(-_rotY, _rotX, 0);
                    float x = Input.GetAxis("Horizontal");
                    float z = Input.GetAxis("Vertical");
                    float y = 0;

                    if (Input.GetKey(KeyCode.E))
                    {
                        y = 1;
                    }
                    else if (Input.GetKey(KeyCode.Q))
                    {
                        y = -1;
                    }

                    Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
                    transform.position += dir * _cameraSpeed * Time.deltaTime;
                }
            }
        }

        private bool LockMode()
        {
            return Input.GetMouseButton(1);
        }

        /// <summary>
        ///  Create a FreeLookCamera on the <paramref name="position"/>
        /// </summary>
        /// <param name="position">Position to spawn the camera</param>
        /// <returns>The Camera component of the FreeLookCamera gameobject</returns>
        public static Camera CreateFreeLookCamera(Vector3 position)
        {
            GameObject cameraInstance = GameObject.Find(_cameraGameObjName);
            Camera cam;
            if (cameraInstance == null)
            {
                cameraInstance = new GameObject(_cameraGameObjName);
                cam = cameraInstance.AddComponent<Camera>();
                cameraInstance.AddComponent<_3OGS_FreeLookCamera>();
                cameraInstance.transform.position = position;
                cameraInstance.AddComponent<AudioListener>();
            }
            else
            {
                cam = cameraInstance.GetComponent<Camera>();
                cameraInstance.transform.position = position;
            }
            return cam;
        }
    }
}