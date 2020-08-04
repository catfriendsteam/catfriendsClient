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

    //곱창집 게이지 선언
    public Slider slider_Gobchang;
    public bool isClicked_Gobchang;
    public float timer_Gobchang;
    public Text gageText_Gobchang;

    //헬스장 게이지 선언
    public Slider slider_Health;
    public bool isClicked_Health;
    public float timer_Health;
    public Text gageText_Health;

    //냥냐랜드 게이지 선언
    public Slider slider_Land;
    public bool isClicked_Land;
    public float timer_Land;
    public Text gageText_Land;

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

        //곱창집 선언
        SetMaxGage_Gobchang(100);
        SetGage_Gobchang(0);
        isClicked_Gobchang = false;
        timer_Gobchang = 0.0f;

        //헬스장 선언
        SetMaxGage_Health(100);
        SetGage_Health(0);
        isClicked_Health = false;
        timer_Health = 0.0f;

        //냥냐랜드 선언
        SetMaxGage_Land(100);
        SetGage_Land(0);
        isClicked_Land = false;
        timer_Land = 0.0f;

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


        //곱창집 업데이트 문

        gageText_Gobchang.text = Mathf.CeilToInt(slider_Gobchang.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_Gobchang.value > 0)
        {
            if (isClicked_Gobchang == true)
            {
                timer_Gobchang += Time.deltaTime;
            }

            if (timer_Gobchang >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Gobchang = false;
                slider_Gobchang.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
        }

        //헬스장 업데이트 문

        gageText_Health.text = Mathf.CeilToInt(slider_Health.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_Health.value > 0)
        {
            if (isClicked_Health == true)
            {
                timer_Health += Time.deltaTime;
            }

            if (timer_Health >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Health = false;
                slider_Health.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
        }
        //냥냐랜드 업데이트 문

        gageText_Land.text = Mathf.CeilToInt(slider_Land.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_Land.value > 0)
        {
            if (isClicked_Land == true)
            {
                timer_Land += Time.deltaTime;
            }

            if (timer_Land >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Land = false;
                slider_Land.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
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

    //곱창집 함수



    public void SetMaxGage_Gobchang(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_Gobchang.maxValue = gageValue;
        slider_Gobchang.value = gageValue;
    }

    public void SetGage_Gobchang(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_Gobchang.value = gageValue;
    }

    //헬스장 함수
    
    public void SetMaxGage_Health(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_Health.maxValue = gageValue;
        slider_Health.value = gageValue;
    }

    public void SetGage_Health(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_Health.value = gageValue;
    }   

    //냥냐랜드 함수

    public void SetMaxGage_Land(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_Land.maxValue = gageValue;
        slider_Land.value = gageValue;
    }

    public void SetGage_Land(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_Land.value = gageValue;
    }
}
