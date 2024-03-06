using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace DrawAndRun
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject inGameUI;
        [SerializeField] private TextMeshProUGUI scoreText;
        void Start()
        {

        }

        public void Init()
        {
            inGameUI.SetActive(true);
            scoreText.gameObject.SetActive(true);
        }
        public void ShowScore(int num)
        {
            scoreText.text = num.ToString();
        }
        public void Hide()
        {
            inGameUI.SetActive(false);
        }
    }
}