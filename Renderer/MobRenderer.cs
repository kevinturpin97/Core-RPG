
using UnityEngine;
using RPG.Controllers;

namespace RPG.Renderer
{
    public class MobRenderer
    {
        private GameObject _gameObject;
        public MobRenderer()
        {
            _gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MobPrefab"));
            _gameObject.name = "Mob";
            _gameObject.AddComponent<MobController>();

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
