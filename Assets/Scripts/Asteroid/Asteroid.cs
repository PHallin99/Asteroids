﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public enum AsteroidType {MAJOR, MEDIUM, MINOR}

	[SerializeField] private GameObject[] asteroidPrefabs;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float protectedDuration;
	[SerializeField] private AsteroidType asteroidType;

	private Vector2 movementDirection = Vector3.zero;
	private bool isSpawnProtected = true;

	private UIUpdater uIUpdater;
	private AsteroidSpawner asteroidSpawner;

	private void Start()
	{
		SetRandomDirection();
		StartCoroutine(SpawnProtectionCounter());
		uIUpdater = FindObjectOfType<UIUpdater>();
		asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
	}

	private void Update()
	{
		transform.Translate((movementDirection.normalized * movementSpeed) * Time.deltaTime);
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
			case AsteroidType.MAJOR:
				asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[1], transform.position, transform.rotation));
				asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[1], transform.position, transform.rotation));
				Destroy(gameObject);
				break;
			case AsteroidType.MEDIUM:
				asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[0], transform.position, transform.rotation));
				asteroidSpawner.AddAsteroidToList(Instantiate(asteroidPrefabs[0], transform.position, transform.rotation));
				Destroy(gameObject);
				break;
			case AsteroidType.MINOR:
				Destroy(gameObject);
				break;
			default:
				Debug.LogError("Default case in DestroyAsteroid should not be able to happen");
				break;
		}
	}

	private void GiveScore()
	{
		switch (asteroidType)
		{
			case AsteroidType.MAJOR:
				uIUpdater.AddScore(20);
				break;
			case AsteroidType.MEDIUM:
				uIUpdater.AddScore(50);
				break;
			case AsteroidType.MINOR:
				uIUpdater.AddScore(100);
				break;
			default:
				Debug.LogError("Default state when awarding score should not be able to happen");
				break;
		}
	}

	public void SetRandomDirection()
	{
		movementDirection = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
	}

	private IEnumerator SpawnProtectionCounter()
	{
		yield return new WaitForSeconds(protectedDuration);
		isSpawnProtected = false;
	}
}
