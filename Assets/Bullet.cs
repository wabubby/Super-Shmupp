using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector2 velocity;
    [SerializeField] float lifeTimeduration = 2f;

    public float lifeTime; 

    void Update() {
        transform.position += (Vector3) velocity * Time.deltaTime;

        lifeTime += Time.deltaTime;
        if (lifeTime >= lifeTimeduration) Destroy(gameObject);
    }
}
