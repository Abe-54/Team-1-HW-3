using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimationLogic : MonoBehaviour
{
    public bool isMoving = false;
    public bool isWaving = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWaving", isWaving);
    }

    public void SetIsWaving(bool isWaving)
    {
        this.isWaving = isWaving;
    }
}
