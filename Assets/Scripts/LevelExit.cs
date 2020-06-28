using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Activable
{    
    public Light redLight;
    public Light greenLight;
    public GameObject door;
    private Animator doorAnimator;
    public string nextLevel;

    public override void activate() {
        redLight.enabled = false;
        greenLight.enabled = true;
        if (doorAnimator) {
            doorAnimator.SetBool("isOpen", true);
        }
        base.activate();
    }

    public override void deactivate() {
        redLight.enabled = true;
        greenLight.enabled = false;
        if (doorAnimator) {
            doorAnimator.SetBool("isOpen", false);
        }
        base.deactivate();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        Debug.Log(doorAnimator);
        base.Start();
    }

    void OnTriggerEnter (Collider col)
    {
        Debug.Log("Someone entered exit: " + col.tag);
        if(_active && col.tag == "Player")
        {
            StartCoroutine(WaitAndLoadNext());
        }
    }

    IEnumerator WaitAndLoadNext() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(nextLevel);
    }
}
