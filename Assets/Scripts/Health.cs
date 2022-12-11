using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 3f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage > 0f ? currentHealth - damage : 0f;

        if (currentHealth == 0)
        {
            Die();
        }

        if (gameObject.tag == "Player")
        {
            var num = currentHealth + 1;
            var heart = GameObject.Find("Heart" + num);
            heart.SetActive(false);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
