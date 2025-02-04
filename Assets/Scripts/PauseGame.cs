using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StarterAssets;

public class PauseGame : MonoBehaviour
{
    [Header("Pause Menu Components")]
    public GameObject PauseMenu;
    public GameObject loadscreen;
    public Dropdown DropDown;

    [Header("SFX")]
    public AudioClip clickSound;

    private AudioSource audiosrc;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.clip = clickSound;
    }

    public void Pausegame()
    {
        audiosrc.Play();
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        audiosrc.Play();
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        audiosrc.Play();
        var scene = SceneManager.LoadSceneAsync("Menu");
        scene.allowSceneActivation = false;
        loadscreen.SetActive(true);
        StartCoroutine(LoadScene(scene));
    }

    private IEnumerator LoadScene(AsyncOperation scene)
    {
       
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

    public void adjustGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    

    
}
