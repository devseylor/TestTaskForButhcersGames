using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DrawAndRun
{
    public class LevelManager : MonoBehaviour
    {
        public int currentLevel { get; private set; }
        public float levelSpeed { get; private set; }
        [SerializeField] private float _defaultSpeed = 1f;
        private TrackMove track;
        private void Awake()
        {
            GameManager.instance.eventsManager.GameStart.AddListener(OnGameStart);
            GameManager.instance.eventsManager.LevelEnd.AddListener(LevelFinish);
        }
        private void OnGameStart()
        {
            GameManager.instance.eventsManager.GameStart.RemoveListener(OnGameStart);
            currentLevel = 1;
            InitNewLevel(currentLevel);
        }
        private void StartLevel()
        {
            GameManager.instance.eventsManager.mouseUp.RemoveListener(StartLevel);

            Time.timeScale = 1;
            levelSpeed = _defaultSpeed;
            track = FindObjectOfType<TrackMove>();
            track.Init(levelSpeed);
            GameManager.instance.eventsManager.LevelStart.Invoke();

        }
        public void RestartLevel()
        {
            GameManager.instance.playerData.ResetScore();
            InitNewLevel(currentLevel);
        }

        private void InitNewLevel(int level)
        {
            // level change logic
            GameManager.instance.eventsManager.LevelInit.Invoke();
            StartCoroutine(LevelInit());
        }
        private IEnumerator LevelInit()
        {
            yield return null;
            GameManager.instance.eventsManager.mouseUp.AddListener(StartLevel);
            yield return null;
        }
        private void LevelFinish()
        {
            Debug.Log("Level " + currentLevel + " finished");
        }
    }
}
