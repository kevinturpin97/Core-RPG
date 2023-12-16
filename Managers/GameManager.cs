using UnityEngine;

namespace RPG.Managers
{
    public class GameManager
    {
        private EntityManager _entityManager;
        public GameManager()
        {
            _entityManager = new EntityManager();
        }
    }
}
