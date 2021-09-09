using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public bool debug;

        [Tooltip("The time it takes for next asteroid to spawn")] [SerializeField]
        private float timeToSpawn;

        [SerializeField] private GameObject[] asteroidPrefabs;

        private readonly List<GameObject> spawnedAsteroids = new List<GameObject>();

        private void Start()
        {
            SpawnAsteroid();
        }

        private void SpawnAsteroid()
        {
            var selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
            var selectedSpawnPoint = new Vector2(Random.Range(-6.66f, 6.66f), Random.Range(-5, 5));

            spawnedAsteroids.Add(Instantiate(selectedAsteroid, selectedSpawnPoint,
                selectedAsteroid.transform.rotation));

            if (debug) Debug.Log("Spawned a " + selectedAsteroid.name + " at " + selectedSpawnPoint);

            StartCoroutine(AsteroidSpawnCounter());
        }

        public void OnGameOver()
        {
            foreach (var asteroidGameObject in spawnedAsteroids.Where(asteroidGameObject => asteroidGameObject != null))
                asteroidGameObject.SetActive(false);

            gameObject.SetActive(false);
        }

        public void AddAsteroidToList(GameObject asteroid)
        {
            spawnedAsteroids.Add(asteroid);
        }

        public void RemoveAsteroidFromList(GameObject asteroid)
        {
            spawnedAsteroids.Remove(asteroid);
        }

        private IEnumerator AsteroidSpawnCounter()
        {
            yield return new WaitForSeconds(timeToSpawn);
            SpawnAsteroid();
        }
    }
}