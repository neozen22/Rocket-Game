using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstalceMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;

    [SerializeField] float perioid = 2f;
    const float tau = Mathf.PI * 2;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (perioid <= Mathf.Epsilon) { return; } //Avoid NaN error
        float cycyles = Time.time / perioid;
        float rawSin = Mathf.Sin(cycyles * tau); 

        
        movementFactor = (rawSin + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
