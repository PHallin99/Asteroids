using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField] private float movementSpeed;

	private void Update()
	{
		transform.Translate((transform.forward * movementSpeed) * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DestroyLaser();
	}

	private void DestroyLaser()
	{
		Destroy(gameObject);
	}
}
