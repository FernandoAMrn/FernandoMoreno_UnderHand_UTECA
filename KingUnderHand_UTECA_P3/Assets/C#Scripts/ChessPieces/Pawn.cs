using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Pawn : MonoBehaviour
{
    [SerializeField] private float range;
    public int health;

    public TextMeshProUGUI healthText;
    
    

    public Draggable_W draggable;
    public Draggable_W draggable2;
    public Draggable_W draggable3;
    public Draggable_W draggable4;
    public Draggable_W draggable5;
    public Draggable_W draggable6;
    public W_King whiteKing;


    private void Start()
    {
        health = 1;
        
    }

    
    private void Update()
    {
        healthText.text = health.ToString();
        if (Vector2.Distance(draggable.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable.isWhiteTurn == true)
        {
            health -= 1;
        }
        if (Vector2.Distance(draggable2.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable2.isWhiteTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(draggable3.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable3.isWhiteTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(draggable4.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable4.isWhiteTurn == true)
        {
            health -= 3;
        }
        if (Vector2.Distance(draggable5.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable5.isWhiteTurn == true)
        {
            health -= 5;
        }
        if (Vector2.Distance(draggable6.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable6.isWhiteTurn == true)
        {
            health -= 1;
        }
        if (Vector2.Distance(transform.position, whiteKing.transform.position ) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health += 1;
        }


        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }

    
}
