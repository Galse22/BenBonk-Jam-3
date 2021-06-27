using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public float sIntensity;
    public float sTime;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            HealthManager healthManager = GameObject.FindWithTag("GameManager").GetComponent<HealthManager>();
            healthManager.TakeDamagePlayer();
            this.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "NorthPole")
        {
            this.gameObject.SetActive(false);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime); 
        }
    }
}
