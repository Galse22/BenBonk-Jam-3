using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthPoleScript : MonoBehaviour
{
    public Transform circle;
    public List<GameObject> goList;
    public List<Transform> transformList;
    int valList;
    Vector2 direction;
    public float bulletFORCE;

    public Transform transformPlayer;

    public float sIntensityLanded;
    public float sTimeLanded;

    public float sIntensitySHOT;
    public float sTimeSHOT;

    public GameObject catchBulletSFX;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BulletOne")
        {
            BulletOne bulletOne = col.gameObject.GetComponent<BulletOne>();
            if(!goList.Contains(col.gameObject) && bulletOne.damageEnabled == true)
            {
                bulletOne.damageEnabled = false;

                DestroyOnWall destroyOnWall = col.gameObject.GetComponent<DestroyOnWall>();
                destroyOnWall.destroyOnWallBool = false;

                Rigidbody2D bulletRB = col.gameObject.GetComponent<Rigidbody2D>();
                bulletRB.velocity = Vector2.zero;
                
                col.gameObject.tag = "Untagged";

                goList.Add(col.gameObject);
                Transform newTransform = new GameObject().transform;
                newTransform.position = col.gameObject.transform.position;
                transformList.Add(newTransform);
                newTransform.SetParent(circle);
                CinemachineShake.Instance.ShakeCamera (sIntensityLanded, sTimeLanded);
                GameObject goInstantiated = Instantiate(catchBulletSFX, transform.position, Quaternion.identity);
                goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            }
        }
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach(GameObject go in goList)
            {
                direction = (go.transform.position - transformPlayer.position).normalized;
                go.GetComponent<Rigidbody2D>().AddForce(direction * bulletFORCE * 10);

                BulletOne bulletOne = go.GetComponent<BulletOne>();
                bulletOne.damageEnemies = true;

                DestroyOnWall destroyOnWall = go.GetComponent<DestroyOnWall>();
                destroyOnWall.destroyOnWallBool = true;
            }
            goList.Clear();
            transformList.Clear();
            CinemachineShake.Instance.ShakeCamera (sIntensitySHOT, sTimeSHOT); 
        }
    }

    private void FixedUpdate() {
        valList = 0;
        foreach(GameObject go in goList)
        {
            go.transform.position = transformList[valList].position;
            valList++;
        }
    }
}
