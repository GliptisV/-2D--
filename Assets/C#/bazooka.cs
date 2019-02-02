using UnityEngine;
using System.Collections;

public class bazooka : MonoBehaviour
{
    public float min, max;


    private Control dirOfChar;

    void Start ()
    {
        dirOfChar = GetComponentInParent<Control>();
    }

    void FixedUpdate()
    {

        Vector3 MousePos = Input.mousePosition;
        Vector3 MyPos = Camera.main.WorldToScreenPoint(transform.position);

        if (dirOfChar.IsForward)
            MousePos = MousePos - MyPos;
        else
            MousePos = MyPos - MousePos;

        float angle = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, min, max);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        
        
        
    }




}
