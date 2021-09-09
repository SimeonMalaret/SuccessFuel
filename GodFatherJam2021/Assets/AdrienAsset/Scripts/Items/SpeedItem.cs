using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Items
{
    public float duration;
    public float speedMultiplier;
    private float oldSpeed;
    private Coroutine effectDuration;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (player.underEffect == false)
        {
            oldSpeed = player.moveSpeed;
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
            player.moveSpeed *= speedMultiplier;
            transform.position = new Vector3(100, 100, 100);
            yield return new WaitForSeconds(time);
            player.moveSpeed = oldSpeed;
            player.underEffect = false;
        }
        Destroy(this.gameObject);
    }
}
