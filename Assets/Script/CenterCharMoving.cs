using UnityEngine;

public class CenterCharMoving : MonoBehaviour
{
    Vector2 goalPos;
    public int randomPosX, randomPosY;
    float speed = 0.5f;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        goalPos.x = 2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomMove();
        Debug.Log(transform.position.x);
    }
    void Update()
    {
        //랜덤한 목표지점으로 이동
        this.transform.position = Vector2.MoveTowards(this.transform.position, goalPos, speed * Time.deltaTime);
        if (transform.position.x == goalPos.x)
            RandomMove();
            
    }
    void RandomMove()
    {
        //랜덤한 목표지점 지정
        randomPosX = Random.Range(-2, 8);
        randomPosY = Random.Range(-3, 1);

        //Debug.Log(transform.position.x - goalPos.x);
        //좌우 방향 바꿈 방향벡터가 음수이면 방향을 전환하면 될것같은데 어떻게 하지
        //현재좌표가 왜 0이 아닐까..............ㅠㅠㅠ
        bool dir = false;
        spriteRenderer.flipX = (randomPosX < goalPos.x ? dir:!dir);

        //randompos 지정
        goalPos.x = randomPosX;
        goalPos.y = randomPosY;
    }
}