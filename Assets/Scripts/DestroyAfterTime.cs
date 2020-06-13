using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    float destroyAfterTime = 2f;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > destroyAfterTime) Destroy(gameObject);
    }
}
