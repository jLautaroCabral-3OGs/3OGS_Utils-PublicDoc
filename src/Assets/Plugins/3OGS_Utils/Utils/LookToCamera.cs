/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using System.Collections;
using UnityEngine;

namespace _3OGS.Utils
{

    public class LookToCamera : MonoBehaviour
    {
        private Camera _target;
        private bool _rotateY;

        private void Start()
        {
            StartCoroutine("Rotate");
        }

        private IEnumerator Rotate()
        {
            
            Quaternion rotation;
            while (true)
            {
                _target = CameraSwitcher.CurrentCamera;

                if(_target != null)
                {
                    Vector3 direction = _target.transform.position - transform.position;
                    if (_rotateY)
                        rotation = Quaternion.LookRotation(-direction);
                    else
                        rotation = Quaternion.LookRotation(new Vector3(-direction.x, transform.rotation.y, -direction.z));

                    transform.rotation = rotation;
                }

                yield return new WaitForSeconds(0.01f);
            }
        }

        /// <summary>
        /// If <c>true</c> the camera will rotate with the Y axis too
        /// </summary>
        /// <param name="rotateY"></param>
        public void SetRotateY(bool rotateY)
        {
            _rotateY = rotateY;
        }
    }
}