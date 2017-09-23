using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 1;
	[SerializeField]
	private float StartingHealth = 100;
	[SerializeField]
	private float CurrentHealth;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
		CurrentHealth = StartingHealth;
	
	}
	
	void Update () {
        Movement();
		if (Input.GetKeyDown (KeyCode.I)) {
			TakeDamage_Zombie (10);
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			TakeDamage_Bullet (5);
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			TakeDamage_BlackHole (15);
		}

	}

    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(h, v);
        vec.Normalize();
        vec *= MoveSpeed;
        rb.velocity = vec;
    }

	private void TakeDamage_Zombie (float amount)
	{
		CurrentHealth = CurrentHealth - amount;
		if (CurrentHealth <= 0)
		{
			Dead();
		}
			
	}

	private void TakeDamage_Bullet (float amount)
	{
		CurrentHealth = CurrentHealth - amount;
		if (CurrentHealth <= 0) 
		{
			Dead ();
		}
			
	}

	private void TakeDamage_BlackHole (float amount)
	{
		CurrentHealth = CurrentHealth - amount;
		if (CurrentHealth <= 0)
		{
			Dead ();
		}
	}
			
	private void Dead ()
	{
		print ("I be ded");
	
	}
}
	