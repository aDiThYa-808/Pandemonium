using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HospitalGameManager : MonoBehaviour
{
    

    [Header("Gun")]
    public GameObject Gun_onBed;
    public GameObject Gun_inHand;
    public AudioSource Audiosrc;
    public AudioClip GunPickUpClip;
    public GameObject GunPickUpTrigger;
    public GameObject GunPickUpPrompt;

    [Header("pause menu")]
    public GameObject pauseMenu;
    public GameObject loadscreen;

    [Header("Letter")]
    public GameObject Letter;

    [Header("SFX")]
    public AudioClip clickSound;

    private AudioSource audiosrc;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.clip = clickSound;
    }

    public void GunPickUp()
    {
        Audiosrc.clip = GunPickUpClip;
        Audiosrc.Play();
        GunPickUpTrigger.SetActive(false);
        GunPickUpPrompt.SetActive(false);
        Gun_onBed.SetActive(false);
        Gun_inHand.SetActive(true);
    }

    public void pausegame()
    {
        audiosrc.Play();
        pauseMenu.SetActive(true);
       
    }

    public void resumegame()
    {
        audiosrc.Play();
        pauseMenu.SetActive(false);
        
    }

    public void LoadMainMenu()
    {
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

    public void DisableLetter()
    {
        Letter.SetActive(false);
    }

    
}
