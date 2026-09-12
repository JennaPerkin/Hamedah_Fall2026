using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRBMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 InputKey;
    public float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        // InputKey is set by player input using unity's unput manager
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        // Adding force to rigidbody based on InputKey and Movement Speed
        rb.AddForce(InputKey * moveSpeed);
    }

}
