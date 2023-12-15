using RPG.Components;
using UnityEngine;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerComponent _playerComponent;
        private void Awake()
        {
            _playerComponent = new PlayerComponent();
        }
        private void Start()
        {
            
        }
        private void Update()
        {
            transform.position = _playerComponent.GetPosition();
        }
    }
}
