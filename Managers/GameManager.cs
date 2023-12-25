using UnityEngine;

namespace RPG.Managers
{
    public class GameManager
    {
        private SceneManager _sceneManager;
        private UIManager _uiManager;

        public GameManager()
        {
            _sceneManager = new SceneManager();
            _uiManager = new UIManager();
            Initialize();
        }

        public void Initialize()
        {
            // TODO: preload assets
            _sceneManager.LoadLevel(1);
        }
    }
}
