
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

namespace DrawAndRun
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Button _restart;
        [SerializeField] private TextMeshProUGUI _finalScore;
        public void Init( )
        {
            _restart.onClick.AddListener(() => { GameManager.instance.levelManager.RestartLevel(); });
        }
        public void Show()
        {
            _gameOverUI.SetActive(true);
            _finalScore.text = "Final Score: " + GameManager.instance.playerData.score;
        }
        public void Hide()
        {
            _gameOverUI.SetActive(false);
        }
    }
}
