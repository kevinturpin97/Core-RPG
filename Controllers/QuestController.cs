using UnityEngine;
using RPG.Components;

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
    }
}