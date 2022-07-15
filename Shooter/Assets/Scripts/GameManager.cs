using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject goEnemy;
    public GameObject goPlayer;

    public float curEnemySpawnDelay;
    public float maxEnemySpawnDelay;

    public Image[] imgLifes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        ReloadEnemy();
    }

    void ReloadEnemy()
    {
        curEnemySpawnDelay += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (curEnemySpawnDelay < maxEnemySpawnDelay)
            return;

        int randPoint = Random.Range(0, 3);
        GameObject createEnemy = Instantiate(goEnemy, spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);

        Rigidbody2D rd = goEnemy.GetComponent<Rigidbody2D>();
        Enemy enemy = createEnemy.GetComponent<Enemy>();

        rd.velocity = new Vector2(0, enemy.speed * (-1));
        enemy.goPlayer = goPlayer;

        maxEnemySpawnDelay = Random.Range(0.5f, 3f);  // 0.5 ~3초 사이에 랜덤하게 적비행기가 생성
        curEnemySpawnDelay = 0;
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 2.0f);
    }
    void AlivePlayer()
    {
        goPlayer.transform.position = Vector3.down * 3.5f; // 플레이어가 죽고 다시 리스폰되는 위치
        goPlayer.SetActive(true);

        Player playerLogic = goPlayer.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void UpdateLifeIcon(int life)
    {
        for (int idx = 0; idx < 3; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }

        for (int idx = 0; idx < life; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 1);
        }
    }

    public void GameOver()
    {
        
    }
}
