using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : CombatController
{
    // The range of the player's attack (used to determine the initial position of the projectile)
    public float attackRange = 1.0f;

    // The prefab for the projectile to be shot
    public GameObject projectilePrefab;

    // The force to apply to the projectile when it is shot
    public float projectileForce = 10.0f;

    // The amount of damage dealt by the projectile
    public int projectileDamage = 25;

    public override void Attack()
    {
        // Get the direction of the mouse cursor in world space
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 attackDirection = mousePos - (Vector2)transform.position;
        attackDirection.Normalize();

        // Instantiate a new projectile at the player's position, facing in the attack direction
        GameObject projectile = Instantiate(projectilePrefab, transform.position + (Vector3)attackDirection * attackRange, Quaternion.LookRotation(attackDirection));

        // Set the projectile's y-axis rotation to 0
        projectile.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Apply the attack force to the projectile's rigidbody2D
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(attackDirection * projectileForce, ForceMode2D.Force);

        // Set the projectile's damage value
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        projectileController.damage = projectileDamage;
    }
}
