using System.Collections;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float slimeWait = 2f; // Set the wait time in seconds
    public float fadeDuration = 2f; // Set the duration of the fade in seconds
    private SpriteRenderer slimeRenderer;

    void Start()
    {
        slimeRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(SlimeFade());
    }

    IEnumerator SlimeFade()
    {
        yield return new WaitForSeconds(slimeWait);

        Color startColor = slimeRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            slimeRenderer.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is set
        slimeRenderer.color = endColor;
    }

    void Update()
    {
        // Any additional logic you want to put in the update method
    }
}
