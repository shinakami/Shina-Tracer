using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAtUI : MonoBehaviour
{
    public Transform Player;
    private Vector3 _offset;
    
    
    void Start()
    {
        _offset = transform.position - Player.position;
        
    }

    
    void LateUpdate()
    {
        transform.position = Player.position + _offset;
    }
}
