using UnityEngine;
using RPG.Entities;
using System.Collections.Generic;

namespace RPG.Manager
{
    public class EntityManager
    {
        private readonly Player _player;
        private readonly List<Mob> _mobs;
        public EntityManager(Player player = null, List<Mob> mobs = null)
        {
            //Debug.Log("Initialisation de EntityManager");

            _player = player ?? new Player();
            _mobs = mobs ?? new List<Mob>();

            for (int i = 0; i < 10; i++)
            {
                _mobs.Add(new Mob());
            }
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}