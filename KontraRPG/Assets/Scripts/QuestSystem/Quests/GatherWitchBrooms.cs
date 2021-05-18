using Inventory.Items;
using QuestSystem.Objectives;
using UnityEngine;
using static Inventory.Inventory;

namespace QuestSystem.Quests
{
    public class GatherWitchBrooms : Quest
    {
        // private GameObject item;
        public GatherWitchBrooms()
        {
            // QuestObjective = new CollectionObjective("Collect 10 Witch brooms",
            //     "You need to go to the witch houses, and gather their brooms.", 10, item);

            QuestObjective = new KillObjective("Kill 10 Witch and gather brooms, to get a key", 1,
                "You need to go to the witch houses, and gather their brooms to get a key.", 10);
        }

        public override void GiveQuestReward()
        {
            Instance.AddItemToInventory(new WitchBroom());
            Instance.AddItemToInventory(new WitchKey());
        }
        
    }
}