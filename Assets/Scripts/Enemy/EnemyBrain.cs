using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class EnemyBrain : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 patrolPos;

    private NavMeshAgent nav;

    void Start()
    {
        startPos = transform.position;
        patrolPos = GetPatrolPosition();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update() {
        nav.SetDestination(patrolPos);

        if(Vector3.Distance(transform.position, patrolPos) < 1f)
        {
            patrolPos = GetPatrolPosition();
        }
    }

    private Vector3 GetPatrolPosition()
    {
        return startPos + getRandomDir() * Random.Range(10f, 70f);
    }

    private Vector3 getRandomDir() 
    {
        return new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}