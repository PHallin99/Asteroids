using UnityEngine;

namespace Player
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        private void Update()
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DestroyLaser();
        }

        private void DestroyLaser()
        {
            Destroy(gameObject);
        }
    }
}