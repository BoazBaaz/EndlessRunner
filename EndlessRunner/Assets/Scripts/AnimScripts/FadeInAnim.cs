using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAnim : MonoBehaviour
{
    public static FadeInAnim instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public Animator animator;

    public void FadeIn()
    {
        animator.SetBool("isStarting", true); //when function is called, the bool of the selected animator gets set to true
    }
}
