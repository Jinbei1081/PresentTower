using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDChara : MonoBehaviour {


    public float power = 1;
    bool canJump;

    new Rigidbody2D rigidbody;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.up * power, ForceMode2D.Impulse);
        canJump = false;
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            rigidbody.AddForce(Vector3.up * power, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
