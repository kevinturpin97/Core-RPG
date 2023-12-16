using UnityEngine;
using RPG.Components;

namespace RPG.Controllers
{
    interface IQuest
    {
        void AcceptQuest();
        void CompleteQuest();
        bool IsQuestComplete();
        bool HasQuest();
    }

    public class QuestController : MonoBehaviour, IQuest
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

        void IQuest.CompleteQuest()
        {
            
        }

        bool IQuest.HasQuest()
        {
            return false;
        }

        bool IQuest.IsQuestComplete()
        {
            return false;
        }

        void IQuest.AcceptQuest()
        {
            
        }
    }
}