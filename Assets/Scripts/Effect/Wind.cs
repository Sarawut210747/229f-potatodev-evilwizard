using UnityEngine;

public class Wind : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ConstantForce2D force = collision.GetComponent<ConstantForce2D>();
            if (force != null)
                force.force = new Vector2(0, 50f);
            Debug.Log("Player");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ConstantForce2D force = collision.GetComponent<ConstantForce2D>();
            if (force != null)
                force.force = Vector2.zero;
        }
    }
}
