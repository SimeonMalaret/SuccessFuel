using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Items
{
    public Transform mainCam;
    public Transform firstPersonCam;
    public Transform topDownCam;

    public float lerpTime = .5f;

    public AudioSource audioSource;
    public AudioClip soundEffect;

    private Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        mainCam = GameManager._instance.mainCam;
        firstPersonCam = GameManager._instance.firstPersonCam;
        topDownCam = GameManager._instance.topDownCam;
    }

    private void ChangeView(Transform trans)
    {
        mainCam.transform.parent = trans;
        StartCoroutine(ISetPositionIn(Vector2.zero, lerpTime));
        StartCoroutine(ISetRotationIn(Quaternion.identity, lerpTime));
    }

    private IEnumerator ISetPositionIn(Vector3 position, float time)
    {
        Vector3 basePosition = mainCam.transform.localPosition;
        Vector3 deltaVector = position - basePosition;
        int frameNumber = Mathf.FloorToInt(time * 60f);
        Vector3 stepVector = deltaVector / (float)frameNumber;
        //Vector3.Lerp(Vector3.zero, deltaVector, (float)i / (float)frameNumber)
        for (int i = 0; i < frameNumber; i++)
        {
            mainCam.transform.localPosition += stepVector;
            yield return new WaitForSeconds(1f / 60f);
        }
    }

    private IEnumerator ISetRotationIn(Quaternion rotation, float time)
    {
        Quaternion baseRotation = mainCam.transform.localRotation;
        int frameNumber = Mathf.FloorToInt(time * 60f);
        //Quaternion stepVector = deltaVector / (float)frameNumber;
        //Vector3.Lerp(Vector3.zero, deltaVector, (float)i / (float)frameNumber)
        for (int i = 0; i < frameNumber; i++)
        {
            mainCam.transform.localRotation = Quaternion.Slerp(baseRotation, rotation, (float)i / (float)frameNumber);
            yield return new WaitForSeconds(1f / 60f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(soundEffect);

            GameManager._instance.changeCam = !GameManager._instance.changeCam;;
            if (GameManager._instance.changeCam == true)
            {
                targetPosition = firstPersonCam;
                ChangeView(targetPosition);
                /*LerpCamera();
                LerpRotateCamera();*/
            }
            if (GameManager._instance.changeCam == false)
            {
                targetPosition = topDownCam;
                ChangeView(targetPosition);
                /*LerpCamera();
                LerpRotateCamera();*/
            }
            Destroy(this.gameObject, lerpTime +1f);
        }
    }
}
