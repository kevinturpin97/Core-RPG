using UnityEngine;

namespace RPG.Components
{
    interface ICharacter
    {
        void Move(Vector3 destination);
        void Attack(BaseCharacter target);
        void Die();
        void TakeDamage(float damage);
        void Heal(float heal);
        float GetAttackDamage();
        float GetMagicDamage();
        float GetLife();
        int GetLevel();
        float GetSpeed();
        void SetPosition(Vector3 position);
        Vector3 GetPosition();
    }

    public abstract class BaseCharacter : ICharacter
    {
        #region SHOULD BE OVERRIDE IN CHILD COMPONENT
        protected virtual float BASE_ATTACK { get; set; } = 0f;
        protected virtual float BASE_MAGIC { get; set; } = 0f;
        protected virtual float BASE_MAX_LIFE { get; set; } = 0f;
        protected virtual float BASE_EXP_TO_NEXT_LEVEL { get; set; } = 0f;
        #endregion

        private float _attackDamage;
        private float _magicDamage;
        private float _life;
        private float _maxLife;
        private int _level;
        private float _speed;
        private Vector3 _position;

        public BaseCharacter(float life = 100, int level = 1, float speed = 2, Vector3 position = default(Vector3))
        {
            _level = level;
            _maxLife *= level;
            _life = life;
            _speed = speed;
            _position = position;
            _attackDamage = BASE_ATTACK * ((_level / 100) + 1);
            _magicDamage = BASE_MAGIC * ((_level / 100) + 1);
        }

        public void Move(Vector3 destination)
        {
            _position = new Vector3(_position.x + destination.x * _speed * Time.deltaTime, _position.y, _position.z + destination.z * _speed * Time.deltaTime);
        }

        public void Attack(BaseCharacter target)
        {
            target.TakeDamage(_attackDamage);
        }

        public void Die()
        {
            Debug.Log("Je meurs");
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
        protected virtual void LevelUp()
        {
            _level++;
            _maxLife = _level * BASE_MAX_LIFE;
            _attackDamage = BASE_ATTACK * ((_level / 100f) + 1f);
            _magicDamage = BASE_MAGIC * ((_level / 100f) + 1f);
        }

        public override string ToString()
        {
            return "BaseCharacter";
        }
    }
}