using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // The amount of damage dealt by the projectile
    public int damage = 0;

    // The lifetime of the projectile (in seconds)
    public float lifetime = 10.0f;

    void Start()
    {
        // Destroy the projectile after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile hit an object with a "Damageable" component
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            // Deal damage to the object
            damageable.TakeDamage(damage);
        }

        // Destroy the projectile
        Destroy(gameObject);
    }
}
