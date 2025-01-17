using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPointPosition;
    [SerializeField] private string respawnPointScene;
    private Character _character;
    private DisableControls _disableControls;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button respawnButton;
    

    public void StartRespawn()
    {
        panel.SetActive(true);
        
    }
}
