using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        if(enemyCount > 10)
        {
            Invoke("WinGame", 25f);
            return;
        }
        var plate = Object.Instantiate(enemy, transform.position, Quaternion.identity);
        enemyCount++;
    }

    private void WinGame()
    {
        SceneController.WinGame();
    }
}
