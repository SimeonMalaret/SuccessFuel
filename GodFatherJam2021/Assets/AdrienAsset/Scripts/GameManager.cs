using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("Fuel")]
    [HideInInspector] public int fuel = -40;
    public float fuelLostTimer;
    public RectTransform needle;
    private Coroutine fuelLostCor;

    public int buildingDamage;
    public int mouetteDamage;

    public PlayerMovement player;
    [HideInInspector] public bool isInvincible = false;
    public float gravity;
    [HideInInspector] public float oldGravity;

    public AudioSource audioSource;
    public AudioClip buildBump;
    public AudioClip gameOver;

    public Transform mainCam;
    public Transform firstPersonCam;
    public Transform topDownCam;
    public bool changeCam;

    [HideInInspector] public bool pauseTimer = false;
    public GameObject gameOverCanvas;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        oldGravity = gravity;
        fuel = -40;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel <= 40)
        {
            MoveNeedle();
            FuelLost(fuelLostTimer);
        }
        else
        {
            player.moveSpeed = 0;
            gameOverCanvas.SetActive(true);
            pauseTimer = true;
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
        yield return new WaitForSeconds(time);
        fuelLostCor = null;
    }

    public void MoveNeedle()
    {
        needle.transform.eulerAngles = new Vector3(0, 0, fuel);
    }

    public void FuelHit(int amount, float time)
    {
        if (isInvincible == false)
        {
            fuel += amount;
            isInvincible = true;
            StartCoroutine(InvincibleTimer(time));
        }
    }

    private IEnumerator InvincibleTimer(float time)
    {
        //Debug.Log("Lance toi !");
        float frameTime = 0.1f;
        float timePassed = 0;
        player.explosion.SetActive(true);
        while (timePassed < time)
        {
            player.mr.enabled = !player.mr.enabled;
            yield return new WaitForSeconds(frameTime);
            timePassed += frameTime;
        }
        player.explosion.SetActive(false);
        player.mr.enabled = true;
        isInvincible = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        pauseTimer = false;
        gameOverCanvas.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
