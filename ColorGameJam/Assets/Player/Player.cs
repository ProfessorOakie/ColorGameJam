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
    [SerializeField]
    private GameObject bulletPrefab;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
		CurrentHealth = StartingHealth;
	
=======
        PlayerList.AddPlayerToTrackable(this);
>>>>>>> 4afad1434ab4b23a6a1a5e16624798a319c2e50d
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
        Shooting();
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

    private void Shooting()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    }
}
	