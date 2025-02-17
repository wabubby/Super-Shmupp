using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PhysicsController),typeof(MovementController))]


public class JumpController : MonoBehaviour
{
    //Config
    [SerializeField] float ApexTime, JumpHeight, TerminalVelocity, DiveHeight, DiveApexTime, diveSpeedX;


    //Control
    float jumpSpeed; 
    float gravity;
    float diveGravity;
    PhysicsController physics;
    MovementController move;
    bool isGround;
    bool canDive;
    public bool isInDive;
    int lastFacing;
    float diveSpeedY;

    void Start()
    {
        physics = GetComponent<PhysicsController>();
        move = GetComponent<MovementController>();

        jumpSpeed = 2 * JumpHeight/ApexTime;
        gravity = jumpSpeed*jumpSpeed/(2*JumpHeight);

        diveSpeedY = 2 * DiveHeight/DiveApexTime;
        diveGravity = diveSpeedY*diveSpeedY/(2*DiveHeight);
    }

    // Update is called once per frame
    void Update()
    {
        isGround = physics.cInfo.down;
        canDive = true;
        #if UNITY_EDITOR
        Start();
        #endif

        if (move.InputDir.x != 0){
            lastFacing = (int)move.InputDir.x;
        }

        Jump();
        Gravitate();
        Dive();

        physics.velocity.y = Mathf.Clamp(physics.velocity.y, -TerminalVelocity, Mathf.Infinity);
    }

    void Jump(){
        if (isGround && Input.GetKey(KeyCode.Space)){
            physics.velocity.y = jumpSpeed;
        }
    }

    void Gravitate(){
        if (!isGround && !isInDive){
            physics.velocity.y -= gravity * Time.deltaTime;
        }
        if (!isGround && isInDive){
            physics.velocity.y -= diveGravity * Time.deltaTime;
        }
    }

    void Dive(){

        if (isGround){
            isInDive = false;
        }

        if (!isGround && isInDive){
            canDive = false;;
        }

        else {
            canDive = true;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && canDive){
            isInDive = true;
            physics.velocity.y = diveSpeedY;
            physics.velocity.x = lastFacing*diveSpeedX;
        }
    }
}
