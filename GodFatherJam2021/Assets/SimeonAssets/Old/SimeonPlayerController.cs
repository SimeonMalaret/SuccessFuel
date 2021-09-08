using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimeonPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    private Rigidbody _rigidbody;

    private float horizontal = 0f;
    private float vertical = 0f;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector3 origin = Vector3.zero;

        Quaternion horizontalQuaternion = Quaternion.AngleAxis(-horizontal, Vector3.up);
        Quaternion verticalQuaternion = Quaternion.AngleAxis(vertical, Vector3.right);

        Quaternion q = horizontalQuaternion * verticalQuaternion;

        _rigidbody.MovePosition(q * (_rigidbody.transform.position - origin) + origin);
        transform.LookAt(Vector3.zero);
    }
}
