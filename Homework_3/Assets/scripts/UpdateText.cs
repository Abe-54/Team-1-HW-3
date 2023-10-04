using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public TMP_Text emilyText;
    
    public void NewText(string text)
    {
        emilyText.text = text;
    }
}
