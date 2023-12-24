namespace RPG.Managers
{
    public class SceneManager
    {
        private QuestManager _questManager;
        private EntityManager _entityManager;

        public SceneManager()
        {

        }

        public void MainMenu()
        {

        }

        public void LoadLevel(int level)
        {
            _questManager = new QuestManager();
            _entityManager = new EntityManager();
        }
    }
}
