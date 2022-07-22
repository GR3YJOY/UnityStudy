using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public float turnDelay = 0.1f; //플레이어가 한칸 움직일 때마다 enemy도 한칸씩 움직이게 만듦
    public int playerFoodPoints = 100;
    public static GameManager instance = null;

    [HideInInspector] public bool playersTurn = true; //플레이어가 움직였는지 안움직였는지에 대한 판단

    private BoardManager boardManager;
    private int level = 1; //레벨 1부터 시작
    private List<Enemy> enemies; //에너미를 관리하기 위한 리스트
    private bool enemiesMoving; //에너미가 움직였는지 여부 판단

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>();

        boardManager = GetComponent<BoardManager>();

        InitGame();
    }

    void InitGame()
    {
        enemies.Clear();

        boardManager.SetupScene(level);
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }

    void Update()
    {
        if (playersTurn || enemiesMoving)
            return;

        StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(turnDelay);

        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();

            yield return new WaitForSeconds(enemies[i].moveTime);
        }
    }

    public void GameOVer()
    {
        enabled = false;
    }
}
