using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final_btn_Manager : MonoBehaviour
{
    public void loadScene()
    {
        var scene = SceneManager.LoadSceneAsync("Menu");
        scene.allowSceneActivation = false;

        if(scene.progress < 0.9f)
        {
            scene.allowSceneActivation = true;
        }

        
    }
}
