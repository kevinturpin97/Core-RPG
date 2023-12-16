using UnityEngine;

namespace RPG.Managers
{
    public class GameManager
    {
        private EntityManager _entityManager;
        private QuestManager _questManager;

        public GameManager()
        {
            _entityManager = new EntityManager();
            _questManager = new QuestManager();
        }
    }
}
