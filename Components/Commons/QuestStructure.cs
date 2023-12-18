using System.Collections.Generic;
using System;

namespace RPG.Components.Commons
{
    [Serializable]
    public class SchemaQuest
    {
        #region Child Class Definition

        enum Status
        {
            Inactive,
            Active,
            Complete
        }

        enum RewardType
        {
            XP,
            Gold,
            Item
        }

        public enum TaskAction
        {
            Kill, // entity id
            Collect, // item id
            Talk, // npc id
            Move // destination id
        }

        public enum RequiredAction
        {
            Kill,
            Collect,
            Talk,
        }

        public enum ChoiceAction
        {
            Accept,
            Decline,
            Complete,
            Continue
        }

        // When reward is given, the task is complete
        public class Reward
        {
            public int ID;
            public RewardType Type;
            public int Value;
        }

        // If the dialogue come from Quest, every action can be invoked
        // If the dialogue come from Task or Requirement, only Continue can be invoked
        public class Choice
        {
            public int ID;
            public string Text;
            public ChoiceAction Action;
        }

        public class Dialogue
        {
            public int ID;
            public string Name;
            public string Text;
            public bool isPlayer; // if true, the dialogue is from the player, otherwise is from the npc
            public List<Choice> Choices;

            public Dialogue()
            {
                Choices = new List<Choice>();
            }
        }

        public class Requirement
        {
            public int ID;
            public string Name;
            public string Description;
            public Status Status;
            public RequiredAction RequiredAction;
            public int TargetID;
            public int Quantity;
            public Dialogue Dialogue;
        }

        public class Task
        {
            public int ID;
            public string Name;
            public string Description;
            public Status Status;
            public TaskAction Action;
            public int TargetID;
            public int Quantity;
            public Dictionary<Status, Dialogue> Dialogues;
            public List<Reward> Rewards;

            public Task()
            {
                // one dialogue for each status
                Dialogues = new Dictionary<Status, Dialogue>();
                Rewards = new List<Reward>();
            }
        }

        #endregion

        public int ID;
        public string Name;
        public string Resume;
        public string Owner;
        public Status Status;
        public List<Requirement> Requirements;
        public List<Dialogue> Dialogues;
        public List<Task> Tasks;

        public SchemaQuest()
        {
            // no need to convert to dictionary<status, dialogue>
            // because its the main quest dialogue
            // once the quest is started, tasks' dialogues will take care of it
            Dialogues = new List<Dialogue>();
            Requirements = new List<Requirement>();
            Tasks = new List<Task>();
        }
    }

    [Serializable]
    public class QuestStructure
    {
        public List<SchemaQuest> Quests;

        public QuestStructure()
        {
            Quests = new List<SchemaQuest>();
        }
    }
}