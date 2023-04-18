using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void Teleport()
    {
        var localPos = new Vector3(
            UnityEngine.Random.Range(-4, 4),
            0.5f,
            UnityEngine.Random.Range(-4, 4)
        );

        transform.localPosition = localPos;
    }
}
