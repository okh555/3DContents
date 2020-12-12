using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalspeed = 1.25f; // 가로로 움직이는 속도(방향)
    private float walkspeed = 2.0F; // 걷는 모션일 때 속도
    private float rotSpeed = 40f; // 회전 할 때 속도
    private float distToGround; // 땅과 player 사이 거리
    private float gravity = -20.0f; // 중력
    private bool wallJump = false; // 벽점프를 위한 bool 변수


    private Vector3 moveDirection = Vector3.zero;
    private Vector3 jumpSpeed = new Vector3(0f, 0f, 0f);

    Vector3 rot = Vector3.zero;
    Animator anim;
    Rigidbody rigidbody;
    CharacterController controller;


    public Vector3 Speed { get; private set; } // 참고용 speed



    public float speed { get; set; } = 13.0F; // 설정용 -> private으로 바꿀 예정
    public float jumpHeight { get; set; } = 6f; // 설정용 -> private으로 바꿀 예정
    public float wallJumpHeight { get; set; } = 10f;

    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        gameObject.transform.eulerAngles = rot;
        controller = GetComponent<CharacterController>();

        anim.SetBool("Open_Anim", true);
        anim.SetBool("Roll_Anim", true);

        distToGround = GetComponent<SphereCollider>().bounds.extents.y;
    }
    void FixedUpdate()
    {
        CheckKey();
        
        if(wallJump)
        {
            wallMove();

        }
        else
        {
            Move();
        }
        gameObject.transform.eulerAngles = rot;
    }


    void Reset()
    {
        if (transform.position.y < -5)
        {
            speed = 13.0F;
            verticalspeed = 1.25f;
            walkspeed = 2.0F;
            rotSpeed = 40f;
            gravity = -20.0f;
            jumpHeight = 6f;
            moveDirection = Vector3.zero;
            jumpSpeed = new Vector3(0f, 0f, 0f);



            transform.position = new Vector3(0, 3f, 0);
            anim.SetBool("Roll_Anim", false);
            anim.SetBool("Open_Anim", false);
            anim.SetBool("Open_Anim", true);
        }
    }

    void Move()// 캐릭터 움직임
    {

        if (anim.GetBool("Open_Anim") && anim.GetCurrentAnimatorStateInfo(0).IsName("closed_Roll_Loop")) // Rolling
        {
            if (IsGrounded()) // Grounded
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            else // in Air
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * verticalspeed, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed * 0.8f;
            }

            if (moveDirection.z + moveDirection.x > 0)
                anim.SetFloat("Speed", Mathf.Min((moveDirection.z + moveDirection.x) / 2, 1f));
            else
                anim.SetFloat("Speed", Mathf.Max((moveDirection.z + moveDirection.x) / 2, -1f));

            controller.Move(moveDirection * Time.deltaTime);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("anim_Walk_Loop")) // Walking
        {
            if (IsGrounded()) // Grounded
            {
                Vector3 walkDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                walkDirection = transform.TransformDirection(walkDirection);
                walkDirection *= speed * 0.2f;
                controller.Move(walkDirection * Time.deltaTime);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() && anim.GetBool("Roll_Anim"))
            {  
                jumpSpeed.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
            if(wallJump && anim.GetBool("Roll_Anim"))
            {
                jumpSpeed.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }

        }
        jumpSpeed.y += gravity * Time.deltaTime;
        if (jumpSpeed.y < 0)
        {
            jumpSpeed.y = Mathf.Max(gravity * Time.deltaTime, jumpSpeed.y);
        }
        controller.Move(jumpSpeed * Time.deltaTime); // Jump
        Speed = moveDirection + jumpSpeed;

    }


    void wallMove()
    {
        controller.velocity.Set(0, 0, 0);
        controller.enabled = false;
        anim.SetFloat("Speed", 0);
        if(Input.GetKey(KeyCode.Space))
        {

            wallJump = false;
            controller.enabled = true;
            jumpSpeed.y = Mathf.Sqrt(wallJumpHeight * -3.0f * gravity);
            jumpSpeed.y += gravity * Time.deltaTime;
            if (jumpSpeed.y < 0)
            {
                jumpSpeed.y = Mathf.Max(gravity * Time.deltaTime, jumpSpeed.y);
            }
            controller.Move(jumpSpeed * Time.deltaTime); // Jump
            Speed = moveDirection + jumpSpeed;
        }
    }

    void CheckKey()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("closed_Roll_Loop"))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rot[1] -= rotSpeed * Time.fixedDeltaTime;
            }

            // Rotate Right
            if (Input.GetKey(KeyCode.E))
            {
                rot[1] += rotSpeed * Time.fixedDeltaTime;
            }

        }

        // Walk
        if (Input.GetKey(KeyCode.W) && !anim.GetBool("Roll_Anim"))
        {
            anim.SetBool("Walk_Anim", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk_Anim", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("anim_Walk_Loop") || anim.GetCurrentAnimatorStateInfo(0).IsName("anim_Idle_Loop_S"))
        {
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
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Wall")
        {
            wallJump = true;
            collider.gameObject.tag = "Untagged";
        }
    }
}



