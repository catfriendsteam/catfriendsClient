using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] GuestObjs;

    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public Vector3 recieveSpawnVector;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();

            //랜덤하게 딜래이를 준다. 숫자~ 숫자
            maxSpawnDelay = Random.Range(2f, 3f);

            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        //0부터 시작하고, 그리고 랜덤한게 2개 있다.
        int ranEnemy = Random.Range(0, 3);
        //0부터 시작하고, 그리고 랜덤으로 나오는 장소가 10개 있다.
        int ranPoint = Random.Range(0, 10);

        GameObject guest = Instantiate(GuestObjs[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);

        //게스트의 트랜스폼을 content라는 태그를 가진 content를 부모로 삼게 하여 content의 좌표로? 들어간다.
        guest.transform.SetParent(GameObject.FindGameObjectWithTag("Content").transform, false);
       
        //content의 자식으로 생성이 되게 만들었으니 게스트의 좌표는 다시 초기화한다. 
        guest.transform.localPosition = Vector3.zero;
        
        //리시브스폰백터 변수를 이용하여 스폰포인트의 로칼포지션을 받는다.
        recieveSpawnVector = spawnPoints[ranPoint].localPosition;
        //게스트에 스폰포인트의 로칼포지션을 넣는다.
        guest.transform.localPosition = recieveSpawnVector;



        Rigidbody2D rigid = guest.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = guest.GetComponent<SpriteRenderer>();
        GuestMove guestLogic = guest.GetComponent<GuestMove>();


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