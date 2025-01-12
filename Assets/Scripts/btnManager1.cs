using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnManager1 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip btnClick;
    public GameObject loadscreen;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = btnClick;
    }

    public void playAgain()
    {
        Debug.Log("clicked");
        loadScene("Playground");
    }


    public void quitgame()
    {
        loadScene("Menu");
    }

    public void loadScene(string sceneName)
    {
        audioSource.Play();
        loadscreen.SetActive(true);  // Activate loading screen
        var scene = SceneManager.LoadSceneAsync(sceneName);  // Start loading the "Hospital" scene asynchronously
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

}
