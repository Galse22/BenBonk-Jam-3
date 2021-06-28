using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    public bool damageEnabled;
    public bool damageEnemies;
    public float sIntensity;
    public float sTime;

    private void OnEnable() {
        damageEnabled = true;
        damageEnemies = false;
        this.gameObject.tag = "BulletOne";
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && damageEnabled)
        {
            HealthManager healthManager = GameObject.FindWithTag("GameManager").GetComponent<HealthManager>();
            healthManager.TakeDamagePlayer();
            this.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "Enemy" && damageEnemies)
        {
            EnemyHealthManager enemyHealthManager = col.gameObject.GetComponent<EnemyHealthManager>();
            enemyHealthManager.Die();
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime); 
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag == "Enemy" && damageEnemies)
        {
            EnemyHealthManager enemyHealthManager = col.gameObject.GetComponent<EnemyHealthManager>();
            enemyHealthManager.Die();
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime); 
        }
    }
}
