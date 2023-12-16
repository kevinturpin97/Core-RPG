
using UnityEngine;
using RPG.Controllers;

namespace RPG.Renderer
{
    public class PlayerRenderer
    {
        private GameObject _gameObject;

        public PlayerRenderer()
        {
            _gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerPrefab"));
            _gameObject.name = "Player";
            _gameObject.AddComponent<PlayerController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            if (entityGroup == null)
            {
                throw new System.Exception("Le groupe d'entité n'est pas instancié");
            }

            _gameObject.transform.SetParent(entityGroup.transform);
        }

        public GameObject GetObject()
        {
            return _gameObject;
        }
    }
}
