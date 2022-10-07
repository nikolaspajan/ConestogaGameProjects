using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectable : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.1f, 0,0.1f);
    }
}
