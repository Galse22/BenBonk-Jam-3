using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public bool pEnabled;
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player" && pEnabled)
        {
            SceneManager.LoadScene(3);
        }
    }
}
