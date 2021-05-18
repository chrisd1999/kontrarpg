using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questTitle;
        [SerializeField] private TextMeshProUGUI questProgress;

        private QuestManager _questManager;

        private void Start()
        {
            _questManager = QuestManager.Instance;

            _questManager.OnProgressChangedCallback += UpdateUI;
        }

        private void UpdateUI()
        {
            Debug.Log("Hello");
            questTitle.SetText(_questManager.GetCurrentQuestTitle());
            questProgress.SetText(_questManager.GetCurrentQuestProgress());
        }
    }
}
