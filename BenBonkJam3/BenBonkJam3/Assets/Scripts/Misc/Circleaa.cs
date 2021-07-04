using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circleaa : MonoBehaviour
{
    public Animator animator;
    private void OnEnable() {
        animator.SetBool("start", true);
    }

    private void OnDisable() {
        animator.SetBool("start", false);
    }
}
