using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotatation : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0,0,0);
    void Update()
    {
        transform.Rotate(rotation);
    }
}
