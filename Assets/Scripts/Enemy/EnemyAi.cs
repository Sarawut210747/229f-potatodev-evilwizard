using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;

    int nextWayPoint = 1;
    float distToPoint;

    public int damage;
    public float knockbackForce;

    // Update is called once per frame
    void Update()
    {
        Move();    
    }
    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoints[nextWayPoint].transform.position);
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWayPoint].transform.position, moveSpeed * Time.deltaTime);

        if(distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[nextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        nextWayPoint++;

        if(nextWayPoint == wayPoints.Length)
        {
            nextWayPoint = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HeartPlayer playerHeart = collision.gameObject.GetComponent<HeartPlayer>();
            if(playerHeart != null)
            {
                playerHeart.TakeDamage(damage);
            }
        }

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if(playerRb != null)
        {
            Vector2 knockDirection = (collision.transform.position - transform.position).normalized;
            playerRb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
