using RPG.Renderer;
using UnityEngine;

namespace RPG.Entities
{
    public class Player
    {
        private readonly PlayerRenderer _playerRenderer;
        private readonly GameObject _mainCamera;

        public Player()
        {
            _playerRenderer = new PlayerRenderer();

            Camera defaultCamera = Camera.main;

            if (defaultCamera != null)
            {
                Object.Destroy(Camera.main.gameObject);
            }

            _mainCamera = InstantiateMainCamera();
        }

        private GameObject InstantiateMainCamera()
        {
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

            cameraGameObject.transform.SetParent(_playerRenderer.GetObject().transform, true);
            cameraGameObject.AddComponent<AudioListener>();
            cameraGameObject.AddComponent<Camera>();

            return cameraGameObject;
        }
    }
}
