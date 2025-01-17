using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnClicked : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPointPosition;
    [SerializeField] private string respawnPointScene;
    private DisableControls _disableControls;
    [SerializeField] public GameObject panel;
    

    public void RespawnButtonPressed()
    {
        CharacterController2d.instance.Respawn(respawnPointPosition);
        panel.SetActive(false);
        Character.instance.Respawn();

    }
}
