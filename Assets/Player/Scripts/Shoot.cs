using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform fpsCamera;
    [SerializeField] private float range;
    [SerializeField] private float forcePower;

    private void Update()
    {
        RaycastHit hit;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(fpsCamera.position, fpsCamera.TransformDirection(Vector3.forward), out hit, range))
            {
                if (hit.rigidbody)
                {
                    Vector3 force = hit.point - fpsCamera.position;
                    hit.rigidbody.AddForceAtPosition(force.normalized * forcePower, hit.point);
                }
            }
        }
    }
}