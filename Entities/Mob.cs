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
            _mob = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Mobs/MOB_1"));
            _mob.name = "Mob_1";
            _mob.tag = "Mob";
            _mob.transform.position = Vector3.zero;
            _mob.AddComponent<MobController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            _mob.transform.SetParent(entityGroup.transform, false);
        }
    }
}