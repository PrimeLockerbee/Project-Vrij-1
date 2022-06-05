using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator a_Animator;

    private float f_gripTarget;
    private float f_triggerTarget;
    private float f_gripCurrent;
    private float f_triggerCurrent;

    public float f_speed;

    private string s_animatorGripParam = "Grip";    
    private string s_animatorTriggerParam = "Grip";

    void Start()
    {
        a_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        f_gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        f_triggerTarget = v;
    }

    void AnimateHand()
    {
        if(f_gripCurrent != f_gripTarget)
        {
            f_gripCurrent = Mathf.MoveTowards(f_gripCurrent, f_gripTarget, Time.deltaTime * f_speed);
            a_Animator.SetFloat(s_animatorGripParam, f_gripCurrent);
        }        
        
        if(f_triggerCurrent != f_triggerTarget)
        {
            f_triggerCurrent = Mathf.MoveTowards(f_triggerCurrent, f_triggerTarget, Time.deltaTime * f_speed);
            a_Animator.SetFloat(s_animatorTriggerParam, f_triggerCurrent);
        }
    }
}
