using UnityEngine;
using RPG.Components.Commons;

namespace RPG.Components
{
    class Test
    {
        public string Name;
    }

    public class QuestComponent
    {
        private SchemaQuest _schemaQuest;

        public QuestComponent()
        {
            Initialize();
        }

        private void Initialize()
        {
            // get quest from xml or json
            string path = "Assets/Resources/Quests/Quests.json";
            var stream = System.IO.File.OpenText(path);
            var json = stream.ReadToEnd();
            Test test = JsonUtility.FromJson<Test>(json);

            Debug.Log(test.Name);
        }
    }
}