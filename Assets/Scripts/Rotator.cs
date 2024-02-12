using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool rotating = true;
    public float speed;

    private void RotateThis()
    {
        transform.Rotate(speed * Time.deltaTime * Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            RotateThis();
        }
    }
}
