using UnityEngine;
using RPG.Controllers;

namespace RPG.Entities
{
    public class Npc
    {
        private GameObject _npc;

        public Npc()
        {
            Instantiate();
        }

        private void Instantiate()
        {
            _npc = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Npcs/NPC_1"));
            _npc.name = "NPC_1";
            _npc.tag = "Npc";
            _npc.transform.position = Vector3.zero;
            _npc.AddComponent<NpcController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            _npc.transform.SetParent(entityGroup.transform, false);
        }
    }
}