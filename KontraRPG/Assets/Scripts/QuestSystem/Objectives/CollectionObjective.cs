using Interfaces;
using UnityEngine;

namespace QuestSystem.Objectives
{
    public class CollectionObjective : IQuestObjective
    {
        private string _title;
        private string _description;
        private bool _isCompleted;
        private int _questAmount;
        private int _currentAmount;
        private GameObject _itemToCollect;

        public CollectionObjective(string title, string description, int amount, GameObject item)
        {
            _title = title;
            _description = description;
            _isCompleted = false;
            _questAmount = amount;
            _currentAmount = 0;
            _itemToCollect = item;
        }

        public string Title
        {
            get => _title;
        }

        public string Description
        {
            get => _description;
        }

        public int QuestAmount
        {
            get => _questAmount;
        }

        public bool IsCompleted
        {
            get => _isCompleted;
        }


        public int CurrentAmount
        {
            get => _currentAmount;
        }

        public GameObject ItemToCollect
        {
            get => _itemToCollect;
        }

        public void UpdateProgress()
        {
            throw new System.NotImplementedException();
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
            return $"You have gathered {_currentAmount} out of {_questAmount} {_itemToCollect.name}";
        }
    }
}