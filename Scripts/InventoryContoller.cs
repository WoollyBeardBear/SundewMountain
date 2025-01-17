using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryContoller : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public InputAction inventory;
    [SerializeField] private GameObject toolbarPanel;

    private void Start()
    {
        inventory.Enable();
    }

    private void Awake()
    {
        inventory = InputSystem.actions.FindAction("Inventory");
    }
    void Update()
    {
        if (inventory.triggered)
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
}
