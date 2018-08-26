using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravity : MonoBehaviour {
    public FauxGravityAttractor Attractor;
    private Rigidbody rigidbody;
    private Transform planetTransform;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // rigidbody.constraints = RigidbodyConstraints.FreezeRotation;  // Not Working
        rigidbody.useGravity = false;
        planetTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attractor.Attract(planetTransform);
    }
}
