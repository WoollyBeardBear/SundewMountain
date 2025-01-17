using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class OnScreenMessage
{
    public GameObject go;
    [SerializeField] public float timeToLive = 2f;

    public OnScreenMessage(GameObject go)
    {
        this.go = go;
    }
}
public class OnScreenMessageSystem : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    private List<OnScreenMessage> _onScreenMessages;
    private List<OnScreenMessage> _openList;
    [SerializeField] public float timeToLive = 2f;
    
    [SerializeField] private float horizontalScatter = 0.25f;
    [SerializeField] private float verticalScatter = 0.5f;


    private void Awake()
    {
        _onScreenMessages = new List<OnScreenMessage>();
        _openList = new List<OnScreenMessage>();
    }

    public void Update()
    {
        for(int i = _onScreenMessages.Count - 1; i >= 0; i--) 
        {
            _onScreenMessages[i].timeToLive -= Time.deltaTime;
            if (_onScreenMessages[i].timeToLive < 0)
            {
                _onScreenMessages[i].go.SetActive(false);
                
                _openList.Add(_onScreenMessages[i]);
                
                _onScreenMessages.RemoveAt(i);
            }
        }
    }

    public void PostMessage(Vector3 worldPosition, string message)
    {
        worldPosition.z = -1f;
        worldPosition.x += Random.Range(-horizontalScatter, horizontalScatter);
        worldPosition.y += Random.Range(-verticalScatter, verticalScatter);
            
        if (_openList.Count > 0)
        {
            ReuseObjectFromOpenList(worldPosition, message);
        }
        else
        {
            CreateNewOnScreenMessageObject(worldPosition, message);
        }
    }

    private void ReuseObjectFromOpenList(Vector3 worldPosition, string message)
    {
        OnScreenMessage osm = _openList[0];
        osm.go.SetActive(true);
        osm.timeToLive = timeToLive;
        osm.go.GetComponent<TextMeshPro>().text = message;
        osm.go.transform.position = worldPosition;
        _openList.RemoveAt(0);
        _onScreenMessages.Add(osm);
    }

    private void CreateNewOnScreenMessageObject(Vector3 worldPosition, string message)
    {
        worldPosition.z = -1f;

        GameObject textGo = Instantiate(textPrefab, transform);
        textGo.transform.position = worldPosition;

        TextMeshPro tmp = textGo.GetComponent<TextMeshPro>();
        tmp.text = message;

        OnScreenMessage onScreenMessage = new OnScreenMessage(textGo);
        onScreenMessage.timeToLive = timeToLive;
        _onScreenMessages.Add(onScreenMessage);
    }
    
}
