using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageMng : MonoBehaviour
{


    public StatusManager statusMng;



    // 카페 게이지 선언
    public Slider slider;
    public bool isClicked;
    public float timer;
    public Text gageText;

    //치킨집 게이지 선언
    public Slider slider_chicken;
    public bool isClicked_chicken;
    public float timer_chicken;
    public Text gageText_chicken;



    void Awake()
    {
        //카페 선언
        SetMaxGage(100);
        SetGage(0);
        isClicked = false;
        timer = 0.0f;

        //치킨집 선언
        SetMaxGage_chicken(100);
        SetGage_chicken(0);
        isClicked_chicken = false;
        timer_chicken = 0.0f;

    }

    void Update()
    {

        //카페 업데이트 문

        gageText.text = Mathf.CeilToInt(slider.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider.value > 0)
        {
            if (isClicked == true)
            {
                timer += Time.deltaTime;
            }

            if (timer >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked = false;
                slider.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
        }


        //치킨 업데이트 문

        gageText_chicken.text = Mathf.CeilToInt(slider_chicken.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_chicken.value > 0)
        {
            if (isClicked_chicken == true)
            {
                timer_chicken += Time.deltaTime;
            }

            if (timer_chicken >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_chicken = false;
                slider_chicken.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
        }






    }



    //카페 함수

    public void SetMaxGage(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider.maxValue = gageValue;
        slider.value = gageValue;
    }

    public void SetGage(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider.value = gageValue;
    }


    //치킨 함수



    public void SetMaxGage_chicken(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_chicken.maxValue = gageValue;
        slider_chicken.value = gageValue;
    }

    public void SetGage_chicken(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_chicken.value = gageValue;
    }

}
