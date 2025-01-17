using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;

    }
    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController dragAndDropController;
    public ItemSpawnManager ItemSpawnManager;
    public OnScreenMessageSystem messageSystem;
    public DayTimeController TimeController;
    public DialogueSystem dialogueSystem;

}
