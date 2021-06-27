using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    int health = 3;
    public GameObject thirdHeart;
    public GameObject secondHeart;
    public GameObject firstHeart;

    public float sIntensity;
    public float sTime;

    public GameObject loseTXT;

    private void Start() {
        Time.timeScale = 1f;
    }
    public void TakeDamagePlayer()
    {
        health--;
        if(health == 2)
        {
            RemoveAllEnemies();
            thirdHeart.SetActive(false);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        }
        else if(health == 1)
        {
            RemoveAllEnemies();
            secondHeart.SetActive(false);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        }
        else
        {
            firstHeart.SetActive(false);
            loseTXT.SetActive(true);
            Time.timeScale = 0.00001f;
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
        foreach(GameObject bullet1 in allBullets1)
        {
            bullet1.SetActive(false);
        }
        GameObject[] allBullets2 = GameObject.FindGameObjectsWithTag("BulletTwo");
        foreach(GameObject bullet2 in allBullets2)
        {
            bullet2.SetActive(false);
        }
    }
}
