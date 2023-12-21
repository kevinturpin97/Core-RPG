using UnityEngine;

namespace RPG.Managers
{
    public class GameManager
    {
        private QuestManager _questManager;
        private EntityManager _entityManager;

        public GameManager()
        {
            _questManager = new QuestManager();
            _entityManager = new EntityManager();
        }
    }
}
