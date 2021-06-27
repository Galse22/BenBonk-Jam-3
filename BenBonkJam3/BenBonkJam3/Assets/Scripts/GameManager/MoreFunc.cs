using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFunc : MonoBehaviour
{
    public GameObject sfxM1;
    public GameObject sfxM2;
    public GameObject sfxM3;
    GameObject goInstantiated;
    public Transform transformPlayer;
    public void RandomMagnetPSfx()
    {
        GameObject SFX = GameObject.FindWithTag("MagnetSFX");
        if(SFX == null)
        {
            int iV = Random.Range(0, 3);
            if(iV == 0)
            {
                goInstantiated = Instantiate(sfxM1, transformPlayer.position, Quaternion.identity);
            }
            else if(iV == 1)
            {
                goInstantiated = Instantiate(sfxM2, transformPlayer.position, Quaternion.identity);
            }
            else
            {
                goInstantiated = Instantiate(sfxM3, transformPlayer.position, Quaternion.identity);
            }
            goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        }
    }
}
