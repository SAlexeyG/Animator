using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController =
            new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) animator.SetTrigger("Shoot");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(animatorOverrideController["Shooting"] != clip)
                animatorOverrideController["Shooting"] = clip;
            else
                animatorOverrideController["Shooting"] = null;
        }
        if (Input.GetKeyDown(KeyCode.P)) animator.SetTrigger("Stop");
    }
}
