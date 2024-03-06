using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace DrawAndRun
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private bool _doFollow;
        [SerializeField] private Vector3 _defaultRot = new Vector3();
        [SerializeField] private Vector3 _defaultPosOffset = new Vector3();


        void Start()
        {
            if (_followTarget == null) _doFollow = false;

        }

        public void Init(Transform target, bool start = true)
        {
            _followTarget = target;
            if (start)
                StartFollowing();
        }
        public void StartFollowing()
        {
            _doFollow = true;
            StartCoroutine(Follow());
        }
        public void StopFollowing()
        {
            _doFollow = false;
        }
        private IEnumerator Follow()
        {
            while (_doFollow)
            {
                transform.position = _followTarget.position + _defaultPosOffset;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, _followTarget.eulerAngles.y, transform.eulerAngles.z);
                yield return null;
            }
        }

    }
}