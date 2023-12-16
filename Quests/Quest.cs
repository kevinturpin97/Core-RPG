using UnityEngine;
using RPG.Controllers;

namespace RPG.Quests
{
    public class Quest
    {
        private GameObject _quest;

        public Quest()
        {
            Instantiate();
        }

        private void Instantiate()
        {
            _quest = new()
            {
                name = "Quest",
                tag = "Quest"
            };
            _quest.AddComponent<QuestController>();
        }
    }
}