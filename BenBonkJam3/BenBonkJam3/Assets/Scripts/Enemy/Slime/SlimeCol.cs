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
            GetComponent<Rigidbody2D> ().AddForce (-force * magnitude * -1000);
            if(timeBetweenNull != null)
            {
                timeBetweenNull.checkThat();
                timeBetweenNull.stunned = true;
                CancelInvoke("TimeNullFunc");
                Invoke("TimeNullFunc", stunnedTime);
            }
            else
            {
                CancelInvoke("InvF");
                aIDestinationSettler.target = null;
                Invoke("InvF", stunnedTime);
            }
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
            moreFunc.RandomMagnetPSfx();
        }
    }

    void InvF()
    {
        aIDestinationSettler.target = transformPlayer;
    }

    void TimeNullFunc()
    {
        timeBetweenNull.StunFunc();
    }
}
