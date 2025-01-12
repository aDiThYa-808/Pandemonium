using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class headbob : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Headbob settings")]
    [Range(0.001f, 0.01f)]
    public float amount = 0.002f;

    [Range(1f, 30f)]
    public float frequency = 10.0f;

    [Range(10f, 100f)]
    public float smooth = 10f;

    Vector3 StartPos;

    [HideInInspector] public FirstPersonController fpc;

    void Start()
    {
        StartPos = transform.localPosition;
        fpc = player.gameObject.GetComponent<FirstPersonController>();
    }

    void Update()
    {
        CheckForMovement();
        StopHeadBob();

        if(fpc.isMoving && fpc._input.sprint)
        {
            amount = 0.01f;
            frequency = 20.2f;
            smooth = 100f;
        }
        else if(fpc.isMoving && !fpc._input.sprint)
        {
            amount = 0.003f;
            frequency = 8.4f;
            smooth = 33.4f;
        }

    }

    private void CheckForMovement()
    {
       fpc = player.gameObject.GetComponent<FirstPersonController>();

        if(fpc.isMoving == true)
        {
            StartHeadBob();
        }
    }

    private Vector3 StartHeadBob()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y , Mathf.Sin(Time.time * frequency)*amount*1.4f , smooth*Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x , Mathf.Sin(Time.time * frequency/2f) * amount * 1.6f, smooth * Time.deltaTime);
        transform.localPosition += pos;
        return pos;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == StartPos) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos , 1* Time.deltaTime);
    }
}
