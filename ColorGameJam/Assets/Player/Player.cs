using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float MoveSpeed = 1;
	[SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float TimeBetweenShots = 0.02f;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.parent = PlayerList.Instance.transform;
	}
	
	void Update () {
        Movement();
        Shooting();
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

	private void Shooting()
    {

        if(Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
        {

        }

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, 1000))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.z = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            GameObject g = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, newRotation, 0);
            g.transform.right = playerToMouse;

            
        }
    }
}
	