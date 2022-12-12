using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSword : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeGravity()
    {
        rb.gravityScale *= -1;
    }
    
}
