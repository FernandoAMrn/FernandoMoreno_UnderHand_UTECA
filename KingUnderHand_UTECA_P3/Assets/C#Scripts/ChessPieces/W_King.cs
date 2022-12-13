using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class W_King : MonoBehaviour
{
    
    [SerializeField] private float range;
    public float health;
    public int maxHealth;
    public TextMeshProUGUI healthText;

    public GameObject panel;

    public Draggable draggable;
    public Draggable draggable2;
    public Draggable draggable3;
    public Draggable draggable4;
    public Draggable draggable5;
    public Draggable draggable6;
    public bool isPressingButton;




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

        if (Vector2.Distance(transform.position, draggable.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 1;
        }
        if (Vector2.Distance(transform.position, draggable2.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 2;
        }
        if (Vector2.Distance(transform.position, draggable3.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 2; 
        }
        if (Vector2.Distance(transform.position, draggable4.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 3;
        }
        if (Vector2.Distance(transform.position, draggable5.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 5;
        }
        if (Vector2.Distance(transform.position, draggable6.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health -= 1;
        }

        if (health <= 0)
        {
            panel.SetActive(true);
        }
    }

}
