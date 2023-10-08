using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerInteractionLogic : MonoBehaviour
{
    public bool canInteract;
    public BaseInteractable targetObject;
    public BasicMovement movement;
    public PlayerInventoryLogic inventory;
    public UiController ui;
    public bool[] cutscenePlayed;
    public int currentCutscene = 0;

    private void Awake()
    {
        movement = GetComponent<BasicMovement>();
        inventory = GetComponent<PlayerInventoryLogic>();
        ui = FindObjectOfType<UiController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (targetObject)
            {
                ui.ShowDialog();

                StartInteraction(targetObject);
            }
            else
            {
                ui.HideDialog();
                movement.canMove = true;
            }
        }
    }


    void StartInteraction(BaseInteractable target)
    {
        movement.canMove = false;

        switch (target.GetType().Name)
        {
            case nameof(KeyInteractable):
                inventory.AddKey(target.keyName);
                ui.UpdateKeyUI();
                target.gameObject.SetActive(false);
                StartCoroutine(ShowTextSequence(target.interactText, target));
                break;

            case nameof(DoorInteractable):
                DoorInteractable doorTarget = (DoorInteractable)target;
                Debug.Log("INTERACTING WITH DOOR");

                if (inventory.HasKey(target.keyName))
                {
                    Debug.Log("I HAVE THE KEY");
                    Debug.Log("KEYS: " + inventory.keys.ToArray().ToString());
                    doorTarget.gameObject.SetActive(false);

                    StartCoroutine(ShowTextSequence(doorTarget.hasKeyText, doorTarget));
                }
                else
                {
                    Debug.Log("I DO NOT HAVE THE KEY");

                    StartCoroutine(ShowTextSequence(doorTarget.interactText, doorTarget));
                }
                break;
        }

        targetObject = null;
    }

    IEnumerator ShowTextSequence(List<string> textList, BaseInteractable target)
    {
        int currentText = 0;

        while (currentText < textList.Count)
        {
            ui.ShowDialog();
            ui.ChangeLineTo(textList[currentText]);

            yield return new WaitForSeconds(0.1f);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            currentText++;
        }

        ui.HideDialog();


        if (target.GetType().Name == nameof(DoorInteractable))
        {
            DoorInteractable doorTarget = (DoorInteractable)target;
            if (doorTarget.cutsceneDirector != null && !cutscenePlayed[currentCutscene])
            {
                Debug.Log("PLAYING CUTSCENE");
                doorTarget.cutsceneDirector.Play();
                yield return new WaitForSeconds((float)doorTarget.cutsceneDirector.duration);
                doorTarget.cutsceneDirector.enabled = false;
                cutscenePlayed[currentCutscene] = true;
            }
        }


        movement.canMove = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BaseInteractable>())
        {
            targetObject = col.GetComponent<BaseInteractable>();
            canInteract = true;
        }
    }


    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<BaseInteractable>())
        {
            targetObject = null;
            canInteract = false;
        }
    }
}
