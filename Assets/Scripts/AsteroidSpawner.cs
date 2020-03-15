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
		GameObject _selectedSpawnPoint;
		GameObject _selectedAsteroid;

		_selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
		_selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

		Instantiate(_selectedAsteroid, _selectedSpawnPoint.transform.position, _selectedAsteroid.transform.rotation);

		if (debug)
		{
			Debug.Log("Spawned a " + _selectedAsteroid.name + " at " + _selectedSpawnPoint.transform.position);
		}

		StartCoroutine(AsteroidSpawnCounter());
	}

	private IEnumerator AsteroidSpawnCounter()
	{
		yield return new WaitForSeconds(timeToSpawn);
		SpawnAsteroid();
	}
}
