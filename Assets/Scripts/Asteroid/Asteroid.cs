using System.Collections;
using Enums;
using UI;
using UnityEngine;

namespace Asteroid
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private GameObject[] asteroidPrefabs;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float protectedDuration;
        [SerializeField] private AsteroidType asteroidType;
        private AsteroidSpawner asteroidSpawner;
        private bool isSpawnProtected = true;

        private Vector2 movementDirection = Vector2.zero;

        private UIUpdater uIUpdater;

        private void Start()
        {
            SetRandomDirection();
            StartCoroutine(SpawnProtectionCounter());
            uIUpdater = FindObjectOfType<UIUpdater>();
            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
        }

        private void Update()
        {
            transform.Translate(movementDirection.normalized * movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isSpawnProtected)
                return;

            if (collision.CompareTag("Laser"))
                GiveScore();

            DestroyAsteroid();
        }

        private void DestroyAsteroid()
        {
            asteroidSpawner.RemoveAsteroidFromList(gameObject);

            switch (asteroidType)
            {
                case AsteroidType.Major:
                    asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[1], transform.position,
                        transform.rotation));
                    asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[1], transform.position,
                        transform.rotation));
                    Destroy(gameObject);
                    break;
                case AsteroidType.Medium:
                    asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[0], transform.position,
                        transform.rotation));
                    asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[0], transform.position,
                        transform.rotation));
                    Destroy(gameObject);
                    break;
                case AsteroidType.Minor:
                    Destroy(gameObject);
                    break;
                default:
                    Debug.LogError("Default case in DestroyAsteroid should not be able to happen", this);
                    break;
            }
        }

        private void GiveScore()
        {
            switch (asteroidType)
            {
                case AsteroidType.Major:
                    uIUpdater.AddScore(20);
                    break;
                case AsteroidType.Medium:
                    uIUpdater.AddScore(50);
                    break;
                case AsteroidType.Minor:
                    uIUpdater.AddScore(100);
                    break;
                default:
                    Debug.LogError("Default state when awarding score should not be able to happen", this);
                    break;
            }
        }

        private void SetRandomDirection()
        {
            movementDirection = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
        }

        private IEnumerator SpawnProtectionCounter()
        {
            yield return new WaitForSeconds(protectedDuration);
            isSpawnProtected = false;
        }
    }
}