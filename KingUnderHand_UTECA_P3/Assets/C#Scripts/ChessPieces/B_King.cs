using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class B_King : MonoBehaviour
{

    [SerializeField] private float range;
    public float health;
    public int maxHealth;
    public TextMeshProUGUI healthText;

    public GameObject panel;

    public Draggable_W draggable;
    public Draggable_W draggable2;
    public Draggable_W draggable3;
    public Draggable_W draggable4;
    public Draggable_W draggable5;
    public Draggable_W draggable6;

    




    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
        panel.SetActive(false);
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();

        if (Vector2.Distance(transform.position, draggable.transform.position) < range && Input.GetKeyUp(KeyCode.Space) &&draggable.isWhiteTurn == true)
        {
            health -= 1;
        }
        if (Vector2.Distance(transform.position, draggable2.transform.position) < range && Input.GetKeyUp(KeyCode.Space) &&draggable2.isWhiteTurn == true)  
        {
            health -= 2;
        }
        if (Vector2.Distance(transform.position, draggable3.transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable3.isWhiteTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(transform.position, draggable4.transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable4.isWhiteTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(transform.position, draggable5.transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable5.isWhiteTurn == true)
        {
            health -= 5;
        }
        if (Vector2.Distance(transform.position, draggable6.transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable6.isWhiteTurn == true)
        {
            health -= 1;
        }

        if (health <= 0)
        {
            panel.SetActive(true);
            
        }
    }

}
