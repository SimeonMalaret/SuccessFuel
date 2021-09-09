using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoItem : Items
{
    public float duration;
    public float gravity;
    private float oldGravity;
    private Coroutine effectDuration;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (player.underEffect == false)
        {
            oldGravity = GameManager._instance.gravity;
        }
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
        if (player.underEffect == false)
        {
            player.underEffect = true;
            GameManager._instance.gravity = gravity;
            transform.position = new Vector3(100, 100, 100);
            yield return new WaitForSeconds(time);
            GameManager._instance.gravity = oldGravity;
            player.underEffect = false;
        }
        Destroy(this.gameObject);
    }
}
