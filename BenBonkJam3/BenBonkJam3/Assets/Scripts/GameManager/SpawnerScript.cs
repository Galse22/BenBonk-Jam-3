using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float timeBtwEnemy;
    public float minTime;
    public float timeToDecrease;
    public GameObject[] housesPlaces;
    int randomHouse;
    int maxHouse;
    int val;

    public int wizVal;

    GameObject enemySpawned;

    public Transform healthBar;
    public Transform player;
    float healthDivided;
    public  float enemiesNeeded = 50;
    float currentEnemies = 1;

    bool activated;
    public GameObject sfxPortal;

    public float sIntensity;
    public float sTime;

    private void Start() {
        maxHouse = housesPlaces.Length;
        StartCoroutine("SpawnEnemy");
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(timeBtwEnemy);
        randomHouse = Random.Range(0, maxHouse);
        val = Random.Range(0, 100);
        if(val <= wizVal)
        {
            enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("WizardEnemy");
        }
        else
        {
            enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("SlimeEnemy");
        }
        enemySpawned.transform.position = housesPlaces[randomHouse].transform.position;
        enemySpawned.SetActive(true);
        StartCoroutine("SpawnEnemy");
    }

    public void DecreaseTime()
    {
        timeBtwEnemy -= timeToDecrease;
        if(timeBtwEnemy < minTime)
        {
            timeBtwEnemy = minTime;
        }
        currentEnemies++;
        healthDivided = 1 - (currentEnemies / enemiesNeeded);
        healthBar.localScale = new Vector3 (1, healthDivided);
        if(currentEnemies >= enemiesNeeded && !activated)
        {
            activated = true;
            Instantiate(sfxPortal, player.position, Quaternion.identity);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime); 
        }
    }
}
