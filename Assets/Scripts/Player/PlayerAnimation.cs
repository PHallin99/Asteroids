using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void StartRespawnAnimation()
	{
		animator.SetBool("Respawning", true);
	}

	public void StopRespawnAnimation()
	{
		animator.SetBool("Respawning", false);
	}
}
