using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public Transform cam;
    
    public float sensitivityX;
    
    void Update()
    {
        UpdateAim();
        UpdateShoot();
    }

    void UpdateAim()
    {
        Quaternion deltaRotation = Quaternion.AngleAxis(Mouse.current.delta.x.ReadValue() * sensitivityX * Time.deltaTime, Vector3.up);
        cam.rotation = deltaRotation * cam.rotation;
    }
    
    void UpdateShoot()
    {
        RaycastHit hit;

        if (Mouse.current.leftButton.isPressed)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.Log("shot");
            }
        }
    }
}