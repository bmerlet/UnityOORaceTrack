using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : Vehicle
{
    // Override initial position
    protected override Vector3 InitialPosition => Vector3.up * 0.194f;
    protected override Quaternion InitialRotation => Quaternion.Euler(0, 90, 0);

    protected override Vector3 forwardVector => Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        ProcessCollision(other);
    }
}
