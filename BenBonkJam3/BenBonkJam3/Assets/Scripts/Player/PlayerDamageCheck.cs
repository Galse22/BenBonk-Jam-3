using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCheck : MonoBehaviour
{
    public HealthManager healthManager;
    public float iTime;

    bool canTakeDamage = true;
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Spikes" && canTakeDamage)
        {
            canTakeDamage = false;
            healthManager.TakeDamagePlayer();
            Invoke("ThatFuncPlayer", iTime);
        }
    }

    void ThatFuncPlayer()
    {
        canTakeDamage = true;
    }
}
