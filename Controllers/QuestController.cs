using UnityEngine;
using RPG.Components;
using RPG.Components.Commons;
using Unity.VisualScripting;

namespace RPG.Controllers
{
    public class QuestController : MonoBehaviour
    {
        private QuestComponent _questComponent;

        private void Awake()
        {
            _questComponent = new QuestComponent();
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void Initialize()
        {
            foreach (SchemaQuest quest in _questComponent.GetQuests())
            {
                if (quest.Status != Status.NotStarted) { continue; }

                GameObject npc = GameObject.Find(quest.Owner);

                if (npc == null) { continue; }

                npc.GetComponent<NpcController>().HasNewQuest = true;
            }
        }

        public void TriggerQuest(GameObject NPC)
        {
            SchemaQuest quest = _questComponent.FindQuest(NPC.name);

            if (quest == null)
            {
                Debug.Log("Quest not found");
                
                return;
            }

            Debug.Log("Quest: " + quest.Name);
            Debug.Log("Status: " + quest.Status);
            NpcController npcController = NPC.GetComponent<NpcController>();

            switch (quest.Status)
            {
                case Status.NotStarted:
                    quest.Status = Status.InProgress;
                    npcController.HasNewQuest = false;
                    break;
                case Status.InProgress:
                    quest.Status = Status.Finished;
                    npcController.HasInformation = true;
                    Debug.Log("ok");
                    break;
                case Status.Finished:
                    quest.Status = Status.Completed;
                    npcController.HasInformation = false;
                    break;
                case Status.Completed:
                    break;
            }

            Debug.Log(_questComponent.UpdateStatus(quest));
        }

        public bool HasQuest(GameObject NPC)
        {
            SchemaQuest quest = _questComponent.FindQuest(NPC.name);

            if (quest == null)
            {
                Debug.Log("Quest not found");

                return false;
            }

            Debug.Log("Quest: " + quest.Name);
            Debug.Log("Status: " + quest.Status);

            return quest.Status != Status.Completed;
        }
    }
}