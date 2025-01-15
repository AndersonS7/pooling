using Pool.PoolingManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private PoolingManager pooling;

    private void Start()
    {
        pooling = PoolingManager.instance;

    }
    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }
    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(2f);
        pooling.Despawn(gameObject);
    }
}
