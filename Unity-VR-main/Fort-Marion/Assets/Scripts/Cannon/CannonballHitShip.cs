using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion.Cannon;
using UnityEngine;

public class CannonballHitShip : MonoBehaviour
{
    
    [SerializeField] private GameObject shipGameObject;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject collidersGameObject;
    

    private Animator animator;
    private static readonly int IsSunk = Animator.StringToHash("isSunk");

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.collider;
        if (!other.CompareTag("Cannonball")) return;
        
        // Disable colliders
        collidersGameObject.SetActive(false);
        
        var cannonball = other.gameObject;
        Vector3 pointOfImpact = cannonball.transform.position;
        Instantiate(explosionEffect, pointOfImpact, Quaternion.identity);
        Destroy(cannonball);
        animator.SetBool(IsSunk, true);
    }
}