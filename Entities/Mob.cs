using RPG.Renderer;
using UnityEngine;

namespace RPG.Entities
{
    public class Mob
    {
        private readonly GameObject _mob;

        public Mob()
        {
            Instantiate();
        }

        private void Instantiate()
        {
            GameObject mobObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MobPrefab"));
            mobObject.name = "Mob";
            mobObject.AddComponent<MobController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            if (entityGroup == null)
            {
                entityGroup = new GameObject
                {
                    name = "Entities",
                    tag = "Entity"
                };;
            }

            mobObject.transform.SetParent(entityGroup.transform);

            _mob = mobObject;
        }
    }
}