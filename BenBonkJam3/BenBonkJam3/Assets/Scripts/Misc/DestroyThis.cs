using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public float time;
    public bool shouldNotDestroyOnLoad;
    void Start()
    {
        if(shouldNotDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        Destroy(this.gameObject, time);
    }
}
