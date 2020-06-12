using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    void OnTriggerEnter (Collider col)
    {
        Debug.Log("Collision: " + col.name);
        if(col.name == "Cube")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
