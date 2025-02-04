using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruthDoorTrigger : MonoBehaviour
{
    public GameObject doorPrompt;
    public GameObject loadscreen;
    public AudioSource doorAudiosrc;
    public AudioClip doorSound;


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            doorPrompt.SetActive(false);
        }
    }


    public void LoadFinalScene()
    {
        doorAudiosrc.clip = doorSound;
        doorAudiosrc.Play();
        loadscreen.SetActive(true);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync("Climax");
        scene.allowSceneActivation = false;
        yield return new WaitForSeconds(3f);
        while(scene.progress < 0.9f)
        {
            yield return null;
        }

        

        scene.allowSceneActivation = true;
    }
}
