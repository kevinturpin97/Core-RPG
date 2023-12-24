using UnityEngine;
using RPG.Managers;

namespace RPG
{
    public class Main : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = new GameManager();
        }
        private void Start()
        {
        }

        private void Update()
        {
        }
    }
}