using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking inGameRanking;
    private GameObject[] runners;
    List<RankingSystem> sortArray = new List<RankingSystem>();

    public bool isGameOver = false;


    private void Awake()
    {
        instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runner");
        inGameRanking = FindObjectOfType<InGameRanking>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < runners.Length; i++)
        {
            sortArray.Add(runners[i].GetComponent< RankingSystem>());
        }
    }

   
    void CalculateRank()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();
        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;
        sortArray[5].rank = 6;
        sortArray[6].rank = 7;

        inGameRanking.a = sortArray[6].name;
        inGameRanking.b = sortArray[5].name;
        inGameRanking.c = sortArray[4].name;
        inGameRanking.d = sortArray[3].name;
        inGameRanking.e = sortArray[2].name;
        inGameRanking.f = sortArray[1].name;
        inGameRanking.g = sortArray[0].name;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateRank();
    }
}
