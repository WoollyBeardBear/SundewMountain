using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int health;
    public int damage;
    public Sprite sprite;
    
}
