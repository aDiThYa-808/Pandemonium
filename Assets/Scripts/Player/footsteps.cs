using System.Collections;
using UnityEngine;
using StarterAssets;

public class footsteps : MonoBehaviour
{
    [Header("Footstep Clips")]
    public AudioClip WalkingSFX;
    public AudioClip RunningSFX;

    [Header("Player")]
    public GameObject Player;

    private AudioSource audioSrc;
    private FirstPersonController controller;
    private bool isSprinting;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        controller = Player.GetComponent<FirstPersonController>();
        isSprinting = controller._input.sprint;
    }

    private void Update()
    {
        if (controller.isMoving)
        {
            PlayFootSteps();
        }
        else
        {
            StopFootSteps();
        }
    }

    private void PlayFootSteps()
    {
        bool currentlySprinting = controller._input.sprint;

        // Check if we need to change the clip
        if (currentlySprinting != isSprinting || !audioSrc.isPlaying)
        {
            isSprinting = currentlySprinting;

            // Assign the correct clip
            audioSrc.clip = isSprinting ? RunningSFX : WalkingSFX;
            audioSrc.Stop(); // Stop the current clip
            audioSrc.Play(); // Play the updated clip
        }
    }

    private void StopFootSteps()
    {
        if (audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
    }
}
