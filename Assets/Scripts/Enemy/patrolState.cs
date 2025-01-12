using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolState : StateMachineBehaviour
{

    private float timer;
    private float chaseRange = 8;
    List<Transform> waypoints = new List<Transform>();
    private NavMeshAgent nav;
    private Transform target;
    private AudioSource audiosrc;


    [Header("SFX")]
    public AudioClip footsteps;



    
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        nav = animator.GetComponent<NavMeshAgent>();
        target = GlobalReferences.Instance.player;
        audiosrc = animator.GetComponent<AudioSource>();


        nav.speed = 2;
        timer = 0f;
        GameObject points = GameObject.FindGameObjectWithTag("waypoints");

        foreach(Transform t in points.transform)
        {
            waypoints.Add(t);
        }

        nav.SetDestination(waypoints[Random.Range(0,waypoints.Count)].position);

    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(nav.remainingDistance <= nav.stoppingDistance)
        {
            nav.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }

        timer += Time.deltaTime;

        if(timer > 10f)
        {
            animator.SetBool("patrol", false);
        }

        float distanceFromPlayer = Vector3.Distance(target.position, animator.transform.position);

        if (distanceFromPlayer < chaseRange)
        {
            animator.SetBool("chase", true);
        }

        if (!audiosrc.isPlaying)
        {
            audiosrc.clip = footsteps;
            audiosrc.volume = 0.036f;
            audiosrc.Play();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nav.SetDestination(nav.transform.position);
        audiosrc.Stop();
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
