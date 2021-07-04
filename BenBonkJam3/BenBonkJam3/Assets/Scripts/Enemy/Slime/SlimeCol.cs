using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SlimeCol : MonoBehaviour
{
    public float magnitude;
    public float sIntensity;
    public float sTime;
    MoreFunc moreFunc;
    Transform transformPlayer;
    public float stunnedTime;
    public AIDestinationSetter aIDestinationSettler;
    public TimeBetweenNull timeBetweenNull;
    public GameObject circleA;
    Vector3 v3;

    public float timeKnock;
    GameObject stored;

    public WizScript wizScipt;

    private void OnEnable() {
        moreFunc = GameObject.FindWithTag("GameManager").GetComponent<MoreFunc>();
        transformPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if(timeBetweenNull == null)
        {
            aIDestinationSettler.target = transformPlayer;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NorthPole")
        {
            var force = transform.position - col.transform.position;
            GetComponent<Rigidbody2D> ().AddForce (-force * magnitude * -5000);
            if(timeBetweenNull != null)
            {
                timeBetweenNull.checkThat();
                timeBetweenNull.stunned = true;
                timeBetweenNull.v3 = Vector3.zero;
                CancelInvoke("TimeNullFunc");
                CancelInvoke("TimeNF");
                Invoke("TimeNullFunc", stunnedTime);
                Invoke("TimeNF", timeKnock);
            }
            else
            {
                CancelInvoke("InvF");
                CancelInvoke("InvF2");
                aIDestinationSettler.target = null;
                wizScipt.stunned = true;
                Invoke("InvF", stunnedTime);
                Invoke("InvF2", stunnedTime + 0.2f);
                circleA.SetActive(true);
                Animator anim = circleA.GetComponent<Animator>();
                anim.SetBool("start", false);
                anim.SetBool("start", true);
            }
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
            moreFunc.RandomMagnetPSfx();
        }
    }

    void InvF()
    {
        aIDestinationSettler.target = transformPlayer;
        circleA.SetActive(false);
    }

    void InvF2()
    {
        wizScipt.stunned = false;
    }

    void TimeNullFunc()
    {
        timeBetweenNull.StunFunc();
    }

    void TimeNF()
    {
        v3 = transform.position;
        timeBetweenNull.v3 = v3;
    }
}
