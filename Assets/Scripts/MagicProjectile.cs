using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var gameObj = col.gameObject;
        if(gameObj.tag == "Enemy" || gameObj.tag == "Window" || gameObj.tag == "Projectile")
        {
            return;
        }
        else if (gameObj.tag == "Player")
        {
            var health = gameObj.GetComponent<Health>();
            health.TakeDamage(1f);
        }
        Destroy(gameObject);
    }
}