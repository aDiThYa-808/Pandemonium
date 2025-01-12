using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class buttontrigger : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject loadscreen;
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


    public async void loadscene()
    {
        if (text.color.a != 0)
        {
            audioSource.Play();
            loadscreen.SetActive(true);
            var scene = SceneManager.LoadSceneAsync("Menu");
            scene.allowSceneActivation = false;
            StartCoroutine(LoadScene(scene));
        }
    }
    private IEnumerator LoadScene(AsyncOperation scene)
    {
        // Wait for a custom amount of time or until the scene is almost loaded
        yield return new WaitForSeconds(4);

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
