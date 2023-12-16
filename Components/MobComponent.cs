using UnityEngine;

namespace RPG.Components
{
    public class MobComponent : BaseCharacter
    {
        public MobComponent(float life = 1000, int level = 10, float speed = 2, Vector3 position = default(Vector3)) : base(life, level, speed, position)
        {

        }
    }
}