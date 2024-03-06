using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T Instance;
        public static T instance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = GameObject.FindObjectOfType<T>();
                }
                return Instance;
            }
            private set { Instance = value; }
        }
    }

    public class GameManager : Singleton<GameManager>
    {
        public LevelManager levelManager;
        public SoundManager soundManager;
        public PlayerData playerData;
        public DrawingManager drawingManager;
        public ClonesSpawner clonesSpawner;
        public UIController UIController;
        public EventsManager eventsManager;
        public InputManager inputManager;

        private void Start()
        {
            instance.eventsManager.GameStart.Invoke();
        }
    }
}
