﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 1;
    private Rigidbody2D rb;
    [SerializeField]
    private float damage = 1;
	[SerializeField]
	private AudioSource source;


    
    private void Start()
    {
		source = GetComponent<AudioSource> ();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        LookAtPlayer();
        MoveForward();
    }

    private void MoveForward()
    {
        rb.velocity = transform.right * MoveSpeed;
    }

    private void LookAtPlayer()
    {
        Player p = GetClosestPlayer();
        if (p)
        {
            Vector3 ZtoP = p.transform.position - transform.position;
            transform.right = ZtoP;
        }
    }

    private Player GetClosestPlayer()
    {
        Player[] Players = PlayerList.Instance.GetPlayers();
        if (Players.Length == 0) return null;
        float closest = -1;
        int index = -1;
        for(int i = 0; i < Players.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, Players[i].transform.position);
            if (closest == -1 || closest > dist)
            {
                closest = dist;
                index = i;
            }
        }
        return Players[index];
    }


    private void Collide(GameObject g)
    {
        if (g.CompareTag("Player"))
        {
            Health h = g.GetComponent<Health>();
            if (h) h.TakeDamage(damage);
			Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collide(collision.collider.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Collide(collider.gameObject);
    }
}
