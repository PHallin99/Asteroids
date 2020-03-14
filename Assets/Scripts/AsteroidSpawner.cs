using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public bool debug = false;

	[Tooltip("The time it takes for next asteroid to spawn")]
	[SerializeField] private float timeToSpawn;
	[SerializeField] private GameObject[] spawnPoints;
	[SerializeField] private GameObject[] asteroidPrefabs;

	private void Start()
	{
		SpawnAsteroid();
	}

	private void SpawnAsteroid()
	{
		GameObject selectedSpawnPoint;
		GameObject selectedAsteroid;

		selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
		selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

		Instantiate(selectedAsteroid, selectedSpawnPoint.transform.position, selectedAsteroid.transform.rotation);

		if (debug)
		{
			Debug.Log("Spawned a " + selectedAsteroid.name + " at " + selectedSpawnPoint.transform.position);
		}

		StartCoroutine(AsteroidSpawnCounter());
	}

	private IEnumerator AsteroidSpawnCounter()
	{
		yield return new WaitForSeconds(timeToSpawn);
		SpawnAsteroid();
	}
}
