using UnityEngine;

namespace Interfaces
{
    public interface IQuestObjective
    {
        string Title { get; }
        string Description { get; }
        int CurrentAmount { get; }
        int QuestAmount { get; }
        bool IsCompleted { get; }
        void UpdateProgress(int id);
        void CheckProgress();
        string ToString();
    }
}