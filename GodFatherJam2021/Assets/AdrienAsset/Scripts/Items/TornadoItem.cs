using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoItem : Items
{
    public float duration;
    public float gravity;
    public float speed;
    private Coroutine effectDuration;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (effectDuration == null)
            {
                effectDuration = StartCoroutine(EffectDuration(duration));
            }
        }
    }

    private IEnumerator EffectDuration(float time)
    {
        GameManager._instance.gravity = gravity;
        transform.position = new Vector3(100, 100, 100);
        yield return new WaitForSeconds(time);
        GameManager._instance.gravity = GameManager._instance.oldGravity;
        Destroy(this.gameObject);
    }
}
