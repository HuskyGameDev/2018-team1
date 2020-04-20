using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public Text continueText;

    public CanvasGroup uiElement;

    public void RunCredits()
    {
        PersistentData.changeScene(SceneManager.GetActiveScene().name, "Credits");
    }

    public void RunCreditsFromLevel()
    {
        PersistentData.UnlockData |= 32;
        PersistentData.changeScene(SceneManager.GetActiveScene().name, "Credits");
    }

    void Start()
    {
        if ( continueText != null )
        {
            continueText.enabled = false;
        }
    }

    void Update()
    {
        if ( continueText != null )
        {
            if (Time.timeSinceLevelLoad > 1f)
            {
                if (continueText.isActiveAndEnabled == false)
                {
                    continueText.enabled = true;
                    FadeIn();
                }
            }
            if (Time.timeSinceLevelLoad > 2f)
            {
                if (Input.anyKey)
                {
                    if ( PersistentData.lastScene == "StartMenu")
                    {
                        PersistentData.changeScene("Credits", "StartMenu");
                    }
                    else
                    {
                        PersistentData.changeScene("Credits", "Overworld");
                    }
                }
            }
        }
    }

    void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, 0, 1));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float lerpTime = 1f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            canvasGroup.alpha = currentValue;

            if (percentageComplete >= 1)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
