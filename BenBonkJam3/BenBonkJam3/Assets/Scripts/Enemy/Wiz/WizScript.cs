using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WizScript : MonoBehaviour
{
    Transform transformPlayer;
    Transform thisTransform;
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
    Vector2 direction;
    public GameObject shootWizSFX;
    void OnEnable()
    {
        thisTransform = GetComponent<Transform>();
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
            direction = (thisTransform.position - transformPlayer.position).normalized;
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * - forceBullet1 * 10);
        }
        else
        {
            // ...
        }
        GameObject goInstantiated = Instantiate(shootWizSFX, transform.position, Quaternion.identity);
        goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        StartCoroutine("ShooterCoroutine");
    }
}
