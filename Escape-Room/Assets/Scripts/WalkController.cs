using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkController : MonoBehaviour {
    public float x;
    public float y;
    public float z;


    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float walkSpeed = 3.0f;

    public bool isRunning = false;
    public bool isGrounded = true;
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            walkSpeed = 7.0f;
            isRunning = true;
        }

        x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        Debug.Log(transform.position);
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        transform.Translate(x, 0, z);
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            walkSpeed = 3.0f;
            isRunning = false;
        }
    }
}
