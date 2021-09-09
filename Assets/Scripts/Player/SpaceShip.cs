using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform laserSpawnPoint;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float thrustAmount;
        [SerializeField] private float shotCooldown;
        [SerializeField] private AnimationClip playerRespawnClip;

        private float angularVelocity;

        private float horizontal;

        private bool isOnCooldown;
        private bool isSpawnProtected;

        private PlayerAnimation playerAnimation;
        private float respawnTime;
        private float thrustForce;

        private UIUpdater uIScoreUpdater;
        private float vertical;

        private void Start()
        {
            respawnTime = playerRespawnClip.length;
            playerAnimation = FindObjectOfType<PlayerAnimation>();
            uIScoreUpdater = FindObjectOfType<UIUpdater>();
        }

        private void Update()
        {
            horizontal = -Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            angularVelocity = horizontal * rotationSpeed;
            thrustForce = vertical * thrustAmount;

            transform.Rotate(Vector3.forward * angularVelocity * Time.deltaTime);
            transform.Translate(Vector3.right * thrustForce * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space)) Shoot();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isSpawnProtected || collision.CompareTag("Laser"))
                return;

            PlayerDied();
        }

        private void PlayerDied()
        {
            gameObject.transform.position = Vector3.zero;

            uIScoreUpdater.RemoveLife();

            // Start respawn animation
            isSpawnProtected = true;
            if (gameObject.activeSelf)
                StartCoroutine(PlayerRespawn());
        }

        private void Shoot()
        {
            if (isOnCooldown)
                return;

            var spawnedLaser = Instantiate(laserPrefab, laserSpawnPoint.position, transform.rotation);
            Destroy(spawnedLaser, 2);
            isOnCooldown = true;
            StartCoroutine(ShootCooldown());
        }

        private IEnumerator PlayerRespawn()
        {
            isSpawnProtected = true;
            playerAnimation.StartRespawnAnimation();

            yield return new WaitForSeconds(respawnTime);
            isSpawnProtected = false;
        }

        private IEnumerator ShootCooldown()
        {
            yield return new WaitForSeconds(shotCooldown);
            isOnCooldown = false;
        }
    }
}