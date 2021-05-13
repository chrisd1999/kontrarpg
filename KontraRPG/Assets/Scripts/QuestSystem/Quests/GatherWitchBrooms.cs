using Inventory.Items;
using QuestSystem.Objectives;
using UnityEngine;
using static Inventory.Inventory;

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

        public override void GiveQuestReward()
        {
            Instance.AddItemToInventory(new WitchBroom());
            Instance.AddItemToInventory(new WitchHat());

        }
    }
}