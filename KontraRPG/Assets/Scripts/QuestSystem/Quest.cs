using Interfaces;

namespace QuestSystem
{
    public abstract class Quest
    {
        private IQuestObjective _questObjective;

        protected IQuestObjective QuestObjective
        {
            get => _questObjective;
            set => _questObjective = value;
        }

        public string Title => _questObjective.Title;
        public string Description => _questObjective.Description;
        public string Progress => _questObjective.ToString();

        public void UpdateProgress()
        {
            _questObjective.UpdateProgress();
        }

        public bool IsCompleted()
        {
            _questObjective.CheckProgress();
            
            return _questObjective.IsCompleted;
        }

        public abstract void GiveQuestReward();
    }
}