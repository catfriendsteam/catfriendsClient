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
    public GameObject menu_setting;
    public GameObject menu_post;
    public GameObject menu_center;
    public GameObject menu_Donation;
    public GameObject center_statButton;
    public GameObject center_openButton;
    public GameObject center_donation;
    public GameObject stats_chunbae;
    public GameObject stats_center;
    public GameObject chunbae, quest, shop, center;
    bool isStoreClicked;

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

    public void open_ChunbaeButton()
    {
        menu_chunbae.SetActive(true);
    }
    public void open_ChunbaeStats()
    {
        stats_chunbae.SetActive(true);
    }
    public void open_Setting()
    {
        menu_setting.SetActive(true);
    }
    public void open_Post()
    {
        menu_post.SetActive(true);
    }
    public void open_CenterUpgrade()
    {
        menu_center.SetActive(true);
        center_openButton.SetActive(false);
        center_statButton.SetActive(false);
        center_donation.SetActive(false);
    }
    public void open_CenterStats()
    {
        stats_center.SetActive(true);
    }
    public void open_Donation()
    {
        menu_Donation.SetActive(true);
    }


    public void close_ChunbaeButton()
    {
        menu_chunbae.SetActive(false);
    }
    public void close_ChunbaeStats()
    {
        stats_chunbae.SetActive(false);
    }
    public void close_Setting()
    {
        menu_setting.SetActive(false);
    }
    public void close_Post()
    {
        menu_post.SetActive(false);
    }
    public void close_CenterUpgrade()
    {
        menu_center.SetActive(false);
        center_openButton.SetActive(true);
        center_statButton.SetActive(true);
        center_donation.SetActive(true);
    }
    public void close_CenterStats()
    {
        stats_center.SetActive(false);
    }
    public void close_Donation()
    {
        menu_Donation.SetActive(false);
    }


    public void gotoCafe()
    {
        SceneManager.LoadScene("Cafe");
    }
    public void gotoMain()
    {
        SceneManager.LoadScene("Main");
    }

}
