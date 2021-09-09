using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float moveSpeed;
    public float rotationSpeed;

    [Header("Drunk Rotation")]
    public float drunkRotationSpeed;
    private float drunkTimer = 0;
    public float maxDrunkTimer;

    public GameObject obj3D;
    private float currentRot;
    public float speedRot = 3f;

    // Update is called once per frame
    void Update()
    {
        //_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime * moveSpeed);

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.Q))
        {
            drunkTimer = 0;
            transform.Rotate(new Vector3(0, -rotationSpeed, 0), Space.Self);

            if (currentRot < 20)
            {
                currentRot += Time.deltaTime * speedRot;
            }
            else
            {
                currentRot = 20;
            }
            obj3D.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRot));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            drunkTimer = 0;
            transform.Rotate(new Vector3(0, rotationSpeed, 0), Space.Self);

            if (currentRot > -20)
            {
                currentRot -= Time.deltaTime * speedRot;
            }
            else
            {
                currentRot = -20;
            }

            obj3D.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRot));
        }
        else
        {
            drunkTimer += Time.deltaTime * speedRot;
            if (drunkTimer >= maxDrunkTimer)
            {
                drunkTimer = 0;
                drunkRotationSpeed = -drunkRotationSpeed;
            }
            transform.Rotate(new Vector3(0, drunkRotationSpeed, 0), Space.Self);


            if (currentRot > -.1f && currentRot < .1f)
            {
                currentRot = 0;
            }
            else if (currentRot < 0)
            {
                currentRot += Time.deltaTime * speedRot;
                if (currentRot > -.1f && currentRot < .1f)
                {
                    currentRot = 0;
                }
            }
            else if (currentRot > 0)
            {
                currentRot -= Time.deltaTime * speedRot;
                if (currentRot > -.1f && currentRot < .1f)
                {
                    currentRot = 0;
                }
            }

            obj3D.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRot));
        }
    }
}
