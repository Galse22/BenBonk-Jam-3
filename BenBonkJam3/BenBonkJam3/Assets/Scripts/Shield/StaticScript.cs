using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject thisGO;
    Vector3 defaultPos;

    void Start()
    {
        defaultPos.Set(0, 0, 0);
        thisGO = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        thisGO.transform.localPosition = defaultPos;
    }
}
