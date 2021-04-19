using Interfaces;

namespace QuestSystem
{
    public class QuestIdentifier : IQuestIdentifier
    {
        private int _questID;
        private int _sourceID;

        public int QuestID
        {
            get => _questID;
        }
        
        public int SourceID
        {
            get => _sourceID;
        }

    }
}