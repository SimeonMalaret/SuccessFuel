using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 50;
    public float testAngle;
    private Rigidbody rb;

    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //RotateAround(Vector3.zero, Vector3.right * horizontal * speed * Time.deltaTime, testAngle);
    }
     void FixedUpdate()
    {
        Vector3 origin = Vector3.zero;

        Quaternion hq = Quaternion.AngleAxis(-horizontal, Vector3.up);
        //Quaternion vq = Quaternion.AngleAxis(vertical, Vector3.right);

       // Quaternion q = hq * vq;

       // rb.MovePosition(q * (rb.transform.position- origin)+ origin);
        transform.LookAt(Vector3.zero);
    }
    //void RotateAround (Vector3 origin, Vector3 axis, float angle)
    //{
    //    Quaternion q = Quaternion.AngleAxis(angle, axis);
    //    rb.MovePosition(q * (rb.transform.position - origin) + origin);
    //    rb.MoveRotation(rb.transform.rotation * q);
    //}
}
