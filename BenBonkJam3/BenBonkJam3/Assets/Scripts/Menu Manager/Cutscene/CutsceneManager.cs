using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] imageArray;
    public Image baseImage;
    public int sceneNumber;
    int amountsButton;

    public GameObject buttonSFX;

    public void ChangeImage()
    {
        amountsButton++;
        GameObject goInstantiated = Instantiate(buttonSFX, Vector3.zero, Quaternion.identity);
        //goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        if(amountsButton < imageArray.Length)
        {
            baseImage.overrideSprite = imageArray[amountsButton];
        }
        else
        {
            ActualLoadScene();
        }
    }

    void ActualLoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
