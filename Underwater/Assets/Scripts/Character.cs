﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

	[SerializeField]
	private float accelerationForce = 5f;

	[SerializeField]
	private float jumpForce = 5f;

	[SerializeField]
	private float maxSpeed = 5f;

	[SerializeField]
	private Rigidbody2D rb2d;

	[SerializeField]
	private Collider2D playerGroundCollider;

	[SerializeField]
	private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;

	[SerializeField]
	private Collider2D groundDetectTrigger;

	[SerializeField]
	private ContactFilter2D groundContactFilter;

	Animator anim;

	//private bool doubleJump = false;
	private bool facingRight = true;
	private float horizontalInput;
	private bool isOnGround;
	private Collider2D[] groundHitDetectionResults = new Collider2D[16];
    //public LayerMask whatIsGround;
    //private Checkpoint currentCheckpoint;
    public bool isDead;
	void Start()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		UpdateIsOnGround();
		UpdateHorizontalInput();
		HandleJumpInput();
        if (Input.GetKeyDown(KeyCode.Space) && isDead)
        {
            Respawn();
        }
        //winText.text = "";
        //SetCountText();

        //if ((isOnGround || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        //{
        //    anim.SetBool("Ground", false);
        //    rb2d.AddForce(new Vector2(0, jumpForce));

        //    if (!doubleJump && !isOnGround)
        //        doubleJump = true;
        //}
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            UpdatePhysicsMaterial();
        Move();
        
        //float move = Input.GetAxis("Horizontal");
     
        //if (move > 0 && !facingRight)
        //    Flip();
        //else if (move < 0 && facingRight)
        //    Flip();
        }

	}

	private void UpdatePhysicsMaterial()
	{
		if (Mathf.Abs(horizontalInput) > 0)
		{
			playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
		}
		else
		{
			playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
		}
	}

	private void UpdateHorizontalInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
	}

	private void UpdateIsOnGround()
	{
		isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;
		// Debug.Log("IsOnGround?: " + isOnGround);
	}

	private void HandleJumpInput()
	{
		if (Input.GetButtonDown("Jump") && isOnGround)
		{
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		//if (isOnGround)
		//    doubleJump = false;
	}

	private void Move()
	{
		rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
		Vector2 clampedVelocity = rb2d.velocity;
		clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = clampedVelocity;
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    public void KillPlayer()
    {
       isDead = true;
        anim.SetBool("isDead", true);

    }
    public void Respawn()
    {
        isDead = false;
        anim.SetBool("isDead", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("respwaned");
    }
	//public void Respawn()
	//{
	//	if (currentCheckpoint == null)
	//		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	//	else
	//	{
	//		rb2d.velocity = Vector2.zero;
	//		transform.position = currentCheckpoint.transform.position;
	//	}
	//}

	//public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
	//{
	//	if (currentCheckpoint != null)
	//		currentCheckpoint.SetIsActivated(false);

	//	currentCheckpoint = newCurrentCheckpoint;
	//	currentCheckpoint.SetIsActivated(true);
	//}
	//void OnTriggerEnter2D(Collider2D other)
	//{
	//    if (other.gameObject.CompareTag("PickUp"))
	//    {
	//        other.gameObject.SetActive(false);
	//        count = count + 1;
	//        SetCountText();
	//    }
	//}
	//void SetCountText()
	//{
	//    countText.text = "Count: " + count.ToString();
	//    if (count >= 6)
	//    {
	//        winText.text = "You Win";
	//    }
	//}
}
