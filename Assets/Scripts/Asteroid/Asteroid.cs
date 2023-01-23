using System;
using System.Collections;
using EditorTools;
using Enums;
using GlobalConstants;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

// To clarify between System.Random and UnityEngine.Random

namespace Asteroid
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private GameObject[] asteroidPrefabs;
        [SerializeField] private AsteroidType asteroidType;

        private AsteroidSpawner asteroidSpawner;
        private UIUpdater uIUpdater;
        private Vector2 movementDirection = Vector2.zero;
        private bool isSpawnProtected = true;
        private float movementSpeed;

        private void Awake()
        {
            uIUpdater = FindObjectOfType<UIUpdater>();
            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
        }

        private void Start()
        {
            switch (asteroidType)
            {
                case AsteroidType.Major:
                    movementSpeed = ConstantsHandler.MajorAsteroidMovementSpeed;
                    break;
                case AsteroidType.Medium:
                    movementSpeed = ConstantsHandler.MediumAsteroidMovementSpeed;
                    break;
                case AsteroidType.Minor:
                    movementSpeed = ConstantsHandler.MinorAsteroidMovementSpeed;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            movementDirection = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
            StartCoroutine(SpawnProtectionCounter());
        }

        private void Update()
        {
            transform.Translate(movementDirection.normalized * (movementSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isSpawnProtected)
                return;

            if (collision.CompareTag(ConstantsHandler.LaserTag))
                GiveScore();

            DestroyAsteroid();
        }

        private void DestroyAsteroid()
        {
            // asteroidSpawner.RemoveAsteroidFromList(gameObject);

            switch (asteroidType)
            {
                case AsteroidType.Major:
                    SplitInto(asteroidPrefabs[1], 3);
                    Destroy(gameObject);
                    break;
                case AsteroidType.Medium:
                    SplitInto(asteroidPrefabs[0], 3);
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

        private void SplitInto(GameObject asteroidPrefab, int amount)
        {
            for (var i = 0; i < amount; i++)
                Instantiate(asteroidPrefab, transform.position, transform.rotation);
            // asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefab, transform.position, transform.rotation));
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

        private IEnumerator SpawnProtectionCounter()
        {
            yield return new WaitForSeconds(ConstantsHandler.ProtectedDuration);
            GetComponent<Collider2D>().enabled = true;
            isSpawnProtected = false;
        }
    }
}