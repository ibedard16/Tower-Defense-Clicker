using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemyParent;
    public Vector3 StartPosition;

    private List<GameObject> Enemies;
    private int currentWave = 0;
    private bool running = false;
    private float waveTime = 0;
    private float nextEnemy = 0;

    void Start()
    {
        Enemies = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && running == false)
        {
            print("space key was pressed");
            startWave();
        }

        if(running){
            waveTime += Time.deltaTime;
            if(waveTime > nextEnemy && nextEnemy < 5){
                nextEnemy += 1;
                makeBot();
            }

        }
    }

    void startWave(){
        waveTime = 0;
        currentWave += 1;
        running = true;
    }

    void makeBot(){
        GameObject newEnemy = Instantiate(EnemyPrefab, StartPosition, Quaternion.identity);
        newEnemy.transform.parent = EnemyParent.transform;
        Enemies.Add(newEnemy);
    }
}
