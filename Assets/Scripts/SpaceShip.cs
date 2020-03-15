using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
	[SerializeField] private GameObject laserPrefab;
	[SerializeField] private Transform laserSpawnPoint;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float thrustAmount;
	[SerializeField] private float shotCooldown;

	private float horizontal;
	private float vertical;

	private float angularVelocity;
	private float thrustForce;

	private bool isOnCooldown = false;
	private bool isSpawnProtected = false;

	private void Update()
	{
		horizontal = -Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		angularVelocity = horizontal * rotationSpeed;
		thrustForce = vertical * thrustAmount;

		transform.Rotate((Vector3.forward * angularVelocity) * Time.deltaTime);
		transform.Translate((Vector3.right * thrustForce) * Time.deltaTime);

		if (Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isSpawnProtected)
			return;

		PlayerDied();
	}

	private void PlayerDied()
	{
		gameObject.transform.position = Vector3.zero;
		isSpawnProtected = true;
		// Start respawn animation
	}

	private void Shoot()
	{
		if (isOnCooldown)
			return;

		GameObject _spawnedLaser;
		_spawnedLaser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
		Destroy(_spawnedLaser, 5);
		isOnCooldown = true;
		StartCoroutine(ShootCooldown());
	}

	private IEnumerator ShootCooldown()
	{
		yield return new WaitForSeconds(shotCooldown);
		isOnCooldown = false;
	}
}
