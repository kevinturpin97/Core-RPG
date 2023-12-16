using UnityEngine;
using RPG.Controllers;

namespace RPG.Entities
{
    public class Mob
    {
        private GameObject _mob;

        public Mob()
        {
            Instantiate();
        }

        private void Instantiate()
        {
            _mob = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MobPrefab"));
            _mob.name = "Mob";
            _mob.AddComponent<MobController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            if (entityGroup == null)
            {
                entityGroup = new GameObject
                {
                    name = "Entities",
                    tag = "Entity"
                };;
            }

            _mob.transform.SetParent(entityGroup.transform);
        }
    }
}