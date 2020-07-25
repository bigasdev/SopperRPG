using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour
{
	float moveSpeed = 6;
	float gravity = -5;
	public Animator anim;
	Vector3 velocity;

	Controller controller;

	void Start()
	{
		controller = GetComponent<Controller>();
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		velocity.x = input.x * moveSpeed;
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		if (h == 0)
		{
			anim.SetBool("Idle", true);
		}
		else
		{
			anim.SetBool("Idle", false);
		}
		anim.SetFloat("horizontal", Mathf.Abs(h));
	}
}
