using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    private bool grounded;

    public bool isGrounded() => grounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
            grounded = false;
    }
}
