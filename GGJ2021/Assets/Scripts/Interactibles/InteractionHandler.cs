using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    public bool IsEnabled = false;

    [SerializeField]
    SpriteRenderer coloredImage;
    [SerializeField]
    GameObject blueImage;
    AudioSource source;

    public int duration = 150;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void Colorize()
    {
        source.Play();
        StartCoroutine(ColorizeObject(duration));
    }

    IEnumerator ColorizeObject( float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration; 
            coloredImage.color += new Color(255, 255, 255, Mathf.Lerp(0, 1, normalizedTime));
            yield return null;
        } 
    }
}
