using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed = 10.0f;
    public float jumpForce = 7f;
    public float walkSpeed = 10f;
    public float sprintSpeed = 18f;
    public float crouchSpeed = 5f;

    public bool cursorVisible = false;
    public bool jumpRequest = false;

    public LayerMask groundLayers;
    public CapsuleCollider col;

    private Rigidbody _rig;

	// Use this for initialization
	void Start () {
        _rig = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();		
	}
	
	// Update is called once per frame
	void Update () {

        HorizontalMovement();
        JumpCall();
        CursorShow();
	}

    void FixedUpdate()
    {
        Jump();
    }

    private bool IsGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3 (col.bounds.center.x,col.bounds.min.y, col.bounds.center.z),col.radius*.9f,groundLayers);       
    }

    public void HorizontalMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }

    public void CursorShow()
    {
        if (cursorVisible == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(cursorVisible==true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("escape")&&cursorVisible==false)
        {
            cursorVisible = true;
        }
        if (Input.GetKeyDown("escape") && cursorVisible == true)
        {
            cursorVisible = false;
        }
    }

    public void JumpCall()
    {
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            jumpRequest = true;
        }
    }

    public void Jump()
    {
        if (jumpRequest == true)
        {
            _rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequest = false;
        }
    }

    public void Sprint()
    {
        speed = sprintSpeed;
    }

    public void Crouch()
    {

    }
}
