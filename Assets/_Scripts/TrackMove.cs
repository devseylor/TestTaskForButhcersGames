using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DrawAndRun {
    public class TrackMove : MonoBehaviour
    {
        [SerializeField] private bool _doMove;
        private float _velocity;
        [SerializeField] private Vector3 _startPosition = new Vector3();
        private void Awake()
        {
            SubEvents();
        }
        private void SubEvents()
        {
            GameManager.instance.eventsManager.GameOver.AddListener(StopMoving);
            GameManager.instance.eventsManager.LevelEnd.AddListener(StopMoving);
        }
        public void Init(float speed, bool start = true)
        {
            _velocity = speed;
            _doMove = start;
            transform.position = _startPosition;
            if (start)
            {
                StartMoving();
            }
        }
        private void StartMoving()
        {
            _doMove = true;
            StartCoroutine(MovementHandler());
        }
        private void StopMoving()
        {
            _doMove = false;
        }
        private IEnumerator MovementHandler()
        {
            Time.timeScale = 1f;
            while (_doMove)
            {
                transform.localPosition += new Vector3(0, 0, -_velocity)*Time.deltaTime;
                yield return null;
            }
        }
    }
}