using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class RaycastController : MonoBehaviour
{
    public const float skinWidth = 0.015f;

    [Range(2,10)] [SerializeField] public int rayCount = 3;
    
    [Serializable]
    public struct Corners {
        public Vector2 topleft, topright, botleft, botright;
    }

    [Serializable]
    public struct RayPoints {
        public Vector2[] top, right, left, down;
    }

    protected BoxCollider2D colliders;
    protected Corners corners;
    protected RayPoints raypoints;
    void Awake() {
        colliders = GetComponent<BoxCollider2D>();
        CalculateCorners();
        CalculateRayPoints();
    }
    void CalculateCorners() {
        Bounds bounds = colliders.bounds;
        bounds.center -= transform.position;
        bounds.Expand(skinWidth*-2);

        corners.botleft = bounds.min;
        corners.topright = bounds.max;
        corners.botright = new Vector2(bounds.max.x,bounds.min.y);
        corners.topleft = new Vector2(bounds.min.x,bounds.max.y);
    }

    void CalculateRayPoints() {
        Bounds bounds = colliders.bounds;
        bounds.center -= transform.position;
        bounds.Expand(skinWidth*-2);

        raypoints.top = new Vector2[rayCount];
        raypoints.down = new Vector2[rayCount];
        raypoints.right = new Vector2[rayCount];
        raypoints.left = new Vector2[rayCount];

        Vector2 vertRayGap = bounds.size.y / (rayCount-1) * Vector2.down;
        Vector2 horzRayGap = bounds.size.x / (rayCount-1) * Vector2.right;

        for(int i = 0; i<rayCount; i++)
        {
            raypoints.top[i] = corners.topleft + horzRayGap*i;
            raypoints.down[i] = corners.botleft + horzRayGap*i;
            raypoints.right[i] = corners.topright + vertRayGap*i;
            raypoints.left[i] = corners.topleft + vertRayGap*i;
        }
    }
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     for(int i = 0; i<rayCount; i++)
    //     {
    //         Gizmos.DrawSphere((Vector2)transform.position + raypoints.top[i], 0.01f);
    //         Gizmos.DrawSphere((Vector2)transform.position + raypoints.down[i], 0.01f);
    //         Gizmos.DrawSphere((Vector2)transform.position + raypoints.right[i], 0.01f);
    //         Gizmos.DrawSphere((Vector2)transform.position + raypoints.left[i], 0.01f);
    //     }
    // }
}
