using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{
    public class SawObstacle : MonoBehaviour
    {
        public float rotationSpeed = 20f;
        public bool doRotate = true;
        public char rotationAxis = 'z';
        void Start()
        {
            StarRotating();
        }
        public void StarRotating()
        {
            doRotate = true;
            StartCoroutine(Rotate());
        }
        public void StopRotating()
        {
            doRotate = false;
        }
        private IEnumerator Rotate()
        {
            while (doRotate)
            {
                Vector3 rotDir = new Vector3();
                switch (rotationAxis)
                {
                    case 'z':
                        rotDir = new Vector3(0,0,rotationSpeed);
                        break;
                    case 'y':
                        rotDir = new Vector3(0, rotationSpeed, 0);
                        break;
                    case 'x':
                        rotDir = new Vector3(rotationSpeed, 0, 0);
                        break;
                }
                transform.eulerAngles += rotDir;
                yield return null;
            }
        }
    }
}