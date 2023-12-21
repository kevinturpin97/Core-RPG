using System.IO;
using UnityEngine;
using RPG.Components.Commons;
using System.Collections.Generic;

namespace RPG.Components
{
    interface IQuest
    {
        void AcceptQuest();
        void CompleteQuest();
        bool IsQuestComplete();
        bool HasQuest();
        bool UpdateStatus(SchemaQuest quest);
        List<SchemaQuest> GetQuests();
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
        }

        public List<SchemaQuest> GetQuests()
        {
            return _questStructure.Quests;
        }

        public SchemaQuest FindQuest(string NPC)
        {
            foreach (SchemaQuest quest in _questStructure.Quests)
            {
                if (quest.Owner == NPC && quest.Status != Status.Completed)
                {
                    return quest;
                }
            }

            return null;
        }

        public bool UpdateStatus(SchemaQuest quest)
        {
            for (int i = 0; i < _questStructure.Quests.Count; i++)
            {
                if (_questStructure.Quests[i].Name == quest.Name)
                {
                    _questStructure.Quests[i] = quest;

                    return true;
                }
            }

            return false;
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