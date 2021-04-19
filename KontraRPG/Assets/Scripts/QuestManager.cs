using System;
using System.Collections.Generic;
using Interfaces;
using QuestSystem.Quests;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private TextMeshProUGUI _title;
    private TextMeshProUGUI _progress;
    
    private readonly List<IQuest> _quests = new List<IQuest>();
    private void Start()
    {
        _title = GameObject.FindGameObjectWithTag("QuestTitle").GetComponent<TextMeshProUGUI>();
        _progress = GameObject.FindGameObjectWithTag("QuestProgress").GetComponent<TextMeshProUGUI>();

        _quests.Add(new GatherWitchBrooms());
        
        _title.SetText(_quests[0].QuestObjective.Title);
        _progress.SetText(_quests[0].QuestObjective.ToString());

    }

}
