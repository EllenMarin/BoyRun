using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] Text coinsText;

    [SerializeField] AudioSource coinSound;

    int coins = 0;
     
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++; 
            coinsText.text = "Coins: " + coins;
            coinSound.Play();
        }
    }
}
