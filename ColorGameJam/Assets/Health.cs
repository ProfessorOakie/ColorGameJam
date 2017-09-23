using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float StartingHealth = 100;
    private float CurrentHealth;

    private void Start()
    {
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage(float amount, Color col)
    {
        CurrentHealth = CurrentHealth - amount;
        if (CurrentHealth <= 0)
        {
            Dead();
        }

    }

    private void Dead()
    {
        print("I be ded");
        Destroy(gameObject);
    }
}
