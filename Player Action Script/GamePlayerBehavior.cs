using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerBehavior : MonoBehaviour
{
    public float FirstVelocity = 100f;
    public float MaxXVelocity = 150f;
    public float MaxAcceleration = 150f;
    public float Acceleration = 120f;
    public float JumpVelocity = 30f;
    public float Gravity = -150f;

    public bool IsHoldingJump = false;
    public float MaxHoldJumpTime = 0.5f;
    public float HoldJumpTimer = 0.0f;
    public float MaxFloatSkyTime = 0.5f;
    public float HoldFloatSkyTimer = 0.0f;
    public float MaxStuckJumpTime = 1f;
    public float HoldStuckTimer = 0.0f;

    public GameObject Firework;
    public GameObject SubFirework;

    public Rigidbody Player;
    public LevelAttributes LevelAttributes;
    public ObjectPool ObjectPool = ObjectPool.Instance;

    private bool _isHitGround = false;
    private bool _isFreeze = false;
    private int _pressfreeze = 1;

   

    public void Init()
    {
        if (LevelAttributes)
        {
            MaxXVelocity = LevelAttributes.PlayerVelocity;
            MaxAcceleration = LevelAttributes.PlayerAcceleration;
            JumpVelocity = LevelAttributes.PlayerJumpVelocity;
            Gravity = LevelAttributes.Gravity;
        }
        Player.velocity = new Vector3(FirstVelocity, 0, 0);
    }

    void Start()
    {
        Init();
        
    }

    void Update()
    {

        PlayerJump();
        

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (_pressfreeze == 1)
            {
                Freeze();
                _isFreeze = true;
                _pressfreeze++;
            }
            else if (_pressfreeze == 2)
            {
                _pressfreeze = 1;
                _isFreeze = false;
            }
        }
    }



    void FixedUpdate() 
    {
        
        PlayerMovement();
 
    }

  
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Board") || collision.collider.CompareTag("Terrain"))
        {

            SubFirework = ObjectPool.SpawnFromPool("Explosion", SubFirework,transform.position, transform.rotation);
            StartCoroutine(ObjectPool.RecycleObject("Explosion", SubFirework, SubFirework.GetComponent<ParticleSystem>().main.duration));
            
            //GameObject subparticle = Instantiate(SubFirework, transform.position, transform.rotation);
            //Destroy(subparticle, SubFirework.GetComponent<ParticleSystem>().main.duration);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Board") || collision.collider.CompareTag("Terrain"))
        {
           
            //GameObject particle = Instantiate(Firework, transform.position, transform.rotation);
            //Destroy(particle, Firework.GetComponent<ParticleSystem>().main.duration);

            _isHitGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Board") || collision.collider.CompareTag("Terrain"))
        {

            
            _isHitGround = false;
        }
    }

    void PlayerMovement()
    {
        if (!_isFreeze)
        {
            if (Player.velocity.x < MaxXVelocity)
            {
                if (Player.velocity.x < FirstVelocity)
                {
                    Player.velocity = new Vector3(FirstVelocity, 0, 0);
                }
                Player.velocity += Vector3.right * Acceleration * Time.fixedDeltaTime;

            }

            if (!_isHitGround)
            {
                if (IsHoldingJump)
                {
                    HoldJumpTimer += Time.fixedDeltaTime;
                    if (HoldJumpTimer >= MaxHoldJumpTime)
                    {
                        
                        IsHoldingJump = false;
                    }
                }
            }

            transform.position += Vector3.up * Player.velocity.y * Time.fixedDeltaTime;

            if (!IsHoldingJump)
            {
                Player.velocity += Vector3.up * Gravity * Time.fixedDeltaTime;
            }

            if (Player.velocity.y > 0)
            {
                HoldFloatSkyTimer += Time.fixedDeltaTime;
                if (HoldFloatSkyTimer >= MaxFloatSkyTime)
                {
                    IsHoldingJump = false;
                }
            }

            if (Player.velocity.x <= 1.0f)
            {
                HoldStuckTimer += Time.fixedDeltaTime;
                if (HoldStuckTimer >= MaxStuckJumpTime)
                {
                    
                    IsHoldingJump = false;
                    Player.velocity += Vector3.up * Gravity * Time.fixedDeltaTime;
                }
            }
        }
    }
    void PlayerJump()
    {
        if (!_isFreeze)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpHold();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                JumpRelease();
            }
            
        }
    }
    public void JumpHold()
    {
        if (_isHitGround)
        {
            Player.velocity += Vector3.up * JumpVelocity;
            IsHoldingJump = true;
            HoldJumpTimer = 0;
            HoldFloatSkyTimer = 0;
        }
    }
    public void JumpRelease()
    {
        IsHoldingJump = false;
    }
    void Freeze()
    {
        Player.velocity = Vector3.zero;
        Player.useGravity = false;
        _isHitGround = false;
        IsHoldingJump = false;
    }

}
