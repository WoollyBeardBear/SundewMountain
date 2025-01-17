using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 4f;
    [SerializeField] float pickUpDistance = 1.3f;
    // "Time to Live" 
    [SerializeField] float ttl = 10f;
    [SerializeField] private Vector3 woodScale;

    public Item item;
    public int count = 1;
    

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
        if (item.name == "Wood")
        {
            transform.localScale = woodScale;
            Debug.Log("wood scale cahnge!");
        }
    }
    private void Update()
    {    
        ttl -= Time.deltaTime;
        if (ttl < 0) 
        { 
            Destroy(gameObject);
        }
        
        
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime);
        
        if (distance < 0.1f)
        {
            //GameManager.AddWood();
            // *TOD0* Should be moved into specified controller rather than being checked here./
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.Log("no inventory container attached to the game manager");
            }
            Destroy(gameObject);
        }
            
        
    
        
    }
}
