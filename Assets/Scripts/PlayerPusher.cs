using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPusher : MonoBehaviour
{
    public Vector3 lastCollisionImpulse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        lastCollisionImpulse = collision.impulse;
    }

    void OnCollisionStay(Collision collision)
    {
        lastCollisionImpulse = collision.impulse;
    }

    void OnCollisionExit(Collision collision) 
    {
        lastCollisionImpulse = Vector3.zero;
    }
}
