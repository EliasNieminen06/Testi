using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    public Image image;
    public bool fadeIn;
    public bool fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponentInChildren<Image>();
        fadeIn = false;
        fadeOut = false;
    }

    public void Update()
    {
        if (fadeIn)
        {
            StartCoroutine(FadeIn());
            fadeIn = false;
        }
        if (fadeOut)
        {
            StartCoroutine(FadeOut());
            fadeOut = false;
        }
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
    IEnumerator FadeOut()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
