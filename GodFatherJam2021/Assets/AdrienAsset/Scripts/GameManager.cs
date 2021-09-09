using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("Fuel")]
    [HideInInspector] public int fuel = -40;
    public float fuelLostTimer;
    public RectTransform needle;
    private Coroutine fuelLostCor;

    public PlayerMovement player;
    public float gravity;
    [HideInInspector] public float oldGravity;

    public AudioClip buildBump;
    private void Awake()
    {
        if (GameManager._instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        oldGravity = gravity;
        fuel = -40;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel <= 40)
        {
            FuelLost(fuelLostTimer);
        }
        else
        {
            player.moveSpeed = 0;
        }
    }

    public void FuelLost(float time)
    {
        if (fuelLostCor == null)
        {
            fuelLostCor = StartCoroutine(LoseFuel(time));
        }
    }

    private IEnumerator LoseFuel(float time)
    {
        fuel++;
        MoveNeedle();
        yield return new WaitForSeconds(time);
        fuelLostCor = null;
    }

    public void MoveNeedle()
    {
        needle.transform.eulerAngles = new Vector3(0, 0, fuel);
    }
}
