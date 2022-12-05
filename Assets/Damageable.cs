using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    // The object's current health
    public int health = 100;

    public virtual void TakeDamage(int damage)
    {
        // Reduce the object's health by the amount of damage taken
        health -= damage;

        // Check if the object is destroyed
        if (health <= 0)
        {
            // TODO: Handle the object's destruction
        }
    }
}