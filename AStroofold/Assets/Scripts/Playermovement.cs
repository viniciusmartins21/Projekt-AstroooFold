using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Rigidbody rb;
    public float forceMovement;
    public int velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //força de impulso para levar a nave para FRENTE;
        rb.AddForce(0, 0, velocity * Time.fixedDeltaTime);


        //força de impulso para levar a nave para os LADOS;
        if (Input.GetKey ("a") == true)
        {
            rb.AddForce(-forceMovement * Time.fixedDeltaTime, 0, 0);
        }
        if (Input.GetKey ("d") == true)
        {
            rb.AddForce(forceMovement * Time.fixedDeltaTime, 0, 0);
        }
        
    }
}
