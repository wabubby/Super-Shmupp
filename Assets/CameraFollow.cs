using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    public float autoScrollspeed;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x+2 > transform.position.x) {
            transform.position = new Vector3(player.position.x+2, transform.position.y, transform.position.z);
        }

        if (player.position.x < transform.position.x-9) {
            player.position = new Vector3(transform.position.x-9, player.position.y, player.position.z);
        }


        transform.position = new Vector3(transform.position.x+autoScrollspeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

}
