using UnityEngine;
using RPG.Controllers;

namespace RPG.Entities
{
    // <summary>
    // The Player class is responsible for managing the player's GameObject and Camera.
    // </summary>
    public class Player
    {
        private GameObject _player;
        private GameObject _mainCamera;

        public Player()
        {
            Instantiate();
            InstantiateMainCamera();
        }

        private void Instantiate()
        {
            _player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerPrefab"));
            _player.name = "Player";
            _player.AddComponent<PlayerController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            if (entityGroup == null)
            {
                entityGroup = new GameObject
                {
                    name = "Entities",
                    tag = "Entity"
                };
            }

            _player.transform.SetParent(entityGroup.transform);
        }

        private void InstantiateMainCamera()
        {
            if (Camera.main != null)
            {
                Object.Destroy(Camera.main.gameObject);
            }

            _mainCamera = new()
            {
                name = "PlayerCamera",
                tag = "MainCamera",
                transform =
                {
                    position = new Vector3(0f, 2f, -5f),
                    rotation = Quaternion.Euler(10f, 0f, 0f),
                    localScale = Vector3.one
                }
            };

            _mainCamera.transform.SetParent(_player.transform, true);
            _mainCamera.AddComponent<AudioListener>();
            _mainCamera.AddComponent<Camera>();
        }
    }
}
