using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    
    float dropCount;
    [SerializeField] float spread = 0.7f;
    int chopCount = 0;
    
    [SerializeField] int maxChop = 2;
    [SerializeField] private Item item;

    public override void Hit()
    {
        Debug.Log("chopCount: " + chopCount);
        // Three chops to chop down the tree
        if(chopCount < maxChop)
        {
            chopCount += 1;
            Debug.Log("Chop count: " + chopCount.ToString());
        }
        else
        {
            
            dropCount = Random.value * 5 + 1;
            // After max chop count is reached, drop a random number of logs between 1 and 5 and spread them out. 
            while (dropCount > 0)
            {
                dropCount -= 1;

                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;
                ItemSpawnManager.instance.SpawnItem(position, item, 1);
                chopCount = 0;
                
            }
            Destroy(gameObject);
        }

    }

}
