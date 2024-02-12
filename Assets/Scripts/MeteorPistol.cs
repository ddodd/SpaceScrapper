using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10f;
    bool isShooting = false;

    void Start()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    private void StartShoot()
    {
        particles.Play();
        isShooting = true;
    }

    private void StopShoot()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        isShooting = false;
    }



    void Update()
    {
        if(isShooting)
        {
            RaycastCheck();
        }
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);
        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
