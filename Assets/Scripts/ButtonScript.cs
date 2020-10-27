using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ParticelSystemPlaying()
    {
        GetComponent<ParticleSystem>().Play();
    }

    public void Click()
    {
        animator.SetFloat("Blend", Random.Range(0f, 1f));
        animator.SetTrigger("Click");
    }
}
