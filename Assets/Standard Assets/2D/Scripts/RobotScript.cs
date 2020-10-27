using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RobotScript : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("Jump");
        animator.SetBool("IsWalking", Input.GetKey(KeyCode.D));
        animator.SetBool("IsCrouching", Input.GetKey(KeyCode.LeftControl));
    }
}
