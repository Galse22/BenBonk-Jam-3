using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnWall : MonoBehaviour
{
    public bool destroyOnWallBool;

    private void OnEnable() {
        destroyOnWallBool = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8 && destroyOnWallBool)
        {
            this.gameObject.SetActive(false);
        }
    }
}
