using UnityEngine;

namespace RPG.Entities
{
    // <summary>
    // The Player class is responsible for managing the player's GameObject and Camera.
    // </summary>
    public class Player
    {
        private readonly GameObject _player;
        private readonly GameObject _mainCamera;

        public Player()
        {
            Instantiate();
            InstantiateMainCamera();
        }

        private void Instantiate()
        {
            GameObject playerObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerPrefab"));
            playerObject.name = "Player";
            playerObject.AddComponent<PlayerController>();

            GameObject entityGroup = GameObject.FindWithTag("Entity");

            if (entityGroup == null)
            {
                entityGroup = new GameObject
                {
                    name = "Entities",
                    tag = "Entity"
                };
            }

            playerObject.transform.SetParent(entityGroup.transform);

            _player = playerObject;
        }

        private void InstantiateMainCamera()
        {
            if (Camera.main != null)
            {
                Object.Destroy(Camera.main.gameObject);
            }

            GameObject cameraGameObject = new()
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

            cameraGameObject.transform.SetParent(_player.transform, true);
            cameraGameObject.AddComponent<AudioListener>();
            cameraGameObject.AddComponent<Camera>();

            _mainCamera = cameraGameObject;
        }
    }
}
