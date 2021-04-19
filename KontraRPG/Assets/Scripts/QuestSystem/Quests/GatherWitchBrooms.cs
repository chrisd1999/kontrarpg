using Interfaces;
using QuestSystem.Objectives;
using UnityEngine;

namespace QuestSystem.Quests
{
    public class GatherWitchBrooms : IQuest
    {
        private IQuestObjective _questObjective;
        private GameObject item;

        public GatherWitchBrooms()
        {
            _questObjective = new CollectionObjective("Collect 10 Witch brooms",
                "You need to go to the witch houses, and gather their brooms.", 10, item);
        }


        public IQuestObjective QuestObjective
        {
            get => _questObjective;
        }

        public bool IsCompleted
        {
            get => QuestObjective.IsCompleted;
        }
    }
}