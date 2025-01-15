using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool.PoolingManager;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float speed;

    private PoolingManager pooling;

    private void Start()
    {
        pooling = PoolingManager.instance;

    }
    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(2f);
        pooling.Despawn(gameObject);
    }
}
