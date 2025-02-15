using UnityEngine;

public class PhysicsController : RaycastController {

    public Vector2 velocity;
    public LayerMask Mask;

    public struct CollisionInfo{
        public bool above, below;
        public bool left, right;
        public Vector2 faceDirection;
        public void Reset(){
            above = below = left = right = false;
            faceDirection = Vector2.right;
        }
    }

    public CollisionInfo cInfo;

    public void Move()
    {
        cInfo.Reset();

        if (velocity.x>0){
            cInfo.faceDirection.x = 1;
        }
        else if (velocity.x<0){
            cInfo.faceDirection.x = -1;
        }

        cInfo.faceDirection.y = Mathf.Sign(velocity.y);
        VerticalCollision();

        transform.position += (Vector3) velocity;
    }

    private void VerticalCollision(){
        for (int i = 0; i < rayCount; i++){
            float rayLengthY = Mathf.Abs(velocity.y * Time.deltaTime) + skinWidth;
            Vector2 rayOrigin = (Vector2)transform.position + raypoints.down[i];
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLengthY, Mask);
            Debug.DrawRay(rayOrigin, Vector2.down*rayLengthY*10, Color.red);

            if (hit) {
                velocity.y = -(hit.distance-skinWidth) * 100000;
            }
        }
    }
    private void HorizontalCollision(){

    }
    public void LateUpdate()
    {
        Move();
    }

}

