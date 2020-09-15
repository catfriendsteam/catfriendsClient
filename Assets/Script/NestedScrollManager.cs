using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public StoreManage StoreManage;
    public StatusManager Statusmng;

    const int SIZE = 5;
    float[] pos = new float[SIZE];
    public float distance, curPos, targetPos;
    bool isDrag;
    public int targetIndex;

    //해금되지않는것을 신경써야 하는 카페용
    int SIZE_Unactive = 0;
    float distance_unactive = 0;
    float Max_targetPoint = 0;

    void Start()
    {
        //받아오는 TargetPos로 초기 시작화면을 조정해보자
        firstSet();


        //거리에 따라 -~1인 pos대입
        distance = 1f / (SIZE - 1);
        distance_unactive = 1f / (SIZE - 1);


        // pos값 초기 설정이지만 나는 뒤에서 해금 안되면 못이동하도록 제약을 걸 예정
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }





    void firstSet()
    {
        //받아오는 TargetPos로 초기 시작화면을 조정해보자
            targetPos = Statusmng.TargetPos;
        //초기 UI 불러오는 것
        if (SceneManager.GetActiveScene().name == "Cafe")
            StoreManage.TabClick();
    }




    //pos[i]의 값을 최대값으로 넣어버립니다.
    void SetSize_TocheckISActiveStore()
    {
        if (Statusmng.Land_Active == true)
        {
            SIZE_Unactive = 5;
            Max_targetPoint = distance_unactive * (SIZE_Unactive-1);
        }
        else if (Statusmng.Health_Active == true && Statusmng.Land_Active == false)
        {
            SIZE_Unactive = 4;
            Max_targetPoint = distance_unactive * (SIZE_Unactive - 1);
        }
        else if (Statusmng.Gobchang_Active == true && Statusmng.Health_Active == false && Statusmng.Land_Active == false)
        {
            SIZE_Unactive = 3;
            Max_targetPoint = distance_unactive * (SIZE_Unactive - 1);
        }
        else if (Statusmng.Chicken_Active == true && Statusmng.Gobchang_Active == false && Statusmng.Health_Active == false && Statusmng.Land_Active == false)
        {
            SIZE_Unactive = 2;
            Max_targetPoint = distance_unactive * (SIZE_Unactive - 1);
        }
        else if (Statusmng.Cafe_Active == true && Statusmng.Chicken_Active == false && Statusmng.Gobchang_Active == false && Statusmng.Health_Active == false && Statusmng.Land_Active == false)
        {
            SIZE_Unactive = 1;
            Max_targetPoint = distance_unactive * (SIZE_Unactive - 1);
        }
    }



    float SetPos()
    {
        //가게 안에서 언엑티브한 조건에 걸려서 넘어가면 안될 때 조건
        SetSize_TocheckISActiveStore();
        if (SceneManager.GetActiveScene().name == "Cafe")
        {
            for (int i = 0; i < SIZE_Unactive; i++)
                if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
                {
                    targetIndex = i;
                   

                    return pos[i];
                }


            return 0;
        }

        //평범한 이동의 경우
        else
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
                

                
                //가게 안에서만 해금되지 않은 가게의 최대 타겟값을 제한하여 해금안되면 움직이지 못하게 하는 경우를 추가한 코드
                if (SceneManager.GetActiveScene().name == "Cafe" && targetPos == Max_targetPoint)
                {

                    targetPos = curPos;
                }
                else
                {
                    ++targetIndex;
                    targetPos = curPos + distance;
                }

            }

        }

        //테스트용
        //  print(curPos + "/" + targetPos + "/" + targetIndex);


        if (StoreManage != null)
        {
            StoreManage.TabClick();
        }
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Cafe" && targetPos == Max_targetPoint)
        {
           // Mathf.Clamp(scrollbar.value, 0f, Max_targetPoint);

             if (isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, Max_targetPoint, 0.1f);
            if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
           

        }


        //가게가 아니면 모든 경우
        else
        {
           // Mathf.Clamp(scrollbar.value, 0f, 1f);
            if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
    
        }
          

    }
}

/* 유튜브 참고https://www.youtube.com/watch?time_continue=142&v=K_ujyelRZUA&feature=emb_logo */
