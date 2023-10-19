using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class CustsceneSignalsLogic : MonoBehaviour
{
    public TMP_Text uiText;

    public List<string> entranceTexts;
    public int currentTextIndex = 0;

    public PlayableDirector playableDirector;
    public bool isPaused = false;

    public BearAnimationLogic bearAnimationLogic;
    private void Update()
    {
        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            HideText();
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
            bearAnimationLogic.SetIsWaving(false);
            isPaused = false;
        }
    }

    public void NewText()
    {
        Debug.Log("NEW TEXT: " + entranceTexts[currentTextIndex]);
        uiText.text = entranceTexts[currentTextIndex++];
    }

    public void HideText()
    {
        uiText.text = "";
    }

    public void pauseCutscene()
    {
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
        isPaused = true;
    }
}
