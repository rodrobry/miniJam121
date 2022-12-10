using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
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
        if(gameObj.tag == "Player" || gameObj.tag == "Window")
        {
            return;
        }
        else if (gameObj.tag == "Enemy")
        {
            var health = gameObj.GetComponent<Health>();
            health.TakeDamage(1f);
        }
        Destroy(gameObject);
    }
}