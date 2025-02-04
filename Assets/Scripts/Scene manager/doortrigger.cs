using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doortrigger : MonoBehaviour
{
    public GameObject DoorPrompt;
    public GameObject LoadingScreen;
    public AudioClip btnClick;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the clickSound to the AudioSource
        audioSource.clip = btnClick;
    }


    private void OnTriggerEnter(Collider other)
    {
        DoorPrompt.SetActive(true);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        loadscene();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        DoorPrompt.SetActive(false);
    }

    public async void loadscene()
    {
        DoorPrompt.SetActive(false);
        audioSource.Play();
        LoadingScreen.SetActive(true);

        var scene = SceneManager.LoadSceneAsync("Playground");
        scene.allowSceneActivation = false;
        StartCoroutine(LoadScene(scene));
    }

        private IEnumerator LoadScene(AsyncOperation scene)
        {
            // Wait for a custom amount of time or until the scene is almost loaded
            yield return new WaitForSeconds(6);

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


    }

