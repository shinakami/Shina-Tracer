using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Plyaer;
    private float _firstvelocity = 120;
    private float _maxVelocity = 130;

    void Start()
    {
        Plyaer.velocity = new Vector3(_firstvelocity, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Plyaer.velocity.x < _maxVelocity)
        {
            if (Plyaer.velocity.x < _firstvelocity)
            {
                Plyaer.velocity = new Vector3(_firstvelocity, 0, 0);
            }
            Plyaer.velocity += Vector3.right * 1.5f * Time.fixedDeltaTime;

        }
    }
}
