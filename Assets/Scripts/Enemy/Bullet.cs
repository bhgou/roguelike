using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject particle;
    [SerializeField] private int damage;
    private void Update()
    {
        if (MovePlayer.Instance.direction == 1)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (MovePlayer.Instance.direction == -1)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * speed);
        }
        var s = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(s,1f);
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
