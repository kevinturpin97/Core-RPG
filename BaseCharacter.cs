using UnityEngine;

namespace RPG.Components
{
    interface ICharacter
    {
        void Move(Vector3 destination);
        void Attack(BaseCharacter target);
        void Die();
        void TakeDamage(float damage);
        void TakeExp(float exp);
        void Heal(float heal);
        float GetAttackDamage();
        float GetMagicDamage();
        float GetLife();
        int GetLevel();
        float GetExp();
        float GetExpToNextLevel();
        float GetSpeed();
        Vector3 GetPosition();
    }

    public abstract class BaseCharacter : ICharacter
    {
        #region SHOULD BE DECLARED IN PLAYER / MOB
        private const float BASE_ATTACK = 7.5f;
        private const float BASE_MAGIC = 10f;
        private const float BASE_MAX_LIFE = 100f;
        private const float BASE_EXP_TO_NEXT_LEVEL = 200f;
        #endregion
        private float _attackDamage;
        private float _magicDamage;
        private float _life;
        private float _maxLife;
        private int _level;
        private float _exp;
        private float _expToNextLevel;
        private float _speed;
        private Vector3 _position;

        public BaseCharacter(float life = 100, int level = 1, float exp = 0, float speed = 2, Vector3 position = default(Vector3))
        {
            _level = level;
            _maxLife *= level;
            _life = life;
            _expToNextLevel *= level;
            _exp = exp;
            _speed = speed;
            _position = position;
            _attackDamage = BASE_ATTACK * ((_level / 100) + 1);
            _magicDamage = BASE_MAGIC * ((_level / 100) + 1);
        }

        public void Move(Vector3 destination)
        {
            _position = destination;
        }

        public void Attack(BaseCharacter target)
        {
            target.TakeDamage(_attackDamage);
        }

        public void Die()
        {
            Debug.Log("Je meurs");
        }

        private void LevelUp()
        {
            _level++;
            _expToNextLevel = _level * BASE_EXP_TO_NEXT_LEVEL;
            _maxLife = _level * BASE_MAX_LIFE;
            _exp = 0;
            _attackDamage = BASE_ATTACK * ((_level / 100f) + 1f);
            _magicDamage = BASE_MAGIC * ((_level / 100f) + 1f);
        }

        public void TakeDamage(float damage)
        {
            if (_life - damage < 0)
            {
                _life = 0;
                this.Die();
            }
            else
            {
                _life -= damage;
            }
        }

        public void TakeExp(float exp)
        {
            if (_exp + exp >= _expToNextLevel)
            {
                LevelUp();
            }
            else
            {
                _exp += exp;
            }
        }

        public void Heal(float heal)
        {
            if (_life + heal > _maxLife)
            {
                _life = _maxLife;
            }
            else
            {
                _life += heal;
            }
        }

        public float GetAttackDamage()
        {
            return _attackDamage;
        }

        public float GetMagicDamage()
        {
            return _magicDamage;
        }

        public float GetLife()
        {
            return _life;
        }

        public int GetLevel()
        {
            return _level;
        }

        public float GetExp()
        {
            return _exp;
        }

        public float GetExpToNextLevel()
        {
            return _expToNextLevel;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return "BaseCharacter";
        }
    }
}