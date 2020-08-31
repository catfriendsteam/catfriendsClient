using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public StoreManage StoreManage;

    const int SIZE = 5;
    float[] pos = new float[SIZE];
    public float distance, curPos, targetPos;
    bool isDrag;
    public int targetIndex;

    void Start()
    {
        //거리에 따라 -~1인 pos대입
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }
    float SetPos()
    {

        //절반 거리를 기준으로 가까운 위치를 반환하는 함수
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;

                // 스토어매니저 반응 받기
             

                return pos[i];
            }
        return 0;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = SetPos();


        

    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();


        



        //절반거리를 넘지 않아도 마우스를 빠르게 이동하면
        if (curPos == targetPos)
        {
            // 속도 테스트용 // print(eventData.delta.x);
            //스크롤이 왼쪽으로 빠르게 이동시 목표가 하나 감소
            //숫자 18로 수치 조정 가능
            if (eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }

            //스크롤이 오른쪽으로 빠르게 이동시 목표가 하나 증가
            else if (eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }

        }

        //테스트용
        //  print(curPos + "/" + targetPos + "/" + targetIndex);


        if (StoreManage != null)
        {
            StoreManage.TabClick();
            print("성공1");
        }
    }


    void Update()
    {
        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
    }
}

/* 유튜브 참고https://www.youtube.com/watch?time_continue=142&v=K_ujyelRZUA&feature=emb_logo */
