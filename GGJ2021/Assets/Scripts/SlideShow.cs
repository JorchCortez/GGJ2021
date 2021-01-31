using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;

    public float fadeSpeedInSpeed = 2;
    public float fadeOutSpeed = 1;
    public float activeTime = 3.0f;

    public void Start(){
        image.sprite = null;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
       StartCoroutine(StartSlideShow());
    }

    IEnumerator StartSlideShow(){
        
        for(int i = 0; i < sprites.Count; i++){
            image.sprite = sprites[i];
            Color color = image.color;
            while(color.a < 1.0f){
                color.a += fadeSpeedInSpeed * Time.deltaTime;
                image.color = color;
                yield return new WaitForEndOfFrame();
            }
            color.a = 1.0f;
            image.color = color;
            yield return new WaitForSecondsRealtime(activeTime);
            while(color.a >= 0.0f){
                color.a -= fadeOutSpeed * Time.deltaTime;
                image.color = color;
                yield return new WaitForEndOfFrame();
            }
            color.a = 0.0f;
            image.color = color;
        }

        yield return null;
    }
}
