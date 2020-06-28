using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : Activable
{
    public GameObject bridge;
    public bool initialDown;
    private Animator bridgeAnimator;

    public override void activate() {
        if (bridgeAnimator) {
            bridgeAnimator.SetBool("isOpened", true);
        }
        base.activate();
    }

    public override void deactivate() {
        if (bridgeAnimator) {
            bridgeAnimator.SetBool("isOpened", false);
        }
        base.deactivate();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        bridgeAnimator = bridge.GetComponent<Animator>();
        _active = initialDown;
        base.Start();
    }
}
