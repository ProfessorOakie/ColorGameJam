using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 1;
    private Rigidbody2D rb;

    
    private void Start()
    {
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
        Vector3 ZtoP = GetClosestPlayer().transform.position - transform.position;
        transform.right = ZtoP;
    }

    private Player GetClosestPlayer()
    {
        float closest = -1;
        int index = -1;
        for(int i = 0; i < PlayerList.GetPlayers().Count; i++)
        {
            float dist = Vector3.Distance(transform.position, PlayerList.GetPlayers()[i].transform.position);
            if (closest == -1 || closest > dist)
            {
                closest = dist;
                index = i;
            }
        }
        return PlayerList.GetPlayers()[index];
    }
}
