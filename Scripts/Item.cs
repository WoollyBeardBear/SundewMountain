using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
    public bool isWeapon;
    public bool isPotion;
    public bool isTool;
    public int damage;
    public int healing;
}
