using System.Collections.Generic;
using QuestSystem;
using QuestSystem.Quests;
using TMPro;
using UnityEngine;
using static Inventory.Inventory;

public class QuestManager : MonoBehaviour
{
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
        _quests.Add(new GatherWitchBrooms());
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
        }
    }
}