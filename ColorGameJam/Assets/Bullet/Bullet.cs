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
        Vector2 vec = transform.forward;
        vec *= moveSpeed;
        rb.velocity = vec;
	}

    public void SetColor(Color c)
    {
        bulletColor = c;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage, bulletColor);
        Destroy(gameObject);
    }

}
