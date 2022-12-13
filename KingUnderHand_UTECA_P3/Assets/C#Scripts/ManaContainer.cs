using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaContainer : MonoBehaviour  //BLACK TEAM MANA
{
    public Draggable draggable;
    public Draggable draggable2;
    public Draggable draggable3;
    public Draggable draggable4;
    public Draggable draggable5;
    public Draggable draggable6;

    public float mana =10;
    public int currentMana;
    public TMP_Text manaText;

    // Start is called before the first frame update
    public void Start()
    {
        mana = 10;
                
    }

    // Update is called once per frame
    void Update()
    {
        
        manaText.text = mana.ToString();
        

        if (draggable.isMoving == true) 
        {
            mana -= 0.01f;
        }
        if(draggable2.isMoving == true)
        {
            mana -= 0.03f; 
        }
        if (draggable3.isMoving == true)
        {
            mana -= 0.03f;
        }
        if (draggable4.isMoving == true)
        {
            mana -= 0.04f;
        }
        if (draggable5.isMoving == true)
        {
            mana -= 0.05f;
        }
        if (draggable6.isMoving == true)
        {
            mana -= 0.01f;
        }
    }


    public void reseetMana()
    {
        mana = 10;
    }

}
