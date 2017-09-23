using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5;

    private Rigidbody rb;
    

    void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 vec = transform.forward;
        vec *= moveSpeed;
        rb.velocity = vec;
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
