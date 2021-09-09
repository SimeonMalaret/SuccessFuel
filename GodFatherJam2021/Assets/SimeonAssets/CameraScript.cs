using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform focusObj;
    public float accuranci = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        /*transform.position = focusObj.position;
        transform.rotation = focusObj.rotation;*/
    }

    // Update is called once per frame
    void Update()
    {

        /*transform.position = focusObj.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, focusObj.rotation, accuranci * Time.deltaTime);*/


        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(new Vector3(0, 0, -GetComponentInParent<PlayerMovement>().rotationSpeed), Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(new Vector3(0, 0, GetComponentInParent<PlayerMovement>().rotationSpeed), Space.Self);
        }
    }
}
