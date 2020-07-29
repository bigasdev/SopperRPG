using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller))]
public class Player : MonoBehaviour
{
	public Animator anim;
	
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	public float moveSpeed = 6;

	public GameObject sfx;
	public Transform sfxPlace;
	private float swordTimer = .5f;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;


	Controller controller;

	void Start()
	{
		controller = GetComponent<Controller>();

		gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update()
	{
		swordTimer += Time.deltaTime;
		
		float h = Input.GetAxis("Horizontal");

		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
		{			
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		if(h < 0)
		{
			velocity.x = Mathf.SmoothDamp(-velocity.x, -targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? -accelerationTimeGrounded : -accelerationTimeAirborne);
		}
		velocity.y += gravity * Time.deltaTime;
	    controller.Move(velocity * Time.deltaTime);	
		
		if(velocity.y >= 1 || velocity.y <= -1)
		{
			anim.SetBool("Jump", true);
		}
		else
		{
			anim.SetBool("Jump", false);
		}

		if (h == 0)
		{
			anim.SetBool("Idle", true);
		}
		else
		{
			anim.SetBool("Idle", false);
		}
		anim.SetFloat("horizontal", Mathf.Abs(h));

        if(h < 0)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if(Input.GetButtonDown("Fire1") && swordTimer >= .5f)
		{
			anim.SetTrigger("Attack");
			StartCoroutine(sfxEffect());
			swordTimer = 0f;
		}

		IEnumerator sfxEffect()
		{
			yield return new WaitForSeconds(.4f);
			var sfxE = Instantiate(sfx, sfxPlace);
			Destroy(sfxE, .2f);
		}
	}
}
