namespace Interfaces
{
    public interface IQuest
    {
        IQuestObjective QuestObjective { get; }
        bool IsCompleted { get; }
    }
}