using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            cherriesText.text = "Score: " + fruits;
        }    
    }

}
