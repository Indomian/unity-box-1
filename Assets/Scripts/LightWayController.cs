using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWayController : Activable
{
    private Renderer _renderer;
    private Material _mat;

    public Texture activeEmissionTexture;
    public Texture inactiveEmissionTexture;

    public override void activate() {
        if (_mat) {
            _mat.SetTexture("_EmissionMap", activeEmissionTexture);
        }
        base.activate();
    }

    public override void deactivate() {
        if (_mat) {
            _mat.SetTexture("_EmissionMap", inactiveEmissionTexture);
        }
        base.deactivate();
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer> ();
        _mat = _renderer.material;
        if (_active) {
            activate();
        } else {
            deactivate();
        }
    }
}
