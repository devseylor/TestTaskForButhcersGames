using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun
{
    public class SingleClone : MonoBehaviour
    {
        [SerializeField] private CloneCollisionManager collisionManager;
        [SerializeField] private CloneAnimationManager animationManager;
        private void Start()
        {
            if (collisionManager == null)
                collisionManager = GetComponent<CloneCollisionManager>();
            if (animationManager == null)
                animationManager = GetComponent<CloneAnimationManager>();

            collisionManager.Init(this);
            animationManager.OnCreate();
            GameManager.instance.eventsManager.LevelEnd.AddListener(OnLevelEnd);
            GameManager.instance.eventsManager.LevelStart.AddListener(animationManager.OnStartMoving);
        }
        private void OnLevelEnd()
        {
            animationManager.OnLevelEnd();
        }
        public IEnumerator Die()
        {
            transform.parent = null;
            animationManager.OnDeath();
            GameManager.instance.clonesSpawner.DeleteFromCrue(this);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
            
        }

    }
}
