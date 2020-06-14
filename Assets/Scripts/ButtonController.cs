using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Activable control;

    void OnTriggerEnter (Collider col)
    {
        Debug.Log("Button down for: " + col.name);
        if(col.name == "Cube")
        {
            control.activate();
            // SceneManager.LoadScene("Level 2");
        }
    }

    void OnTriggerExit (Collider col)
    {
        Debug.Log("Button up for: " + col.name);
        if(col.name == "Cube")
        {
            control.deactivate();
            // SceneManager.LoadScene("Level 2");
        }
    }
}
