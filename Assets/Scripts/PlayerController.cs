﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float forwardForce = 1;
    public float torque = 0.1f;

    protected Rigidbody body;

    protected virtual void OnEnable()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
    }

    // Update is called once per frame
    protected void Update()
    {
    }

    // Called once per time delta, this one is realtime processing
    protected void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical");

        body.AddForce(body.transform.forward * speed * forwardForce, ForceMode.Force);
        body.AddRelativeTorque(body.transform.up * torque * turn);
    }
}
