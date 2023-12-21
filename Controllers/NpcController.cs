using UnityEngine;
using RPG.Components;
using RPG.Entities;

namespace RPG.Controllers
{
    public class NpcController : MonoBehaviour
    {
        private NpcComponent _npcComponent;
        private Collider _obstacleCollider;
        private bool _hasNewQuest = false;
        private bool _hasInformation = false;

        private void Awake()
        {
            _npcComponent = new NpcComponent(position: new Vector3(10f, 0f, 10f));
        }

        private void Start()
        {
            transform.position = _npcComponent.GetPosition();
        }

        private void Update()
        {
            _npcComponent.SetPosition(transform.position);
        }

        public bool HasNewQuest
        {
            get
            {
                return _hasNewQuest;
            }

            set
            {
                if (value)
                {
                    Transform model = transform.Find("NpcModel");

                    GameObject newQuest = Instantiate(Resources.Load<GameObject>("Prefabs/Quest/New"));
                    newQuest.name = "QuestAvailable";
                    newQuest.transform.position = new Vector3(0f, 2f * model.transform.localScale.y, 0f);

                    newQuest.transform.SetParent(transform, false);
                } else
                {
                    Destroy(transform.Find("QuestAvailable").gameObject);
                }

                _hasNewQuest = value;
            }
        }

        public bool HasInformation
        {
            get 
            { 
                return _hasInformation; 
            }
            set
            {
                if (value)
                {
                    Transform model = transform.Find("NpcModel");

                    GameObject information = Instantiate(Resources.Load<GameObject>("Prefabs/Quest/Info"));
                    information.name = "InformationAvailable";
                    information.transform.position = new Vector3(0f, 2f * model.transform.localScale.y, 0f);

                    information.transform.SetParent(transform, false);
                }
                else
                {
                    Destroy(transform.Find("InformationAvailable").gameObject);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (_obstacleCollider == null) { return; }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_obstacleCollider.bounds.center, _obstacleCollider.bounds.extents.magnitude);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.name == "Ground")
            {
                return;
            }

            _obstacleCollider = collision.collider;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.name == "Ground")
            {
                return;
            }

            _obstacleCollider = null;
        }
    }
}