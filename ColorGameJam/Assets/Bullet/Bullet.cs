using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float damage = 1;

    private Color bulletColor;

    private Rigidbody2D rb;
    

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector2 vec = transform.right;
        vec *= moveSpeed;
        rb.velocity = vec;
	}

    public void SetColor(Color c)
    {
        bulletColor = c;
    }

    private void Collide(GameObject g)
    {
        if (g.CompareTag("Shredder")) return;
        Health h = g.GetComponent<Health>();
        if(h) h.TakeDamage(damage, bulletColor);
        Destroy(gameObject);
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
