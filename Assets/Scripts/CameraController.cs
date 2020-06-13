using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform followTarget;
    [SerializeField]
    Vector3 cameraOffset;
    Vector3 moveDistance;
    [SerializeField]
    float movePercentage = 0.1f;
    float xPos = 0f, yPos = 58f, zPos = -10f;

    void Start()
    {
        cameraOffset = new Vector3(xPos, yPos, zPos);
    }

    void Update()
    {
        if (followTarget == null)
        {
            if (FindObjectOfType<Player>()) followTarget = FindObjectOfType<Player>().transform;
        }
    }

    void FixedUpdate()
    {
        if (!(followTarget == null))
        {
            moveDistance = (followTarget.position - transform.position + cameraOffset) * movePercentage;

            transform.position += moveDistance;
        }
    }
}
