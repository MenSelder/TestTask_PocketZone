using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletDamage = 15f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var component in collision.gameObject.GetComponents<MonoBehaviour>())
        {
            Debug.Log(component);

            if (component is IDamageable)
            {
                IDamageable damageable = (IDamageable)component;
                damageable.TakeDamage(bulletDamage);
            }
        }

        Destroy(gameObject);
    }
}
