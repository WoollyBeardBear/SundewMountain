using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public int maxVal;
    public int currVal;

    public Stat(int curr, int max)
    {
        maxVal = max;
        currVal = curr;
    }

    internal void Subtract(int amount)
    {
        currVal -= amount;
    }

    internal void Add(int amount)
    {
        currVal += amount;

        if (currVal > maxVal) { currVal = maxVal; }
    }

    internal void SetToMax()
    {
        currVal = maxVal;
    }
}

public class Character : MonoBehaviour, IDamageable
{
    public Stat hp;
    [SerializeField] private StatusBar hpBar;

    public bool isDead;
    public bool isExhausted;

    private DisableControls _disableControls;
    private PlayerRespawn _playerRespawn;
    public static Character instance;
    [SerializeField] private GameObject panel;
    private AttackController _attackController;


    private void Awake()
    {
        
        _disableControls = GetComponent<DisableControls>();
        _playerRespawn = GetComponent<PlayerRespawn>();
        _attackController = GetComponent<AttackController>();
        instance = this;
    }

    private void Start()
    {
        hpBar.Set(hp.currVal, hp.maxVal);
    }
    
    
    public void TakeDamage(int amount)
    {
        if (isDead == true) { return; }
        hp.Subtract(amount);
        UpdateHpBar();
        if (hp.currVal <= 0)
        {
            IsDead();
        }
    }

    private void IsDead()
    {
        isDead = true;
        _disableControls.DisableControl();
        _playerRespawn.StartRespawn();

    }

    public void Respawn()
    {
        panel.SetActive(false);
        isDead = false;
        FullHeal();
        _disableControls.EnableControl();
    }

    private void UpdateHpBar()
    {
        hpBar.Set(hp.currVal, hp.maxVal);
    }

    public void Heal(int amount)
    {
        hp.Add(amount);
        UpdateHpBar();
    }

    public void FullHeal()
    {
        hp.SetToMax();
        UpdateHpBar();
    }
    
    

    public void CalculateDamage(ref int damage)
    {
        
    }

    public void ApplyDamage(int damage)
    {
        TakeDamage(damage);
    }

    public void CheckState()
    {
        
    }
}

