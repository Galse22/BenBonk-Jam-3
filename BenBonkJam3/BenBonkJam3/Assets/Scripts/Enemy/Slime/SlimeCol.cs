using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCol : MonoBehaviour
{
    public float magnitude;
    public float sIntensity;
    public float sTime;
    MoreFunc moreFunc;

    private void OnEnable() {
        moreFunc = GameObject.FindWithTag("GameManager").GetComponent<MoreFunc>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NorthPole")
        {
            var force = transform.position - col.transform.position;
            GetComponent<Rigidbody2D> ().AddForce (-force * magnitude * -1000);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
            moreFunc.RandomMagnetPSfx();
        }
    }
}
