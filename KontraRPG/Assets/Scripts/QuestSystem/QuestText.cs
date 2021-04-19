using Interfaces;

namespace QuestSystem
{
    public class QuestText : IQuestText
    {
        private string _title;
        private string _description;
        private string _hint;
        private string _dialog;

        public string Title
        {
            get => _title;
        }

        public string Description
        {
            get => _description;
        }

        public string Hint
        {
            get => _hint;
        }

        public string Dialog
        {
            get => _dialog;
        }
    }
}