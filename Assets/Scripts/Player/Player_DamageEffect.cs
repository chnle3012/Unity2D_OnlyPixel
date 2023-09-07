using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color blinkColor = Color.white;
    [SerializeField] float blinkDuration;
    [SerializeField] float blinkInterval;

    private Color originalColor; 

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color; 
    }

    public void TakeDamage()
    {
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f;
        while (elapsedTime < blinkDuration)
        {
            sr.color = blinkColor; 
            yield return new WaitForSeconds(blinkInterval);
            sr.color = originalColor; 
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += Time.deltaTime;
        }
    }
}
