using UnityEngine;
using RPG.Components;
using RPG.Renderer;

namespace RPG.Manager
{
    public class EntityManager
    {
        private PlayerRenderer _playerRenderer;
        public EntityManager()
        {
            _playerRenderer = new PlayerRenderer();
        }
    }
}