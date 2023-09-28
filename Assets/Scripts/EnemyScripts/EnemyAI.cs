using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float rangeMelee = 1f;
    private float speed = 100f;

    [SerializeField] private LayerMask layerMask;

    private float cd = 0.3f;
    private float currentCd = 0;

    private float damage = 20f;

    Transform target = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController;
        if (!collision.gameObject.TryGetComponent(out playerController))
            return;

        target = playerController.transform;
    }

    private void Hit(float damage)
    {
        if (currentCd > 0)
        {
            currentCd -= Time.deltaTime;
            return;
        }

        currentCd = cd;
        target.GetComponent<DamageableScript>().TakeDamage(damage);
    }

    private void MoveToTarget()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = (target.position - transform.position).normalized 
            * speed * Time.deltaTime;
    }

    void Update()
    {
        if (target == null)
            return;

        MoveToTarget();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, rangeMelee, layerMask);
        if (hit.collider?.transform == target)
        {
            Hit(damage);
        }

        Debug.DrawRay(transform.position, (target.position - transform.position).normalized, Color.cyan, rangeMelee);
    }
}
