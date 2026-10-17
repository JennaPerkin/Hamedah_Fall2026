using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceAnimation : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isSpacePressed", true);
        }
        else
        {
            animator.SetBool("isSpacePressed", false);
        }
    }
}
