using System;

using UnityEngine;


public class ToolBarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 10;
    private int selectedTool;

    public Action<int> onChange;

    public Item GetItem
    {
        get
        {
            return GameManager.instance.inventoryContainer.slots[selectedTool].item;
        }
    }
    
    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = (selectedTool >= toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool -= 1;
                selectedTool = (selectedTool <= 0 ? toolbarSize - 1 : selectedTool);
            }

            onChange?.Invoke(selectedTool);
        }
    }

    public void potionChange()
    {
        int newPotionCount = GameManager.instance.inventoryContainer.slots[selectedTool].count -= 1;


        if (newPotionCount <= 0)
        {
            GameManager.instance.inventoryContainer.slots[selectedTool].Clear();
        }
    }
    
    

    internal void Set(int id)
    {
        selectedTool = id;
    }
}
