using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
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
        float turn = Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical");

        Vector3 pushDir = new Vector3(body.transform.forward.x, 0, body.transform.forward.z);

        body.AddRelativeForce(Vector3.forward * speed * forwardForce, ForceMode.Force);
        body.AddRelativeTorque(Vector3.up * torque * turn);
    }

    // Called once per time delta, this one is realtime processing
    protected void FixedUpdate()
    {
        
    }
}
