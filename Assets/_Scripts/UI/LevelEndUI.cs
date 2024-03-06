using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{
    public class LevelEndUI : MonoBehaviour
    {
        [SerializeField] private GameObject _inputTouchUI;

        public void Init()
        {
            _inputTouchUI.SetActive(false);
        }
        public void Show()
        {
        }

        public void Hide()
        {
        }
    }
}