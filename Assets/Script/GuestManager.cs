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
        int ranPoint = Random.Range(0, 9);

        GameObject guestMove = Instantiate(GuestObjs[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = guestMove.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = guestMove.GetComponent<SpriteRenderer>();
        GuestMove guestLogic = guestMove.GetComponent<GuestMove>();
        if (ranPoint < 5)
        {
            rigid.velocity = new Vector2(guestLogic.speed  , 0);
        }

        else if(ranPoint >= 5) //  right Spawn
        {
            rigid.velocity = new Vector2(guestLogic . speed * (-1), 0 );
            sprite.flipX = true;
        }

     
    }


}