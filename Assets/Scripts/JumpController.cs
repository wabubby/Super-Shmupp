using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PhysicsController),typeof(MovementController))]


public class JumpController : MonoBehaviour
{

    // private fields and methods should be CAMELCASE!!!

    //Config
    [SerializeField] float apexTime = 0.2f;
    [SerializeField] float JumpHeight = 3f;
    [SerializeField] float TerminalVelocity = 28f;
    [SerializeField] float DiveHeight = 1f;
    [SerializeField] float DiveApexTime = 0.12f;
    [SerializeField] float diveSpeedX = 15f;
    [SerializeField] float jumpBuffThreshold = 0.15f;
    [SerializeField] float CoyoteTime = 0.1f;

    //idfk what the shit this is
    PhysicsController physics;
    MovementController move;

    //Control
    float jumpSpeed; 
    float gravity;
    float diveGravity;

    //keeping track of stuff
        //diving
        bool canDive;
        public bool isInDive;
        int lastFacing;
        float diveSpeedY;
        //jump buffer
        float lastJumpInputTime;
        bool jumpBuffered;

        //Coyote
        float lastGround;

        //misc
        bool isGround;
        bool canJump;
        bool airborneFromJump;


    void Start()
    {
        physics = GetComponent<PhysicsController>();
        move = GetComponent<MovementController>();

        jumpSpeed = 2 * JumpHeight/apexTime;
        gravity = jumpSpeed*jumpSpeed/(2*JumpHeight);

        diveSpeedY = 2 * DiveHeight/DiveApexTime;
        diveGravity = diveSpeedY*diveSpeedY/(2*DiveHeight);
    }

    // Update is called once per frame
    void Update() {
        #if UNITY_EDITOR
        Start();
        #endif

        canJump = false;
        canDive = true;
        isGround = physics.cInfo.down;
        jumpBuffered = false;


        if (move.InputDir.x != 0){
            lastFacing = (int)move.InputDir.x;
        }

        if (isGround){
            lastGround = Time.time;
            airborneFromJump = false;
            canJump = true;
        }

        else{
            if (Time.time - lastGround < CoyoteTime){
                canJump = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space)){
            lastJumpInputTime = Time.time;
        }
        
        float timeSinceJumpInput = Time.time - lastJumpInputTime;
        if (timeSinceJumpInput < jumpBuffThreshold){
            jumpBuffered = true;
        }

        Gravitate();
        TryJump();
        TryDive();

        // terminal velocity
        if (physics.velocity.y < -TerminalVelocity) {
            physics.velocity.y = -TerminalVelocity;
        }
    }

    void TryJump(){
        if (canJump && Input.GetKeyDown(KeyCode.Space) && !airborneFromJump){
            physics.velocity.y = jumpSpeed;
            airborneFromJump = true;
            print("jumped");
        }

        if (jumpBuffered && isGround && canJump){
            physics.velocity.y = jumpSpeed;
            lastJumpInputTime = -Mathf.Infinity;
            canJump = false;
            airborneFromJump = true;
        }
    }

    void Gravitate(){
        float g = isInDive ? diveGravity : gravity;
        physics.velocity.y -= g * Time.deltaTime;
    }

    void TryDive(){
        if (isGround) {isInDive = false;}

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isInDive){
            isInDive = true;
            physics.velocity.y = diveSpeedY;
            physics.velocity.x = lastFacing*diveSpeedX;
        }
    }
}
