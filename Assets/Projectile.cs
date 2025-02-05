using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Player _player;
    public float _timeToLive = 5f;

    private Coroutine _returnToPoolTimerCoroutine;

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(returnToPoolAfterTime());
    }

    private IEnumerator returnToPoolAfterTime()
    {
        // Destroy this projectile after a certain time interval
        float elapsedTime = 0.0f;
        while (elapsedTime < _timeToLive)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.returnObjectToPool(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _player.depleteHealth(5);
            ObjectPoolManager.returnObjectToPool(gameObject);
        }
    }
}
