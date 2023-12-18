using System.IO;
using UnityEngine;
using RPG.Components.Commons;

namespace RPG.Components
{
    interface IQuest
    {
        void AcceptQuest();
        void CompleteQuest();
        bool IsQuestComplete();
        bool HasQuest();
    }

    public class QuestComponent : IQuest
    {
        private const string QUEST_PATH = "Assets/Resources/Quests/Quests.json";
        private QuestStructure _questStructure;

        public QuestComponent()
        {
            Initialize();
        }

        private void Initialize()
        {
            StreamReader buffer = File.OpenText(QUEST_PATH);

            _questStructure = JsonUtility.FromJson<QuestStructure>(buffer.ReadToEnd());

            foreach (SchemaQuest quest in _questStructure.Quests)
            {
                Debug.Log(quest.Name);
            }
        }

        public void AcceptQuest()
        {
            throw new System.NotImplementedException();
        }

        public void CompleteQuest()
        {
            throw new System.NotImplementedException();
        }

        public bool HasQuest()
        {
            throw new System.NotImplementedException();
        }

        public bool IsQuestComplete()
        {
            throw new System.NotImplementedException();
        }
    }
}