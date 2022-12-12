using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaContainer : MonoBehaviour
{
    public Text manaText;
    public Draggable draggable;

    public float mana =10;
    public float currentMana;
    public TMP_Text mnaext;

    // Start is called before the first frame update
    public void Start()
    {
        mana = 10;
        
    }

    // Update is called once per frame
    void Update()
   {

    //    if (draggable.isMoving == true)
    //    {
    //        Debug.Log("A card Is Moving");
    //        //mana--;
            
    //    }
    //    else
    //    {
    //        return;
    //    }
     mnaext.text = "" + Mathf.FloorToInt(mana);
    }


}
