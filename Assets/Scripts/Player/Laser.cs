using EditorTools;
using GlobalConstants;
using UI;
using UnityEngine;

namespace Player
{
    public class Laser : MonoBehaviour
    {
        private float moveSpeed;

        private void Update()
        {
            transform.Translate(Vector3.right * (ConstantsHandler.LaserMovementSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            FindObjectOfType<UIUpdater>().AddScore(-5);
            Destroy(gameObject);
        }
    }
}