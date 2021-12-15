using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//¤W1700 ¤¤1150 ¤U1300
public class Parallax : MonoBehaviour
{

    private float _length, _startpos;
    private float _temp, _dist;

    [SerializeField]
    private float _choke;

    public Transform Camera;

    

    [Range(0f, 1f)] public float ParallaxEffect;

    void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x - _choke;
        
    }

    void Update()
    {
        _temp = Camera.position.x * (1 - ParallaxEffect);
        _dist = Camera.position.x * ParallaxEffect;

        transform.position = new Vector3(_startpos + _dist, transform.position.y, transform.position.z);

        if (_temp > _startpos + _length)
        {
            _startpos += _length;
        }
        else if (_temp < _startpos - _length)
        {
            _startpos -= _length;
        }

    }
}
