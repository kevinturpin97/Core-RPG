using System.Collections.Generic;
using UnityEngine;
using RPG.Entities;

namespace RPG.Managers
{
    public class EntityManager
    {
        private Player _player;
        private List<Npc> _npcs;
        private List<Mob> _mobs;

        public EntityManager()
        {
            Initialize();

            _npcs = new List<Npc>
            {
                new Npc()
            };
            _mobs = new List<Mob>
            {
                new Mob()
            };

            _player = new Player(); // This must be the last one to be instantiated.
        }

        private void Initialize()
        {
            _ = new GameObject()
            {
                name = "Entities",
                tag = "Entity"
            };
        }
    }
}