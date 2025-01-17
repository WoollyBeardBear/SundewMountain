using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] private int dropCount;
    [SerializeField] float spread = 0.7f;
    [SerializeField] GameObject pickUpDrop;


    [SerializeField] List<Item> _items;

    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
            for (int i =0; i < _items.Count; i++)
            {
                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;
                ItemSpawnManager.instance.SpawnItem(position, _items[i], 1);
                
            }
        }
    }
}
