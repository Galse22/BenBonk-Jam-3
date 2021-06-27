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
    void OnEnable()
    {
        transformPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        aIDestinationSettler.target = transformPlayer;
        StartCoroutine("NullifyCoroutine");
    }

    private void OnDisable() {
        aIDestinationSettler.target = transformPlayer;
        StopAllCoroutines();
    }

    IEnumerator NullifyCoroutine()
    {
        yield return new WaitForSeconds(timeBtwNullF);
        aIDestinationSettler.target = null;
        yield return new WaitForSeconds(timeToSet);
        aIDestinationSettler.target = transformPlayer;
        StartCoroutine("NullifyCoroutine");
    }
}
