using UnityEngine;
using RPG.Components;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerComponent _playerComponent;
        private Collider _obstacleCollision;
        private Collider _obstacleTrigger;
        private Rigidbody _rigidbody;
        private QuestController _questController;
        private bool isGrounded = true;

        private void Awake()
        {
            _playerComponent = new PlayerComponent(100, 1, 0, 5, new Vector3(0, 0, 0));
            // TODO: add rigidbody in Player
            _rigidbody = gameObject.GetComponent<Rigidbody>();

            GameObject quest = GameObject.FindWithTag("Quest");

            if (quest == null)
            {
                Debug.Log("Erreur QuestController n'a pas pu être chargée depuis PlayerController");
            }

            _questController = quest.GetComponent<QuestController>();
        }

        private void Start()
        {
            _questController.Initialize();
            transform.position = _playerComponent.GetPosition();
        }

        private void Update()
        {
            EventLIstener();

            _playerComponent.SetPosition(transform.position);
        }

        private void EventLIstener()
        {
            ViewListener();
            MoveListener();
            ActionListener();
        }

        private void ViewListener()
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * 2f, 0f);
        }

        private void MoveListener()
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
                moveDirection += transform.forward;

            if (Input.GetKey(KeyCode.S))
                moveDirection -= transform.forward;

            if (Input.GetKey(KeyCode.A))
                moveDirection -= transform.right;

            if (Input.GetKey(KeyCode.D))
                moveDirection += transform.right;

            //if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            //{
            //    _rigidbody.AddExplosionForce(_rigidbody.mass * 10f, transform.position + Vector3.up, 1f, 1f, ForceMode.Impulse);
            //    isGrounded = false;
            //}
            
            //isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

            moveDirection.Normalize();

            if (moveDirection != Vector3.zero)
            {
                transform.position += moveDirection * _playerComponent.GetSpeed() * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 2f : 1f);
            }
        }

        private void OnDrawGizmos()
        {
            if (_obstacleCollision == null) { return; }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_obstacleCollision.bounds.center, _obstacleCollision.bounds.extents.magnitude);
        }

        private void ActionListener()
        {
            if (Input.GetMouseButtonUp(0) && _obstacleTrigger)
            {
                _questController.TriggerQuest(_obstacleTrigger.gameObject);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("Defend");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.name.StartsWith("NPC"))
            {
                return;
            }

            if (_obstacleTrigger == other) { return; }

            if (!_questController.HasQuest(other.gameObject)) { return; }
            
            // TODO: replace with outline urp
            if (_obstacleTrigger != null)
            {
                _obstacleTrigger.gameObject.transform.Find("NpcModel").GetComponent<Renderer>().material.color = Color.white;
            }

            _obstacleTrigger = other;
            _obstacleTrigger.gameObject.transform.Find("NpcModel").GetComponent<Renderer>().material.color = Color.red;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.name.StartsWith("NPC"))
            {
                return;
            }

            if (_obstacleTrigger == null) { return; }

            if (_obstacleTrigger != other) { return; }

            _obstacleTrigger.gameObject.transform.Find("NpcModel").GetComponent<Renderer>().material.color = Color.white;

            _obstacleTrigger = null;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.name == "Ground")
            {
                return;
            }

            _obstacleCollision = collision.collider;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.name == "Ground")
            {
                return;
            }

            _obstacleCollision = null;
        }
    }
}