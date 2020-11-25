using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    Animator anim;
    Rigidbody rigidbody;
    CharacterController controller;
    private float speed = 12.0F;

    private float verticalspeed = 1.25f;
    private float walkspeed = 2.0F;

    private float gravity = -10.0f;

    private float jumpHeight = 6f;


    private Vector3 moveDirection = Vector3.zero;
    private Vector3 jumpSpeed = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        gameObject.transform.eulerAngles = rot;
        controller = GetComponent<CharacterController>();

        anim.SetBool("Open_Anim", true);
        anim.SetBool("Roll_Anim", true);

    }
    void FixedUpdate()
    {
        CheckKey();
        Move();
        gameObject.transform.eulerAngles = rot;
    }
    
    void Move()// 캐릭터 움직임
    {        
        if (anim.GetBool("Open_Anim") && anim.GetCurrentAnimatorStateInfo(0).IsName("closed_Roll_Loop")) // Rolling
        {
            if (controller.isGrounded) // Grounded
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * verticalspeed, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            else // in Air
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * verticalspeed, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed * 0.5f;
            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("anim_Walk_Loop"))
        {
            if (controller.isGrounded) // Grounded
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed * 0.5f;
            }
        }
        else
        {
            moveDirection = moveDirection * Time.deltaTime * 0.8f;
        }
        if (moveDirection.z + moveDirection.x > 0)
            anim.SetFloat("Speed", Mathf.Min(moveDirection.z + moveDirection.x, 3f));
        else
            anim.SetFloat("Speed", Mathf.Max(moveDirection.z + moveDirection.x, -3f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(controller.isGrounded);
            if (jumpSpeed.y < 0 && jumpSpeed.y < 1 && anim.GetBool("Roll_Anim"))
            {
                Debug.Log("Jump");
                jumpSpeed.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }


        jumpSpeed.y += gravity * Time.deltaTime;
        if (jumpSpeed.y < 0)
        {
            jumpSpeed.y = Mathf.Min(gravity, jumpSpeed.y);
        }
        controller.Move(jumpSpeed * Time.deltaTime);



        controller.Move(moveDirection * Time.deltaTime);
    }

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W) && !anim.GetBool("Roll_Anim"))
		{
			anim.SetBool("Walk_Anim", true);
        }
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.R))
		{
            if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}
