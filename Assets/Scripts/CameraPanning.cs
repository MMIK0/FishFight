using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), 2f);
    }
}
