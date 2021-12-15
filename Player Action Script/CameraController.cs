using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
  

    public static Vector3 DeathPos, StartPos, CameraDeathPos, CameraStartPos;
    public Transform Player;
    public Vector3 Offset;
    public Gamemanger Gamemanger;

    
    void Awake()
    {
        if (DeathPos == Vector3.zero)
        {
            StartPos = Player.position;
            CameraStartPos = transform.position;
        }
    }
    
    void Start()
    {
        
        Offset = transform.position - Player.position;
 
    }

    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {

        transform.position = Player.position + Offset;
    }
    public void TransistionStart() //���ͫ�N���a�P���Y�Ԧ^�X�o�I���ʵe
    {
        DeathPos = Gamemanger.DeathPos;
        CameraDeathPos = Gamemanger.CameraDeathPos;
        if (DeathPos != Vector3.zero)
        {
            Player.position = StartPos;
            transform.position = CameraStartPos;
            Player.DOMove(DeathPos, 2.5f).From(false);
            transform.DOMove(CameraDeathPos, 2.5f).From(false);
        }

    }
}
