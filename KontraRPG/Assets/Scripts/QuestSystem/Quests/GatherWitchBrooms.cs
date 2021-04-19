using Interfaces;
using QuestSystem.Objectives;
using UnityEngine;

namespace QuestSystem.Quests
{
    public class GatherWitchBrooms : Quest
    {
        private GameObject item;

        public GatherWitchBrooms()
        {
            QuestObjective = new CollectionObjective("Collect 10 Witch brooms",
                "You need to go to the witch houses, and gather their brooms.", 10, item);
        }
    }
}