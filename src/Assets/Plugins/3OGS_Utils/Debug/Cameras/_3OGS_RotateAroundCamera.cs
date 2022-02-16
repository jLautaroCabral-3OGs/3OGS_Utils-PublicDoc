using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _3OGS.Debug.Cameras
{
    /// <summary>
    /// A camera that follows a target and can rotate around it, always looking at it. 
    /// </summary>
    /// <remarks>
    /// To rotate the camera you use the middle mouse button.
    /// Use the wheel to zoom.
    /// You can hold right click to show the cursor so you can left click freely, to press DebugButtons, for example.
    /// </remarks>
    public class _3OGS_RotateAroundCamera : MonoBehaviour
    {
        private _3OGS_RotateAroundCamera() { }

        [Header("Camera settings")]
        [SerializeField]
        private Transform _target;
        private float _scrollSpeed = 65f;

        [Header("Angle settings")]
        [SerializeField]
        [Range(45, 80)]
        private float _cameraXRotationMaxAnle = 80;

        [SerializeField]
        [Range(-80, 35)]
        private float _cameraXRotationminAnle = 35;

        [Header("Zoomb settings")]
        [SerializeField]
        private float _minZoomLimit = 8f;
        [SerializeField]
        private float _maxZoomLimit = 25f;

        private Camera _cam;

        private Vector3 _previousPosition;

        private Transform _thisT;

        private bool _allowZoomIn, _allowZoomOut, _allowRotateUp = true, _allowRotateDown = true;

        private float _currentZoomValue;

        private Vector3 _lastCameraOffset;

        private static readonly string _cameraGameObjName = "_3OGS_Debug RotateAroundCamera";

        private void Awake()
        {
            _cam = GetComponent<Camera>();
            _thisT = this.transform;
        }

        private void Start()
        {
            Vector3 supp = _target.position - _thisT.position;
            _currentZoomValue = supp.magnitude;
        }

        private void Update()
        {
            HandleCameraPosition();
            HandleZoom();
        }

        private void HandleCameraPosition()
        {
            if (Input.GetMouseButtonDown(2))
            {
                _previousPosition = _cam.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(2))
            {
                Vector3 direction = _previousPosition - _cam.ScreenToViewportPoint(Input.mousePosition);

                _thisT.position = _target.position;

                float xRotation = this.transform.rotation.eulerAngles.x;
                xRotation = xRotation > 270f ? xRotation - 360 : xRotation;

                _allowRotateDown = xRotation < _cameraXRotationminAnle ? false : true;
                _allowRotateUp = xRotation > _cameraXRotationMaxAnle ? false : true;

                if (direction.y > 0f && _allowRotateUp)
                    _thisT.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                else if (direction.y < 0f && _allowRotateDown)
                    _thisT.Rotate(new Vector3(1, 0, 0), direction.y * 180);

                _thisT.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);

                _previousPosition = _cam.ScreenToViewportPoint(Input.mousePosition);

                _lastCameraOffset = _target.position - this.transform.position;
            }
            else if (_lastCameraOffset != null)
            {
                this.transform.position = _target.position/* - lastCameraOffset*/;
            }

            _thisT.Translate(new Vector3(0, 0, -Mathf.Abs(_currentZoomValue)));
        }

        private void HandleZoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll != 0)
            {
                float zoomDistance = Vector3.Distance(_thisT.position, _target.position);

                _allowZoomOut = zoomDistance > _maxZoomLimit ? false : true;
                _allowZoomIn = zoomDistance < _minZoomLimit ? false : true;

                if (scroll > 0 && _allowZoomIn)
                    _thisT.Translate(new Vector3(0, 0, _scrollSpeed * Time.deltaTime));
                else if (scroll < 0 && _allowZoomOut)
                    _thisT.Translate(new Vector3(0, 0, -_scrollSpeed * Time.deltaTime));

                Vector3 supp = _target.position - _thisT.position;
                _currentZoomValue = supp.magnitude;
            }
        }

        /// <summary>
        ///  Create a RotateArounTarget camera on the <paramref name="target"/>
        /// </summary>
        /// <param name="target">Target to follow and position to spawn the camera</param>
        /// <returns>The Camera component of the RotateAroundTarget gameobject</returns>
        public static Camera CreateRotateAroundToTargetCamera(Transform target)
        {
            GameObject cameraInstance = GameObject.Find(_cameraGameObjName);
            Camera cam;
            if (cameraInstance == null)
            {
                cameraInstance = new GameObject(_cameraGameObjName);
                cam = cameraInstance.AddComponent<Camera>();
                cameraInstance.AddComponent<AudioListener>();
                _3OGS_RotateAroundCamera rotCamera = cameraInstance.AddComponent<_3OGS_RotateAroundCamera>();
                rotCamera._target = target;
            }
            else
            {
                cam = cameraInstance.GetComponent<Camera>();
                _3OGS_RotateAroundCamera rotCamera = cameraInstance.AddComponent<_3OGS_RotateAroundCamera>();
                rotCamera._target = target;
            }

            return cam;
        }
    }
}

