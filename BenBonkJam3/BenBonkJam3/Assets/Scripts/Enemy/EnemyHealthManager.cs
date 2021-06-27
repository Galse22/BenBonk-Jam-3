using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject deathGO;
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Spikes")
        {
            Die();
        }
    }
    public void Die()
    {
        SpawnerScript spawnerScript = GameObject.FindWithTag("GameManager").GetComponent<SpawnerScript>();
        spawnerScript.DecreaseTime();
        GameObject goInstantiated = Instantiate(deathGO, transform.position, Quaternion.identity);
        goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        this.gameObject.SetActive(false);
    }
}
