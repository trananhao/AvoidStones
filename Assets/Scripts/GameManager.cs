using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dino playerPrefab;
    public Stone[] stonePrefabs;

    public float spawnTime;

    int m_score;
    bool m_isGameover;
    bool m_isGamebegun;
    Dino m_dinoClone;

    public int Score { get => m_score; set => m_score = value; }
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public bool IsGamebegun { get => m_isGamebegun; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()  
    {
        GameGUIManager.Ins.ShowGameGui(false);
    }

    public void PlayGame()
    {
        if (playerPrefab)
            m_dinoClone = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        StartCoroutine(Spawn());

        GameGUIManager.Ins.ShowGameGui(true);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        m_isGamebegun = true;

        if(stonePrefabs != null && stonePrefabs.Length> 0)
        {
            while (!m_isGameover)
            {
                int randIdx = Random.Range(0, stonePrefabs.Length);

                if (stonePrefabs[randIdx] != null)
                {
                    Instantiate(stonePrefabs[randIdx], new Vector3(m_dinoClone.transform.position.x, Random.Range(8f, 10f), 0f), Quaternion.identity);
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }

        yield return null;
    }
}
