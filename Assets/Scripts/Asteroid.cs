using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public bool debug = false;
	private enum AsteroidType {MAJOR, MEDIUM, MINOR}

	[SerializeField] private GameObject[] asteroidPrefabs;
	[SerializeField] private float movementSpeed;
	[SerializeField] private AsteroidType asteroidType;
	private Vector2 movementDirection = Vector3.zero;

	private void Start()
	{
		SetRandomDirection();
	}

	private void Update()
	{
		transform.Translate((movementDirection.normalized * movementSpeed) * Time.deltaTime);
	}

	// Physics Logic
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			DestroyAsteroid();

			if (debug)
			{
				Debug.Log("Collision between player and asteroid detected");
			}
		}

		else if (collision.CompareTag("Laser"))
		{
			DestroyAsteroid();

			if (debug)
			{
				Debug.Log("Collision between laser and asteroid detected");
			}
		}
	}

	private void DestroyAsteroid()
	{
		switch (asteroidType)
		{
			case AsteroidType.MAJOR:
				Instantiate(asteroidPrefabs[1], transform.position, transform.rotation);
				Instantiate(asteroidPrefabs[1], transform.position, transform.rotation);
				Destroy(gameObject);
				break;
			case AsteroidType.MEDIUM:
				Instantiate(asteroidPrefabs[0], transform.position, transform.rotation);
				Instantiate(asteroidPrefabs[0], transform.position, transform.rotation);
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

	public void SetRandomDirection()
	{
		movementDirection = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
	}
}
