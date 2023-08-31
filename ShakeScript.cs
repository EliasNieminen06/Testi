using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool startShake;
    public AnimationCurve curve;
    public float duration;

    private void Start()
    {
        startShake = false;
        duration = 1f;
    }

    void Update()
    {
        if (startShake)
        {
            startShake = false;
            StartCoroutine(shake());
        }
    }

    IEnumerator shake()
    {
        Vector3 startPos = transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float strength = curve.Evaluate(timeElapsed / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }
}
