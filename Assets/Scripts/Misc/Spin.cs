using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back, speed * Time.fixedDeltaTime);
    }
}
