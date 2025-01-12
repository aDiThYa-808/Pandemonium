using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnManager : MonoBehaviour
{
    public GameObject loadscreen;
    public AudioClip btnClick;
    private AudioSource audioSource;
    public GameObject camera;
    private AudioSource bgm;

    private void Start()
    {
        bgm = camera.GetComponent<AudioSource>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the clickSound to the AudioSource
        audioSource.clip = btnClick;
    }


    public void PlayGame()
    {
        audioSource.Play();
        bgm.Stop();
        loadscreen.SetActive(true);  // Activate loading screen
        var scene = SceneManager.LoadSceneAsync("Hospital");  // Start loading the "Hospital" scene asynchronously
        scene.allowSceneActivation = false;  // Prevent automatic scene activation
        StartCoroutine(LoadScene(scene));  // Start the coroutine to control when to activate the scene
    }

    private IEnumerator LoadScene(AsyncOperation scene)
    {
        // Wait for a custom amount of time or until the scene is almost loaded
        yield return new WaitForSeconds(8);

        // Optionally, you can also check if the scene is almost loaded
        while (scene.progress < 0.9f)
        {
            // This is just to show progress, you can update a loading bar here
            Debug.Log("Loading progress: " + scene.progress);
            yield return null;
        }

        // Now the scene is ready, so activate it
        scene.allowSceneActivation = true;

        
    }



    public void credits()
    {
        audioSource.Play();

    }

    public void quitgame()
    {
        audioSource.Play();

        // For Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();
        #endif
    }


}
