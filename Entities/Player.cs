using UnityEngine;

namespace RPG.Entities
{
    public sealed class Player : BaseCharacter
    {

        public Player(float life = 100, int level = 1, float exp = 100, float speed = 2, Vector3 position = default(Vector3)) : base(life, level, exp, speed, position)
        {
            
        }
    }
}