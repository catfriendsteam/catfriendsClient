using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CenterCharMoving : MonoBehaviour
{
    //고양이 각각의 움직임
    //선행포인트 이벤트 발현

    //고양이관련변수
    public SpriteRenderer sprite;
    public Rigidbody2D catRigid;

    public float speed = 0.1f;
    public bool CanRunRandomize;//이 변수가 true가 되어야 랜덤 움직임 가능
    Vector3 velocity;
    Vector2 curPos = Vector2.zero;

    //jump 관련 변수
    public float jumpheight;
    bool jumping = false;

    void Start()
    {
        velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        //고양이 움직임
       transform.position += velocity.normalized*speed;

        //위아래 경계선 체크
        if (transform.position.y >= 0.24f)
        {
            velocity.y *= velocity.y > 0 ? -1 : 1;
        }
        else if (transform.position.y <= -3.87f)
            velocity.y *= velocity.y > 0 ? 1 : -1;

        /*//점프구간
        Vector2 cur = transform.localPosition;
        if (cur.x >= 4100f && cur.x <= 4200f&&cur.y<=-1470f&&cur.y>=-1670f)
        {
            StartCoroutine(Jumpp());
        }*/

        //flip
        if (velocity.x >= 0)
            sprite.flipX = true;
        else sprite.flipX = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //물체와 부딪혔을때 경로 재설정
        if (collision.tag == "CenterObj")
        {
            //Debug.Log("부딪힘");
            velocity.x *= -1;
            velocity.y *= -1;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //고양이가 캔버스 안에 있을때
        if (collision.name == "Center")
        {
            Vector2 cur = transform.localPosition;
            if (cur.x >= 4100f && cur.x <= 4200f && cur.y <= -1470f && cur.y >= -1670f)
            {
                StartCoroutine(Jumpp());
            }

            if (CanRunRandomize)
            {
                //랜덤움직임 무한반복을 막기 위해 시간간격을 준다.
                CanRunRandomize = false;
                Randomize();

                //타이머 함수를 외부 스레드에서 실행..동시작업.......
                StartCoroutine(Timer());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //고양이가 캔버스를 벗어났을때
        if (collision.name == "Center")
        {
            float dir = transform.position.x - collision.transform.position.x;
            if (dir >= 0)
            {
                //고양이가 화면 오른쪽으로 벗어났을때 방향전환
                velocity.x *= velocity.x > 0 ? -1 : 1;
            }
            else
            {
                //고양이가 화면 왼쪽으로 벗어났을때
                velocity.x *= velocity.x > 0 ? 1 : -1;
            }
        }
    }

   void jump()
    {
        if (!jumping)
        {
            jumping = true;
            curPos = transform.localPosition;
            catRigid.gravityScale = 1;
            catRigid.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
        }
    }

    void GroundCheck()
    {
        if (jumping)
        {
            if (transform.localPosition.y<curPos.y)
            {
                catRigid.velocity = Vector2.zero;
                transform.localPosition = new Vector2(curPos.x, curPos.y);
                catRigid.gravityScale = 0;
                CanRunRandomize = true;
                Randomize();
            }
        }
    }
    IEnumerator Jumpp()
    {
        velocity.x = 0f;
        velocity.y = 0f;
        CanRunRandomize = false;
        jump();
        GroundCheck();
        yield return new WaitForSeconds(5f);
        jumping = false;
    }

    IEnumerator Timer()
    {
        int curtime=0;
        while (!CanRunRandomize)
        {
            curtime++;
            if (curtime == 7)
                CanRunRandomize = true;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }

    void Randomize()
    {
        float randomX, randomY;
        randomX = Random.Range(-1f, 1.0f);
        randomY = Random.Range(-1f, 1.0f);

        velocity.x = randomX;
        velocity.y = randomY;
    }

}