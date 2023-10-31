using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image inventorySlot;
    public Image item;

    public void ShowDialog()
    {
        Debug.Log("Showing dialog");
        text.gameObject.SetActive(true);
    }

    public void HideDialog()
    {
        text.gameObject.SetActive(false);
    }

    public void ChangeLineTo(string newtext)
    {
        text.text = newtext;
    }

    public void UpdateInventoryUI(Sprite sprite, Vector3 rotation)
    {
        item.gameObject.SetActive(true);
        item.sprite = sprite;
        item.rectTransform.rotation = Quaternion.Euler(rotation);
    }

    public void RemoveKeyUI()
    {
        item.sprite = null;
        item.gameObject.SetActive(false);
    }

    public void ShowInteractionPrompt()
    {
        ChangeLineTo("Press Space to interact");
        ShowDialog();
    }
}
