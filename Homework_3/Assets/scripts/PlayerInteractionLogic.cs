using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionLogic : MonoBehaviour
{
    public bool canTalk;
    public InteractableObject targetObject;
    public BasicMovement movement;
    public UiController ui;

    private void Awake()
    {
        movement = GetComponent<BasicMovement>();
        ui = FindObjectOfType<UiController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (targetObject)
            {
                
                StartTalking(targetObject);
                ui.ShowDialog();
                ui.ChangeLineTo(targetObject.text[0]);
                targetObject = null;
            }
            else
            {
                ui.HideDialog();
                movement.canMove =  true;
            }
        }
    }


    void StartTalking(InteractableObject target)
    {
        movement.canMove = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<InteractableObject>())
        {
            targetObject = col.GetComponent<InteractableObject>();
            canTalk = true;
        }
    }
    
    
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<InteractableObject>())
        {
            targetObject = null;
            canTalk = false;
        }
    }
}
