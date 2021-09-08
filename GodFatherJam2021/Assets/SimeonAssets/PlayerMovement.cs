using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float drunkRotationSpeed;

    private float drunkTimer = 0;
    public float maxTimer;

    // Update is called once per frame
    void Update()
    {
        //_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime * moveSpeed);

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);


        if (Input.GetKey(KeyCode.Q))
        {
            rotationSpeed = Mathf.Abs(rotationSpeed);
            drunkTimer = 0;
            transform.Rotate(new Vector3(0, -rotationSpeed, 0), Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed = Mathf.Abs(rotationSpeed);
            drunkTimer = 0;
            transform.Rotate(new Vector3(0, rotationSpeed, 0), Space.Self);
        }
        else
        {
            drunkTimer += Time.deltaTime;
            if (drunkTimer >= maxTimer)
            {
                drunkTimer = 0;
                drunkRotationSpeed = -drunkRotationSpeed;
            }
        }
        transform.Rotate(new Vector3(0, drunkRotationSpeed, 0), Space.Self);
    }

    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(_moveDirection) * moveSpeed * Time.deltaTime);
    }
}
