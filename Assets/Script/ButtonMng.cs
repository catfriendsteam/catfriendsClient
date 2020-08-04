using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour
{

    public GageMng gageMng;
    public StatusManager statusMng;


    public NestedScrollManager nestedScrollMng;





    //카페 슬라이더
    public Slider slider;
    //치킨 슬라이더
    public Slider slider_chicken;
    //곱창 슬라이더
    public Slider slider_Gobchang;
    //헬스 슬라이더
    public Slider slider_Health;
    //냥냐랜드 슬라이더
    public Slider slider_Land;









    public void IncreaseGage()
    {
        //카페 게이지 상승
        if (nestedScrollMng.targetIndex >= 0 && nestedScrollMng.targetIndex < 1)
        {
            if (gageMng.fever_cafe == false)
            {
                slider.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked = true;
                gageMng.timer = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if(gageMng.fever_cafe == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //치킨 게이지 상승
        if (nestedScrollMng.targetIndex >= 1 && nestedScrollMng.targetIndex < 2)
        {
            if (gageMng.fever_chicken == false)
            {
                slider_chicken.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_chicken = true;
                gageMng.timer_chicken = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.fever_chicken == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //곱창 게이지 상승
        if (nestedScrollMng.targetIndex >= 2 && nestedScrollMng.targetIndex < 3)
        {
            if (gageMng.fever_gobchang == false)
            {
                slider_Gobchang.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Gobchang = true;
                gageMng.timer_Gobchang = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.fever_gobchang == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }

        //헬스 게이지 상승
        if (nestedScrollMng.targetIndex >= 3 && nestedScrollMng.targetIndex < 4)
        {
            if (gageMng.fever_health == false)
            {
                slider_Health.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Health = true;
                gageMng.timer_Health = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.fever_health == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }
        //냥냐랜드 게이지 상승
        if (nestedScrollMng.targetIndex >= 4 && nestedScrollMng.targetIndex < 5)
        {
            if (gageMng.fever_land == false)
            {
                slider_Land.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Land = true;
                gageMng.timer_Land = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.fever_land == true)
            {
                statusMng.Touch_IncreaseMoney();
            }

        }


    }


}
