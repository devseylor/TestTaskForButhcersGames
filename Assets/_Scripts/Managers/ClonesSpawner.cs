using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DrawAndRun
{

    public class ClonesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _clonePlace;
        [SerializeField] private List<SingleClone> _clones = new List<SingleClone>();
        [SerializeField] private GameObject _clonePF;
        private bool _levelStarted = false;
        public int currentClonesCount { get { return _clones.Count; } }
        private void Awake()
        {
            _clones = new List<SingleClone>();
            SubEvents();
        }

        private void SubEvents()
        {
            GameManager.instance.eventsManager.LevelInit.AddListener(OnLevelInit);
            GameManager.instance.eventsManager.LevelEnd.AddListener(OnLevelEnd);
            GameManager.instance.eventsManager.GameOver.AddListener(OnGameOver);
        }

        public void AddToCrue(SingleClone unit)
        {
            //unit.gameObject.layer = 6;
            //unit.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            _clones.Add(unit);
            unit.gameObject.transform.parent = _clonePlace;
            
        }
        public void DeleteFromCrue(SingleClone unit)
        {
            _clones.Remove(unit);
            if (_clones.Count == 0)
                GameManager.instance.eventsManager.GameOver.Invoke();
        }

        private void OnLevelEnd()
        {
            _clones.Clear();
            _levelStarted = false;
        }
        private void OnGameOver()
        {
            _clones.Clear();
            _levelStarted = false;
        }
        private void OnLevelInit()
        {
            _levelStarted = false;
            for (int i = 0; i < GameData.instance.clonesStartNum; i++)
            {
               GameObject unit = Instantiate(_clonePF);
               SingleClone clone = unit.GetComponent<SingleClone>();
               AddToCrue(clone);
                
            }
            ReArrangeClones( ClonesAlignment.instance.GetDefaultAlignment(_clones.Count),true);
        }

        public void ReArrangeClones(List<Vector3> newPositions, bool isLocal = false)
        {
            if(_clones.Count != newPositions.Count)
            {
                Debug.LogWarning("wrong positions list");
                return;
            }
            for(int i=0; i < newPositions.Count; i++)
            {
                if(isLocal)
                    _clones[i].transform.localPosition = newPositions[i];
                else
                    _clones[i].transform.position = newPositions[i];
            }
        }
    }
}