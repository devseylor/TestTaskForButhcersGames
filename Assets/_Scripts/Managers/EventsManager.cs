using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace DrawAndRun
{
    public class EventsManager : MonoBehaviour
    {
        public UnityEvent GameStart;

        public UnityEvent LevelInit;
        public UnityEvent LevelStart;
        public UnityEvent LevelEnd;

        public UnityEvent GameOver;

        public UnityEvent mouseDown;
        public UnityEvent mouseUp;
    }
}