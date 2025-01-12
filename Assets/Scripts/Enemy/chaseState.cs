using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;


public class chaseState : StateMachineBehaviour
{
    private NavMeshAgent nav;
    private Transform target;

    private float stopChaseRange = 15;
    private float fieldOfViewAngle = 60f;

    private GameObject mainCam;
    private GameObject jumpCam;
    private GameObject ui;
    private AudioSource audiosrc;
    private AudioSource MainCamAudiosrc;

    [Header("SFX")]
    public AudioClip footsteps;
    public AudioClip bgm;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainCam = GlobalReferences.Instance.mainCam;
        jumpCam = GlobalReferences.Instance.jumpCam;
        ui = GlobalReferences.Instance.ui;
        nav = animator.GetComponent<NavMeshAgent>();
        target = GlobalReferences.Instance.player;
        audiosrc = animator.GetComponent<AudioSource>();
        MainCamAudiosrc = mainCam.GetComponent<AudioSource>();
        nav.speed = 4;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nav.SetDestination(target.position);

        float distance = Vector3.Distance(target.position,animator.transform.position);
        if(distance > stopChaseRange)
        {
            animator.SetBool("chase",false);
        }


        if (!MainCamAudiosrc.isPlaying)
        {
            MainCamAudiosrc.clip = bgm;
            MainCamAudiosrc.volume = 0.8f;
            MainCamAudiosrc.Play();
        }


        if (!audiosrc.isPlaying)
        {
            audiosrc.clip = footsteps;
            audiosrc.volume = 0.8f;
            audiosrc.Play();
        }

       

        if(distance <= nav.stoppingDistance)
        {
            GlobalReferences.Instance.audiosrc.Play();
            nav.isStopped = true;
            nav.gameObject.SetActive(false);
            GlobalReferences.Instance.Enemies.SetActive(false);
            GlobalReferences.Instance.gunHolder.SetActive(false);
            GlobalReferences.Instance.foot.SetActive(false);
            GlobalReferences.Instance.showbuttons();
            target.gameObject.GetComponent<FirstPersonController>().enabled=false;
           
            ui.SetActive(false);
            jumpCam.SetActive(true);
            mainCam.SetActive(false);
            
        }
    }

   


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nav.SetDestination(animator.transform.position);
        audiosrc.Stop();
        MainCamAudiosrc.Stop();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
