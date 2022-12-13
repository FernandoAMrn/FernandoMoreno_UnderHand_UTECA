using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class W_Pawn : MonoBehaviour
{
    [SerializeField] private float range;
    public int health;

    public TextMeshProUGUI healthText;

    public B_King blakcKing;

    public Draggable draggable;
    public Draggable draggable2;
    public Draggable draggable3;
    public Draggable draggable4;
    public Draggable draggable5;
    public Draggable draggable6;


    private void Start()
    {
        health = 1;

    }


    private void Update()
    {
        healthText.text = health.ToString();
        if (Vector2.Distance(draggable.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable.isBlackTurn == true)
        {
            health -= 1;
        }
        if (Vector2.Distance(draggable2.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable2.isBlackTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(draggable3.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable3.isBlackTurn == true)
        {
            health -= 2;
        }
        if (Vector2.Distance(draggable4.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable4.isBlackTurn == true)
        {
            health -= 3;
        }
        if (Vector2.Distance(draggable5.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable5.isBlackTurn == true)
        {
            health -= 5;
        }
        if (Vector2.Distance(draggable6.transform.position, transform.position) < range && Input.GetKeyUp(KeyCode.Space) && draggable6.isBlackTurn == true)
        {
            health -= 1;
        }
        if (Vector2.Distance(transform.position, blakcKing.transform.position) < range && Input.GetKeyUp(KeyCode.Space))
        {
            health += 1;
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }
}
