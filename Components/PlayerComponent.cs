using UnityEngine;

namespace RPG.Components
{
    interface IPlayer
    {
        void TakeExp(float exp);
        float GetExp();
        float GetExpToNextLevel();
    }
    public class PlayerComponent : BaseCharacter, IPlayer
    {
        protected override float BASE_ATTACK { get; set; } = 7.5f;
        protected override float BASE_MAGIC { get; set; } = 100f;
        protected override float BASE_MAX_LIFE { get; set; } = 100f;
        protected override float BASE_EXP_TO_NEXT_LEVEL { get; set; } = 200f;
        private float _exp;
        private float _expToNextLevel;

        public PlayerComponent(float life = 100, int level = 1, float exp = 0, float speed = 5, Vector3 position = default(Vector3)) : base(life, level, speed, position)
        {
            _expToNextLevel = this.GetLevel() * BASE_EXP_TO_NEXT_LEVEL;
            _exp = exp < _expToNextLevel ? exp : 0;
        }

        public void TakeExp(float exp)
        {
            _exp += exp;
            if (_exp >= _expToNextLevel)
            {
                LevelUp();
            }
        }

        public float GetExp()
        {
            return _exp;
        }

        protected override void LevelUp()
        {
            base.LevelUp();

            _exp = 0;
            _expToNextLevel = this.GetLevel() * BASE_EXP_TO_NEXT_LEVEL;
        }

        public float GetExpToNextLevel()
        {
            return _expToNextLevel;
        }
    }
}
