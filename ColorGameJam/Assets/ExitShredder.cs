using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShredder : MonoBehaviour {

    private void Exit(GameObject g)
    {
        Destroy(g);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Exit(collision.collider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Exit(collider.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Exit(collision.collider.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        Exit(other.gameObject);
    }
}
