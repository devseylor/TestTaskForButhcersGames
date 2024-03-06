using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{

    public class CloneAnimationManager : MonoBehaviour
    {
        private const string indle = "Idle";
        private const string run = "Running";
        private const string happyWalk = "happyWalk";
        private const string sadWalk = "SadWalk";
        private const string victory = "Victory Idle";

        [SerializeField] private List<string> danceStates;
        [SerializeField] private Animator _animator;
        void Awake()
        {
            if (_animator == null) _animator = GetComponentInChildren<Animator>();
        }


        public void OnCreate()
        {
            _animator.Play(indle);
        }
        public void OnStartMoving()
        {
            _animator.Play(run);

        }
        public void OnLevelEnd()
        {
            _animator.gameObject.SetActive(true);
            if (danceStates.Count == 0)
                _animator.Play(victory);
            else
            {
                int rand = Random.Range(0, danceStates.Count);
                _animator.Play(danceStates[rand]);
            }
        }
        public void OnDeath()
        {
            _animator.Play(sadWalk);  
        }
    }
}