using System;
using UnityEngine;

public class PhysicsController : RaycastController {

    [Serializable]
    public struct CollisionInfo{
        public bool up, down;
        public bool left, right;
        public Vector2 faceDirection;
        public void Reset(){
            up = down = left = right = false;
            faceDirection = Vector2.right;
        }
    }

    public Vector2 velocity;
    public LayerMask Mask;
    public CollisionInfo cInfo;

    private Vector2 deltaS; // the change in position this frame

    public void Move()
    {
        cInfo.Reset();
        transform.rotation = Quaternion.Euler(0,0,0);   
        cInfo.faceDirection.x = Mathf.Sign(velocity.x);
        cInfo.faceDirection.y = Mathf.Sign(velocity.y);

        deltaS = velocity*Time.deltaTime;

        VerticalCollision();
        HorizontalCollision();

        velocity = deltaS/Time.deltaTime;

        transform.position += (Vector3) deltaS;
    }

    private void VerticalCollision() {

      
        if (cInfo.faceDirection.y <= 0){
        for (int i = 0; i < rayCount; i++){
            Vector2 rayOrigin = (Vector2) transform.position + raypoints.down[i];
            float rayLengthY = Mathf.Abs(deltaS.y) + skinWidth;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLengthY, Mask);

            if (hit) {
                deltaS.y = -(hit.distance-skinWidth);
                cInfo.down = true;
            }

            Debug.DrawRay(rayOrigin, Vector2.down*rayLengthY, Color.red);
        }
        }
        
        else if (cInfo.faceDirection.y < 0) {
            for (int i = 0; i < rayCount; i++){
            Vector2 rayOrigin = (Vector2) transform.position + raypoints.top[i];
            float rayLengthY = Mathf.Abs(deltaS.y) + skinWidth;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLengthY, Mask);

            if (hit) {
                deltaS.y = (hit.distance-skinWidth);
                cInfo.up = true;
            }

            Debug.DrawRay(rayOrigin, Vector2.up*rayLengthY, Color.red);
            }
        }


    }
    
    private void HorizontalCollision() {
        if (cInfo.faceDirection.x > 0){
            for (int i = 0; i < rayCount; i++){
                Vector2 rayOrigin = (Vector2) transform.position + raypoints.right[i];
                float rayLengthX = Mathf.Abs(deltaS.x) + skinWidth;

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLengthX, Mask);

                if (hit) {
                    deltaS.x = (hit.distance-skinWidth);
                    cInfo.right = true;
                }
                Debug.DrawRay(rayOrigin, Vector2.right*rayLengthX, Color.red);
            }
        }
        else{
            for (int i = 0; i < rayCount; i++){
                Vector2 rayOrigin = (Vector2) transform.position + raypoints.left[i];
                float rayLengthX = Mathf.Abs(deltaS.x) + skinWidth;

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, rayLengthX, Mask);

                if (hit) {
                    deltaS.x = -(hit.distance-skinWidth);
                    cInfo.left = true;
                }
                Debug.DrawRay(rayOrigin, Vector2.right*rayLengthX, Color.red);
            }

        }
    }

    public void LateUpdate() { Move(); }


}

