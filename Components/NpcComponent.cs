using UnityEngine;
using RPG.Components.Commons;

namespace RPG.Components
{
    public class NpcComponent : BaseCharacter
    {
        public NpcComponent(float life = 1000, int level = 10, float speed = 2, Vector3 position = default(Vector3)) : base(life, level, speed, position)
        {

        }
    }
}