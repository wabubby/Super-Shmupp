//using System.Numerics;
//using System.Numerics;
//using System.Numerics;
using UnityEngine;
[RequireComponent(typeof(PhysicsController), typeof(JumpController))]

public class MovementController : MonoBehaviour{

    //Config variables
    [SerializeField] private float speed;
    [SerializeField] private float accelTime, decelTime;

    //Control variables 
    private float deltaAccel, deltaDecel;
    private PhysicsController physics;

    private JumpController jump;

    //private field
    public Vector2 InputDir;
    Vector2 lastInputDir;

    void Start()
    {
        physics = GetComponent<PhysicsController>();
        jump = GetComponent<JumpController>();

        deltaAccel = (speed/accelTime)*Time.deltaTime;
        deltaDecel = (speed/decelTime)*Time.deltaTime;
        print($"{deltaAccel} {deltaDecel}");
        lastInputDir = Vector2.zero;
    }

    void Update()
    {
        InputDir = Vector2.zero;
         //Check for key presses
        if (Input.GetKey(KeyCode.D)){
            InputDir.x += 1;
        }

        if (Input.GetKey(KeyCode.A)){
            InputDir.x -= 1;
        }


        if (!jump.isInDive){
            if (lastInputDir !=InputDir){
                physics.velocity.x = 0;
            }
            
            if (InputDir.x > 0){
                physics.velocity.x += deltaAccel;
            }

            if (InputDir.x < 0){
                physics.velocity.x -= deltaAccel;
            }
        }

        //Deceleration
        if (InputDir.x == 0 && !jump.isInDive){
            if (Mathf.Abs(physics.velocity.x) - Mathf.Abs(physics.cInfo.faceDirection.x*deltaDecel) < 0){
                physics.velocity.x = 0;
            }
            else{
                physics.velocity.x -= physics.cInfo.faceDirection.x*deltaDecel;
            }
        }

        if (!jump.isInDive){
            physics.velocity.x = Mathf.Clamp(physics.velocity.x, -speed, speed);
        }

        lastInputDir = InputDir;
    }
}