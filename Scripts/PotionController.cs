using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] private ItemSlot itemSlot;
    
    public void FullHeal()
    {
        Character.instance.FullHeal();
        
        
    }
    
}
