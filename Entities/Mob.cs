using RPG.Renderer;
using UnityEngine;

namespace RPG.Entities
{
    public class Mob
    {
        private readonly MobRenderer _mobRenderer;
        public Mob()
        {
            _mobRenderer = new MobRenderer();
        }
    }
}