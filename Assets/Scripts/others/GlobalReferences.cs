using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    // Singleton Instance
    public static GlobalReferences Instance { get; private set; }

    // Public reference for player
    [Header("Player Components")]
    public Transform player;
    public GameObject mainCam;
    public GameObject jumpCam;
    public GameObject gunHolder;
    public GameObject foot;

    [Header("UI")]
    public GameObject ui;

    [Header("Audio Source")]
    public AudioSource audiosrc;

    [Header("Parent with all enemy game objects")]
    public GameObject Enemies;

    [Header("Retry/Quit button")]
    public GameObject retrybutton;
    
   
    public void showbuttons()
    {
        StartCoroutine(showbuttonsafterseconds());
    }
    IEnumerator showbuttonsafterseconds()
    {
        yield return new WaitForSeconds(4);
        retrybutton.SetActive(true);
    }
    


    private void Awake()
    {
        // Ensure only one instance of GlobalReferences exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
            return;
        }

        // Set the singleton instance
        Instance = this;

    }
}
