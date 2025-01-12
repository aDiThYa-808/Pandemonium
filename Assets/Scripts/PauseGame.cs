using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [Header("Pause Menu Components")]
    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject SettingsMenu;

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

    public void Settingsmenu()
    {
        audiosrc.Play();
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
