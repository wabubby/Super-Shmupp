using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed = 5;
    
    public int health = 5;

    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Game.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (player.position - transform.position).magnitude;

        if (distanceToPlayer < 20) {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
            transform.position = newPosition;

            if (distanceToPlayer < transform.localScale.x) {
                SceneManager.LoadScene("Full Game");
            }

            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        health -= 1;
        Destroy(col.gameObject);
    }
}
