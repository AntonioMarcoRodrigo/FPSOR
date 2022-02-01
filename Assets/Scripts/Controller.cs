using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera cam;
    public float impactForce;
    
    void OnAction()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit)
        {
            if (hit.rigidbody != null)
            {
                Debug.Log("yes");
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            else
            {
                Debug.Log("no");
            }               
        }
    }
}