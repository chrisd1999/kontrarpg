using System;
using System.Collections.Generic;
using Interfaces;
using QuestSystem.Quests;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private readonly List<IQuest> _quests = new List<IQuest>();

    private void Start()
    {
        _quests.Add(new GatherWitchBrooms());
    }

    private void Update()
    {
        foreach (var quest in _quests)
        {
            Debug.Log(quest.QuestObjective.Description);
        }
    }
    
}
