using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private GameObject door;
    public float moveSpeed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, door.transform.position, moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var  objectName = col.collider.gameObject.name;
        Debug.Log(objectName);
        if (objectName == "Door")
        {
            SceneController.LoseGame();
        }
    }
}
