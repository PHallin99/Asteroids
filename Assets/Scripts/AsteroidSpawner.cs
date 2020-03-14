using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	public bool debug = false;

	[Tooltip("The time it takes for next asteroid to spawn")]
	[SerializeField] private float timeToSpawn;
	[SerializeField] private GameObject[] asteroidPrefabs;

	private void Start()
	{
		SpawnAsteroid();
	}

	private void SpawnAsteroid()
	{
		Vector3 selectedSpawnPoint;
		GameObject selectedAsteroid;

		selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
		selectedSpawnPoint = new Vector2(Random.Range(-6.66f, 6.66f), Random.Range(-5, 5));

		Instantiate(selectedAsteroid, selectedSpawnPoint, selectedAsteroid.transform.rotation);

		if (debug)
		{
			Debug.Log("Spawned a " + selectedAsteroid.name + " at " + selectedSpawnPoint);
		}

		StartCoroutine(AsteroidSpawnCounter());
	}

	private IEnumerator AsteroidSpawnCounter()
	{
		yield return new WaitForSeconds(timeToSpawn);
		SpawnAsteroid();
	}
}
