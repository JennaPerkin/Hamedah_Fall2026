using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRBMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 InputKey;
    public float moveSpeed;
    public float jumpForce;
    public float rotationSpeed;

    [Header("GroundDetection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        // InputKey is set by player input using unity's unput manager
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, ground);
        //Debug.Log("isGrounded: " + isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    void FixedUpdate()
    {
        // Adding force to rigidbody based on InputKey and Movement Speed
        rb.AddForce(InputKey * moveSpeed);

        if (InputKey.magnitude > 0.1f)
        {
            float Angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }

}
