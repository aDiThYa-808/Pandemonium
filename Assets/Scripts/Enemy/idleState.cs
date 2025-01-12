using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleState : StateMachineBehaviour
{
    private float timer;
    private float chaseRange = 8;
    private Transform target;
    private AudioSource audiosrc;

    [Header("SFX")]
    public AudioClip breathing;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GlobalReferences.Instance.player;
        audiosrc = animator.GetComponent<AudioSource>();
        timer = 0f;
        
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if(timer > 3f)
        {
            animator.SetBool("patrol", true);
        }

        float distanceFromPlayer = Vector3.Distance(target.position, animator.transform.position);

        if(distanceFromPlayer < chaseRange)
        {
            animator.SetBool("chase", true);

        }

        if (!audiosrc.isPlaying)
        {
            audiosrc.clip = breathing;
            audiosrc.volume = 0.036f;
            audiosrc.Play();
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audiosrc.Stop();
    }

     //OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
