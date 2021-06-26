using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCol : MonoBehaviour
{
    public float magnitude;
    public float sIntensity;
    public float sTime;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NorthPole")
        {
            var force = transform.position - col.transform.position;
            GetComponent<Rigidbody2D> ().AddForce (-force * magnitude * -1000);
            CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        // // Calculate Angle Between the collision point and the player
        //     Vector3 dir = c.contacts[0].point - transform.position;
        // // We then get the opposite (-Vector3) and normalize it
        //     dir = -dir.normalized;
        // // And finally we add force in the direction of dir and multiply it by force. 
        // // This will push back the player
        //     GetComponent<Rigidbody2D>().AddForce(dir*force);
        }
    }
}
