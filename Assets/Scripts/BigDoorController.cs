using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorController : Activable
{
    public GameObject door;
    public bool initialOpen;
    private Animator doorAnimator;

    public override void activate() {
        if (doorAnimator) {
            doorAnimator.SetBool("isOpened", true);
        }
        base.activate();
    }

    public override void deactivate() {
        if (doorAnimator) {
            doorAnimator.SetBool("isOpened", false);
        }
        base.deactivate();
    }

    // Start is called before the first frame update
    public override void Start()
    { 
        doorAnimator = door.GetComponent<Animator>();
        _active = initialOpen;
        base.Start(); 
    }
}
