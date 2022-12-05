using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardDisplay : MonoBehaviour
{
    public Card card; //Referencia a scriptable object

    
    public TextMeshProUGUI manaText;

    public Image artWorkImage;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;

     void Start()
    {
        artWorkImage.sprite = card.artWork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
    }
}
