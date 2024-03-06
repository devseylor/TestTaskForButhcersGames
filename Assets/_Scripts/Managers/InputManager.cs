using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{
    public class InputManager : MonoBehaviour
    {
        private void Awake()
        {
            Input.simulateMouseWithTouches = true;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.eventsManager.mouseDown.Invoke();
            }
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.instance.eventsManager.mouseUp.Invoke();
            }
        }

        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }

    }
}
