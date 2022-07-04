using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    void Start()
    {
        if (animator = null)
        {
            animator = GetComponent<Animator>();
        }
        else
        {
            return;
        }
        this.animator.speed = speed;
    }
}
