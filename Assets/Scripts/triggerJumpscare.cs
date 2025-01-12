using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class triggerJumpscare : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject jumpCam;
    private NavMeshAgent nav;
    void Start()
    {
        mainCam = GlobalReferences.Instance.mainCam;
        jumpCam = GlobalReferences.Instance.jumpCam;
    }

    

    // Update is called once per frame
    
}
