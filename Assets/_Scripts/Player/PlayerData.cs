using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DrawAndRun
{
    public class PlayerData : MonoBehaviour
    {
        public int score { get; private set; }
        [SerializeField] private int _curentLevel;
        public void AddScore(int num)
        {
            score += num;
            GameManager.instance.UIController.inGame.ShowScore(score);
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}