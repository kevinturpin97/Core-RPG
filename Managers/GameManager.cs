using UnityEngine;

namespace RPG.Managers
{
    public class GameManager
    {
        private EntityManager _entityManager;
        public GameManager() 
        {
            //Debug.Log("Initialisation de GameManager");

            _entityManager = new EntityManager();
        }
    }
}
