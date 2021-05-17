using Interfaces;

namespace QuestSystem.Objectives
{
    public class KillObjective : IQuestObjective
    {
        private string _title;
        private string _description;
        private bool _isCompleted;
        private int _enemyID;
        private int _currentAmount;
        private int _questAmount;

        public KillObjective(string title, int enemyID, string description, int questAmount)
        {
            _title = title;
            _description = description;
            _enemyID = enemyID;
            _isCompleted = false;
            _currentAmount = 0;
            _questAmount = questAmount;
        }

        public string Title
        {
            get => _title;
        }

        public string Description
        {
            get => _description;
        }

        public int CurrentAmount
        {
            get => _currentAmount;
        }

        public int QuestAmount
        {
            get => _questAmount;
        }

        public bool IsCompleted
        {
            get => _isCompleted;
        }

        public void UpdateProgress(int enemyID)
        {
            if (_enemyID == enemyID)
            {
                _currentAmount++;
            }
        }

        public void CheckProgress()
        {
            if (_currentAmount >= _questAmount)
            {
                _isCompleted = true;
                return;
            }

            _isCompleted = false;
        }

        public override string ToString()
        {
            return $"You have killed {_currentAmount} out of {_questAmount} witches.";
        }
    }
}