﻿using System.Collections;
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

    GameObject enemySpawned;
    private void Start() {
        maxHouse = housesPlaces.Length;
        StartCoroutine("SpawnEnemy");
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(timeBtwEnemy);
        randomHouse = Random.Range(0, maxHouse);
        val = Random.Range(0, 100);
        if(val <= 40)
        {
            enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("SlimeEnemy");
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
    }
}