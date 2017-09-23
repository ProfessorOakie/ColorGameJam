using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 1;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        PlayerList.AddPlayerToTrackable(this);
	}
	
	void Update () {
        Movement();
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
}
