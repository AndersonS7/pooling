using Pool.PoolingManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int size;
    [SerializeField] private Transform point;

    private List<GameObject> pooledBullets = new List<GameObject>();
    private PoolingManager pooling;

    private void Start()
    {
        pooling = PoolingManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = pooling.Spawn(cube);

            if (b == null)
                return;

            b.transform.position = point.position;
            b.transform.rotation = point.rotation;

            b.SetActive(true);
        }
    }
}
