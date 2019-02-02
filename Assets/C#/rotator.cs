using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    Rigidbody2D RG;

    void Start ()
    {
        RG = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 Velocity = RG.velocity;

        float angle = Mathf.Atan2(Velocity.y, Velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
