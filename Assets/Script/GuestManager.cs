using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] GuestObjs;

    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();

            //랜덤하게 딜래이를 준다.
            maxSpawnDelay = Random.Range(5f, 8f);

            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        //0부터 시작하고, 그리고 랜덤한게 2개 있다.
        int ranEnemy = Random.Range(0, 2);
        //0부터 시작하고, 그리고 랜덤으로 나오는 장소가 4개 있다.
        int ranPoint = Random.Range(0, 4);

        Instantiate(GuestObjs[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);


    }


}