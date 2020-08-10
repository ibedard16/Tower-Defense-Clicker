using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker : MonoBehaviour
{
    public TurretMaker TM;
    public RobotMovement EnemyPrefab;
    public GameObject EnemyContainer;
    public GameObject[] guidePosts;
    public float enemySpeed;
    public List<RobotMovement> Enemies;
    public int WaveSize = 15;
    public GameObject LifeText;
    public int lives = 3;

    private float nextEnemy = 0;
    private float waveTime = 0;
    private int currentWave = 0;
    private bool running = false;

    void Start()
    {
        Enemies = new List<RobotMovement>();
        LifeText.GetComponent<UnityEngine.UI.Text>().text = "" + lives;
    }

    public void RemoveLife(){
        lives -= 1;
        LifeText.GetComponent<UnityEngine.UI.Text>().text = "" + lives;
    }

    void Update()
    {
        waveTime += Time.deltaTime;
        if (Input.GetKeyDown("space") && running == false)
        {
            print("space key was pressed");
            startWave();
        }

        if(running){
            if(waveTime > nextEnemy && nextEnemy < WaveSize){
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
        RobotMovement newEnemy = Instantiate(EnemyPrefab, new Vector2(100, 100), Quaternion.identity);
        newEnemy.guidePosts = guidePosts;
        newEnemy.speed = enemySpeed;
        newEnemy.transform.parent = EnemyContainer.transform;
        newEnemy.wave = this;
        Enemies.Add(newEnemy);
    }
}
