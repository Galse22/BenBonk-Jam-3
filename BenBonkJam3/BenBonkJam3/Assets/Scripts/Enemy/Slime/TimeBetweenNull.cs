using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TimeBetweenNull : MonoBehaviour
{
    Transform transformPlayer;
    public float timeBtwNullF;
    public float timeToSet;
    public AIDestinationSetter aIDestinationSettler;
    public AIPath aIPath;

    public bool stunned;

    public Animator animator;

    bool looking;

    public Transform slimeTransform;

    public GameObject circleA;

    public Vector3 v3;
    void OnEnable()
    {
        transformPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        aIDestinationSettler.target = transformPlayer;
        stunned = false;
        animator.SetBool("walking", true);
        StartCoroutine("NullifyCoroutine");
    }

    private void OnDisable() {
        aIDestinationSettler.target = transformPlayer;
        StopAllCoroutines();
    }

    private void Update() {
        if(stunned)
        {
            aIDestinationSettler.target = null;
            animator.SetBool("walking", false);
            if(looking)
            {
                slimeTransform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                slimeTransform.localScale = new Vector3(-1f, 1f, 1f);
            }
            circleA.SetActive(true);
            if(v3 != Vector3.zero)
            {
                transform.position = v3;
            }
        }
        else
        {
            animator.SetBool("walking", true);
            circleA.SetActive(false);
        }
    }

    IEnumerator NullifyCoroutine()
    {
        if(!stunned)
        {
            yield return new WaitForSeconds(timeBtwNullF);
            aIDestinationSettler.target = null;
            yield return new WaitForSeconds(timeToSet);
            aIDestinationSettler.target = transformPlayer;
            StartCoroutine("NullifyCoroutine");
        }
        else
        {
            aIDestinationSettler.target = null;
        }
    }

    public void StunFunc()
    {
        aIDestinationSettler.target = transformPlayer;
        stunned = false;
        if(this.gameObject.activeSelf == true)
        {
            StartCoroutine("NullifyCoroutine");
        }
    }

    public void checkThat()
    {
        if(aIDestinationSettler.target != null)
        {
            if(aIPath.desiredVelocity.x >= 0.01f)
            {
                slimeTransform.localScale = new Vector3(1f, 1f, 1f);
                looking = true;
            }
            else if(aIPath.desiredVelocity.x <= -0.01f)
            {
                slimeTransform.localScale = new Vector3(-1f, 1f, 1f);
                looking = false;
            }
        }
    }
}
