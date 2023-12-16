using UnityEngine;
using RPG.Components;

namespace RPG.Controllers
{
    interface IQuest
    {

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
    }
}