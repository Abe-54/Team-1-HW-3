using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Image keySprite_1;
    public Sprite fullKeySprite_1;

    public void ShowDialog()
    {
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

    public void UpdateKeyUI()
    {
        keySprite_1.sprite = fullKeySprite_1;
        keySprite_1.color = new Color(keySprite_1.color.r, keySprite_1.color.g, keySprite_1.color.b);
    }
}
