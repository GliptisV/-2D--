using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRay : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float Distance;

    private void FixedUpfate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Distance, mask);

        if(hit != false)
        {
            print(hit.collider.gameObject.name);
        }

        Debug.DrawRay(transform.position, Vector2.right * Distance, Color.red);




    }

}
