using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (rig.velocity.y < 0)
        {
            rig.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1)*Time.deltaTime;
        }
        else if (rig.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rig.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }   
}
