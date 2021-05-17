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
    public delegate void OnProgressChanged();
    public OnProgressChanged OnProgressChangedCallback;
        
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
        
        OnProgressChangedCallback?.Invoke();
    }

    private void Update()
    {
        if (_quests.Count <= 0) return;
        
        if (_quests[_currentID].IsCompleted())
        {
            _quests[_currentID].GiveQuestReward();
            _currentID++;
        };
    }

    public string GetCurrentQuestTitle()
    {
        return _quests[_currentID].Title;
    }

    public string GetCurrentQuestProgress()
    {
        return _quests[_currentID].Progress;
    }

    public void UpdateQuestProgress(int id = 0)
    {
        _quests[_currentID].UpdateProgress(id);
        OnProgressChangedCallback?.Invoke();
    }
}