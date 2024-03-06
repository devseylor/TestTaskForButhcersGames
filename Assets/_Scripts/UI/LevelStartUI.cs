
using UnityEngine;

namespace DrawAndRun
{
    public class LevelStartUI : MonoBehaviour
    {
        [SerializeField] private GameObject levelStartUI;

        public void Init()
        {
            levelStartUI.SetActive(true);
        }
        public void Hide()
        {
            levelStartUI.SetActive(false);
        }
    }
}