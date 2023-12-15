
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
            _gameObject.AddComponent<PlayerController>();
        }
    }
}
