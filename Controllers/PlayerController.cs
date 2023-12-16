using RPG.Components;
using System;
using UnityEngine;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerComponent _playerComponent;
        private Collider _obstacleCollider;

        private void Awake()
        {
            _playerComponent = new PlayerComponent(100, 1, 0, 5, new Vector3(0, 0, 0));
        }

        private void Start()
        {
            transform.position = _playerComponent.GetPosition();
        }

        private void Update()
        {
            this.EventLIstener();

            _playerComponent.SetPosition(transform.position);
        }

        private void EventLIstener()
        {
            this.ViewListener();
            this.MoveListener();
            this.ActionListener();
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

            moveDirection.Normalize();

            if (moveDirection != Vector3.zero)
            {
                transform.position += moveDirection * _playerComponent.GetSpeed() * Time.deltaTime;
            }
        }

        private void OnDrawGizmos()
        {
            if (_obstacleCollider == null) { return; }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_obstacleCollider.bounds.center, _obstacleCollider.bounds.extents.magnitude);
        }

        private void ActionListener()
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Attack");
                Destroy(gameObject);
            }
            else if (Input.GetMouseButton(1))
            {
                Debug.Log("Defend");
            }
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