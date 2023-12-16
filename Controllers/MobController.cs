using RPG.Components;
using UnityEngine;

namespace RPG.Controllers
{
    public class MobController : MonoBehaviour
    {
        private MobComponent _mobComponent;
        private Collider _obstacleCollider;

        private void Awake()
        {
            _mobComponent = new MobComponent(position: new Vector3(3f, 0f, 3f));
        }

        private void Start()
        {
            transform.position = _mobComponent.GetPosition();
        }

        private void Update()
        {
            _mobComponent.SetPosition(transform.position);
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