using System.Collections.Generic;
using UnityEngine;
using RPG.Entities;

namespace RPG.Managers
{
    public class EntityManager
    {
        private Player _player;
        private List<Mob> _mobs;
        public EntityManager()
        {
            Initialize();

            _player = new Player();
            _mobs = new List<Mob>
            {
                new Mob()
            };
        }

        private void Initialize()
        {
            GameObject entityGroup = new()
            {
                name = "Entities",
                tag = "Entity"
            };
        }
    }
}