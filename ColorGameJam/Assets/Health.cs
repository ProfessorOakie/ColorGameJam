using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Health : MonoBehaviour {

    [SerializeField]
    private float StartingHealth = 100;
    private float CurrentHealth;

    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip deathSound;
    private AudioSource asource;

    private void Start()
    {
        CurrentHealth = StartingHealth;
        asource = GetComponent<AudioSource>();
        if (!asource) asource = gameObject.AddComponent<AudioSource>();
        asource.loop = false;
    }

    public virtual void TakeDamage(float baseDamage, Player.ColorColor col, float colorCorrectDamage)
    {
        TakeDamage(baseDamage);
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth = CurrentHealth - amount;
        if (CurrentHealth <= 0)
        {
            Dead();
        }
        PlaySound(hurtSound);
    }

    private void Dead()
    {
        //print("I be ded");
        PlaySound(deathSound);
        Destroy(gameObject);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip && asource)
            asource.PlayOneShot(clip);
    }
}
