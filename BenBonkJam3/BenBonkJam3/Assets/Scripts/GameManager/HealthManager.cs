using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    int health = 3;
    public GameObject thirdHearth;
    public GameObject secondHearth;

    public float sIntensity;
    public float sTime;
    public void TakeDamagePlayer()
    {
        health--;
        if(health == 2)
        {
            RemoveAllEnemies();
            thirdHearth.SetActive(false);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        }
        else if(health == 1)
        {
            RemoveAllEnemies();
            secondHearth.SetActive(false);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        }
        else
        {
            // played died
        }
    }

    void RemoveAllEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in allEnemies)
        {
            enemy.SetActive(false);
        }
        GameObject[] allBullets1 = GameObject.FindGameObjectsWithTag("BulletOne");
        foreach(GameObject bullet1 in allEnemies)
        {
            bullet1.SetActive(false);
        }
        GameObject[] allBullets2 = GameObject.FindGameObjectsWithTag("BulletTwo");
        foreach(GameObject bullet2 in allEnemies)
        {
            bullet2.SetActive(false);
        }
    }
}
