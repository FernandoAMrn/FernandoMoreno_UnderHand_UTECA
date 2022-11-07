using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName ="Cards")]
public class Cards : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite art;
    public int manaCost;
    public int health;
    public int attack;
}
