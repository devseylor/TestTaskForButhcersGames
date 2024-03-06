using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DrawAndRun
{
    public class UIController : MonoBehaviour
    {
        public InGameUI inGame;
        public LevelStartUI levelInit;
        public LevelEndUI levelEnd;
        public GameOverUI gameOver;
        private void Awake()
        {
            SubEvents();
        }
        private void SubEvents()
        {
            GameManager.instance.eventsManager.LevelInit.AddListener(OnLevelInit);
            GameManager.instance.eventsManager.LevelStart.AddListener(OnLevelStart);
            GameManager.instance.eventsManager.LevelEnd.AddListener(OnLevelEnd);
            GameManager.instance.eventsManager.GameOver.AddListener(OnGameOver);
        }
        private void OnLevelInit()
        {
            inGame.Hide();
            levelInit.Init();
            levelEnd.Hide();
            gameOver.Init();
            gameOver.Hide();
        }
        private void OnLevelStart()
        {
            levelInit.Hide();
            inGame.Init();
        }
        private void OnLevelEnd()
        {
            levelEnd.Init();
            levelEnd.Show();
            inGame.Hide();
        }
        private void OnGameOver()
        {
            levelEnd.Hide();
            levelInit.Hide();
            gameOver.Show();
        }
    }
}