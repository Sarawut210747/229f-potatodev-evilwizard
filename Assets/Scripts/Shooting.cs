using UnityEngine;

public class Shooting : MonoBehaviour
{
   [SerializeField] private Transform shootPoint;         // จุดยิงกระสุน
    [SerializeField] private Rigidbody2D bulletPrefab;     // Prefab กระสุน (มี Rigidbody2D)
    [SerializeField] private float launchTime = 1f;        // เวลาที่กระสุนใช้ถึงเป้าหมาย
     [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // คลิกซ้าย = ยิง
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // คำนวณความเร็วที่ต้องใช้เพื่อให้ถึงเมาส์ภายในเวลา launchTime
            Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, mouseWorldPos, launchTime);

            // ยิงกระสุน
            Rigidbody2D newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            newBullet.linearVelocity = velocity;

            // หมุนกระสุนให้หันตามทิศที่ยิง
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    // ฟังก์ชันคำนวณความเร็วกระสุน
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float timeToTarget)
    {
        Vector2 distance = target - origin;

        float vx = distance.x / timeToTarget;
        float vy = (distance.y + 0.5f * Mathf.Abs(Physics2D.gravity.y) * Mathf.Pow(timeToTarget, 2)) / timeToTarget;

        return new Vector2(vx, vy);
    }
}