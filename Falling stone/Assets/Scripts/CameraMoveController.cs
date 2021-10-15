using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    public Transform cameraTarget;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - cameraTarget.position;
    }

    
    void Update()
    {
        if(cameraTarget != null)
        {
            transform.position = cameraTarget.position + offset;
        }  
    }
}
