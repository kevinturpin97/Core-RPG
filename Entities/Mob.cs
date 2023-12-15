using UnityEngine;

namespace RPG.Entities
{
    public sealed class Mob : BaseCharacter
    {
        public Mob(float life = 1000, int level = 10, float exp = 0, float speed = 2, Vector3 position = default(Vector3)) : base(life, level, exp, speed, position)
        {
            Debug.Log("Initialisation de Mob");
        }
    }
}