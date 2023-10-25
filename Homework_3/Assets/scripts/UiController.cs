using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void UpdateKeyUI(KeyInteractable key)
    {
        item.gameObject.SetActive(true);
        item.sprite = key.GetComponent<SpriteRenderer>().sprite;
    }

    public void RemoveKeyUI()
    {
        item.sprite = null;
        item.gameObject.SetActive(false);
    }
}
