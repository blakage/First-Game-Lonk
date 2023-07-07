using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    Animator animator;

    public string currentState = "idle";
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string stateName, float speed = 1) {
        animator.speed = speed;

        if(stateName == currentState){
            return;
        }

        animator.Play(stateName);
        currentState = stateName;
    }

}
