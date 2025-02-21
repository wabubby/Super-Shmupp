using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float delay;

    Vector2 inputDir;
    float delayTimer;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputDir = (mousePosition - (Vector2) transform.parent.position).normalized;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(inputDir.y, inputDir.x)*Mathf.Rad2Deg);

        if (Input.GetMouseButton(0)) {
            if (delayTimer <= 0) {
                ShootBullet();
                delayTimer = delay;
            }
        }
        delayTimer -= Time.deltaTime;
    }

    void ShootBullet() {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        bullet.velocity = inputDir * speed;
    }
}
