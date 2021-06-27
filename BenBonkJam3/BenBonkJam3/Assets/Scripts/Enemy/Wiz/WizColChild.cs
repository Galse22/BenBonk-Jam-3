using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizColChild : MonoBehaviour
{
    HealthManager healthManager;

    private void OnEnable() {
        healthManager = GameObject.FindWithTag("GameManager").GetComponent<HealthManager>();
    }


     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "SouthPole")
        {
            healthManager.TakeDamagePlayer();
            this.gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
        }
    }
}
