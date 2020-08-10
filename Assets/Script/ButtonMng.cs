using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMng : MonoBehaviour
{
    
    public MoveAndAnimation_Chunbae moveAndAnimation_Chunbae;

    public GageMng gageMng;
    public StatusManager statusMng;


    public GameObject menu_chunbae;

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

        //춘배 에니메이션 스크립트에서 트리거를 호출하여 터치할 때마다 에니메이션을 하게 만듭니다.
        moveAndAnimation_Chunbae.ToTouched_Chunbae();
        
        
        //카페 게이지 상승


        if (nestedScrollMng.targetIndex >= 0 && nestedScrollMng.targetIndex < 1)
        {
            if (gageMng.isfever_cafe == false)
            {
                
                slider.value += statusMng.touch_value;   //게이지 1%씩 증가
                gageMng.isClicked_cafe = true;
                gageMng.timer_cafe = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if(gageMng.isfever_cafe == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //치킨 게이지 상승
        if (nestedScrollMng.targetIndex >= 1 && nestedScrollMng.targetIndex < 2)
        {
            if (gageMng.isfever_chicken == false)
            {
                slider_chicken.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_chicken = true;
                gageMng.timer_chicken = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.isfever_chicken == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }



        //곱창 게이지 상승
        if (nestedScrollMng.targetIndex >= 2 && nestedScrollMng.targetIndex < 3)
        {
            if (gageMng.isfever_gobchang == false)
            {
                slider_Gobchang.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Gobchang = true;
                gageMng.timer_Gobchang = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.isfever_gobchang == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }

        //헬스 게이지 상승
        if (nestedScrollMng.targetIndex >= 3 && nestedScrollMng.targetIndex < 4)
        {
            if (gageMng.isfever_health == false)
            {
                slider_Health.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Health = true;
                gageMng.timer_Health = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.isfever_health == true)
            {
                statusMng.Touch_IncreaseMoney();
            }
        }
        //냥냐랜드 게이지 상승
        if (nestedScrollMng.targetIndex >= 4 && nestedScrollMng.targetIndex < 5)
        {
            if (gageMng.isfever_land == false)
            {
                slider_Land.value += 1;   //게이지 1%씩 증가
                gageMng.isClicked_Land = true;
                gageMng.timer_Land = 0.0f;

                statusMng.Touch_IncreaseMoney();
            }
            else if (gageMng.isfever_land == true)
            {
                statusMng.Touch_IncreaseMoney();
            }

        }


    }


    public void ClickChunBaeButton()
    {
        menu_chunbae.SetActive(true);
    }


    public void XButton_ChunbaeButton()
    {
        menu_chunbae.SetActive(false);
    }



    public void InsideCafe()
    {
        SceneManager.LoadScene("Cafe");
    }
    public void OutsideMain_Cafe()
    {
        SceneManager.LoadScene("Main");
    }

}
