using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingBox : MonoBehaviour
{
	private bool isWrappingX = false;
	private bool isWrappingY = false;
	private Renderer rend;

	private void Start()
	{
		rend = GetComponentInChildren<Renderer>();
	}

	private void Update()
	{
		ScreenWrap();
	}

	private void ScreenWrap()
	{
		bool isVisible = CheckRenderers();

		if (isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}

		if (isWrappingX && isWrappingY)
		{
			return;
		}

		Vector2 newPosition = transform.position;

		if (newPosition.x > 6.66f || newPosition.x < -6.66f)
		{
			newPosition.x = -newPosition.x;
			isWrappingX = true;
		}

		if (newPosition.y > -5 || newPosition.y < 5)
		{
			newPosition.y = -newPosition.y;
			isWrappingX = true;
		}

		transform.position = newPosition;
	}

	private bool CheckRenderers()
	{
		if (transform.position.x < 6.66f && transform.position.x >-6.66f)
		{
			if (transform.position.y > -5 && transform.position.y < 5)
			{
				return true;
			}
		}

		return false;
	}
}
