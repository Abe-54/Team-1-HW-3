using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerInteractionLogic : MonoBehaviour
{
    [Header("Player Components")]
    public BasicMovement movement;
    public PlayerInventoryLogic inventory;
    public UiController ui;

    [Header("Interaction Status")]
    public bool canInteract;

    [Header("Target Objects")]
    public KeyInteractable keyTarget;
    public DoorInteractable doorTarget;
    public InteractableObject objectTarget;

    [Header("Cutscene Configuration")]
    public bool[] cutscenePlayed;
    public int currentCutscene = 0;

    private float dialogDelay = 0.1f;
    private float inputDebounceTime = 0.2f;

    void Awake()
    {
        movement = GetComponent<BasicMovement>();
        inventory = GetComponent<PlayerInventoryLogic>();
        ui = FindObjectOfType<UiController>();
    }

    void Update()
    {
        HandleInteraction();
    }

    void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            if (keyTarget) StartKeyInteraction(keyTarget);
            else if (doorTarget) StartDoorInteraction(doorTarget);
            else if (objectTarget) StartBasicInteraction(objectTarget);
        }
    }

    void StartDoorInteraction(DoorInteractable target)
    {
        DisableMovement();
        if (inventory.HasKey(doorTarget.keyName))
        {
            inventory.RemoveKey(doorTarget.keyName);
            ui.RemoveKeyUI();
            target.gameObject.SetActive(false);
            StartCoroutine(ShowTextSequence(doorTarget.hasKeyText));
        }
        else
        {
            StartCoroutine(ShowTextSequence(target.interactText, () =>
            {
                PlayCutsceneIfAvailable(doorTarget.cutsceneDirector);
            }));
        }
    }

    void PlayCutsceneIfAvailable(PlayableDirector director)
    {
        if (director != null && !cutscenePlayed[currentCutscene])
        {
            DisableMovement();
            director.Play();
            StartCoroutine(WaitForCutscene(director));
        }
    }

    void StartBasicInteraction(InteractableObject target)
    {
        DisableMovement();
        StartCoroutine(ShowTextSequence(target.interactText));
    }

    void StartKeyInteraction(KeyInteractable target)
    {
        DisableMovement();
        inventory.AddKey(target.keyName);
        ui.UpdateKeyUI(target);
        target.gameObject.SetActive(false);
        StartCoroutine(ShowTextSequence(target.interactText));
    }

    IEnumerator ShowTextSequence(List<string> textList, Action onComplete = null)
    {
        DisableMovement();
        for (int i = 0; i < textList.Count; i++)
        {
            ui.ShowDialog();
            ui.ChangeLineTo(textList[i]);
            yield return new WaitForSeconds(dialogDelay);
            yield return WaitForUserInput(KeyCode.Space);
            yield return new WaitForSeconds(inputDebounceTime);
        }

        ui.HideDialog();
        EnableMovement();
        onComplete?.Invoke();
    }

    IEnumerator WaitForUserInput(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }
    }

    IEnumerator WaitForCutscene(PlayableDirector director)
    {
        yield return new WaitForSeconds((float)director.duration);
        director.enabled = false;
        cutscenePlayed[currentCutscene] = true;
        EnableMovement();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        keyTarget = col.GetComponent<KeyInteractable>();
        doorTarget = col.GetComponent<DoorInteractable>();
        objectTarget = col.GetComponent<InteractableObject>();

        if (keyTarget || doorTarget || objectTarget)
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<KeyInteractable>() || col.GetComponent<DoorInteractable>() || col.GetComponent<InteractableObject>())
        {
            keyTarget = null;
            doorTarget = null;
            objectTarget = null;
            canInteract = false;
            ui.HideDialog();
        }
    }

    void DisableMovement()
    {
        movement.canMove = false;
        canInteract = false;
        movement.myRigidbody2d.velocity = Vector2.zero;
    }

    void EnableMovement()
    {
        movement.canMove = true;
    }
}
