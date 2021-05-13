using System.Collections.Generic;
using QuestSystem;
using QuestSystem.Quests;
using TMPro;
using UnityEngine;
using static Inventory.Inventory;

public class QuestManager : MonoBehaviour
{
    private TextMeshProUGUI _title;
    private TextMeshProUGUI _progress;
    private int _currentID = 0;
    
    public static QuestManager Instance { get; private set; }
    private readonly List<Quest> _quests = new List<Quest>();
        
    private void Awake()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                GameObject.Destroy(gameObject);
            }
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        _title = GameObject.FindGameObjectWithTag("QuestTitle").GetComponent<TextMeshProUGUI>();
        _progress = GameObject.FindGameObjectWithTag("QuestProgress").GetComponent<TextMeshProUGUI>();

        _quests.Add(new GatherWitchBrooms());

        _title.SetText(_quests[_currentID].Title);
        _progress.SetText(_quests[_currentID].Progress);
    }

    private void Update()
    {
        if (_quests.Count <= 0) return;
        if (Input.GetKeyDown(KeyCode.G))
        {
            _quests[_currentID].UpdateProgress();
            if (_quests[_currentID].IsCompleted())
            {
                _quests[_currentID].GiveQuestReward();
                _currentID++;
            };
            _progress.SetText(_quests[_currentID].Progress);
        }
    }
}