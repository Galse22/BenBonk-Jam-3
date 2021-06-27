using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicScript : MonoBehaviour
{
    GameObject previousGO;
    private void Start() {
        // checks if find game object with same tag
        previousGO = GameObject.FindWithTag("MenuMusic");
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if(sceneName == "Menu")
        {
            if(previousGO != null && previousGO != this.gameObject)
            {
                Destroy(this.gameObject);
            }
        }
        else if(sceneName == "Cutscenes")
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
