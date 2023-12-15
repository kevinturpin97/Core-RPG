using UnityEngine;
using RPG.Manager;

namespace RPG
{
    public class Main : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = new();
        }
        private void Start()
        {

        }

        private void Update()
        {
            //Debug.Log(_gameManager._playerManager.GetPlayerComponent()); 
        }
    }

}