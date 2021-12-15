using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelAttributes : ScriptableObject
{
    public string LevelName;
    public float PlayerVelocity;
    public float PlayerAcceleration;
    public float PlayerJumpVelocity;
    public float Gravity;
    public float PlayerSizeScale;
    public Color StageColor;
    
}
