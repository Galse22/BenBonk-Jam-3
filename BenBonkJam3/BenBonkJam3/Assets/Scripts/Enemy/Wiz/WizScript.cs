using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WizScript : MonoBehaviour
{
    Transform transformPlayer;
    public AIDestinationSetter aIDestinationSettler;
    public float timeBtwShooting;
    public float stoppingDistance;
    public AIPath aIPath;
    float currentDistance;
    public Animator anim;
    public Transform placeToShoot;
    int valRand;

    public float forceBullet1;
    public float forceBullet2;
    void OnEnable()
    {
        transformPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        aIDestinationSettler.target = transformPlayer;
        StartCoroutine("ShooterCoroutine");
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private void Update() {
        currentDistance = aIPath.remainingDistance;
        if(currentDistance < stoppingDistance)
        {
            aIPath.canMove = false;
            anim.SetBool("walking", false);
        }
        else
        {
            aIPath.canMove = true;
            anim.SetBool("walking", true);
        }
    }

    IEnumerator ShooterCoroutine()
    {
        yield return new WaitForSeconds(timeBtwShooting);
        valRand = Random.Range(0, 100);
        if(valRand > 0)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("WBullet1");
            bullet.transform.position = placeToShoot.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * forceBullet1);
        }
        else
        {
            // ...
        }
        
        StartCoroutine("ShooterCoroutine");
    }
}
