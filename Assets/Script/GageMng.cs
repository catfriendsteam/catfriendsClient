using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageMng : MonoBehaviour
{


    public StatusManager statusMng;
    public float fevertime;
    public float fevercount;
    public GameObject Fevergage_Text;
    public bool isfever;


    // 카페 게이지 선언
    public Slider slider;
    public bool isClicked;
    public float timer;
    public Text gageText;
    public bool fever_cafe;
    public float cafefever;

    //치킨집 게이지 선언
    public Slider slider_chicken;
    public bool isClicked_chicken;
    public float timer_chicken;
    public Text gageText_chicken;
    public bool fever_chicken;
    public float chickenfever;

    //곱창집 게이지 선언
    public Slider slider_gobchang;
    public bool isClicked_Gobchang;
    public float timer_Gobchang;
    public Text gageText_Gobchang;
    public bool fever_gobchang;
    public float gobchangfever;


    //헬스장 게이지 선언
    public Slider slider_health;
    public bool isClicked_Health;
    public float timer_Health;
    public Text gageText_Health;
    public bool fever_health;
    public float healthfever;


    //냥냐랜드 게이지 선언
    public Slider slider_land;
    public bool isClicked_Land;
    public float timer_Land;
    public Text gageText_Land;
    public bool fever_land;
    public float landfever;


    void Awake()
    {
        fevertime = 1.0f;
        fevercount = 1.0f + cafefever + chickenfever + gobchangfever + healthfever + landfever;
 

        //카페 선언
        SetMaxGage(100);
        SetGage(0);
        isClicked = false;
        timer = 0.0f;

        //피버 테스트

        isfever = false;

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
      


        AllFeverCheck();


        CheckCafeGage();
        CheckChickenGage();
        CheckGobchangGage();
        CheckHealthGage();
        CheckLandGage();

        if (isfever == true)
        {
            Text[] Fevertext = GameObject.FindGameObjectWithTag("Fever_Text").GetComponentsInChildren<Text>();
            Fevertext[0].text = fevercount.ToString();

        }
    }












    //모든 가게의 피버 체크
    void AllFeverCheck()
    {
        if (fever_cafe == false && fever_chicken == false && fever_gobchang == false && fever_health == false && fever_land == false)
        {
            isfever = false;
            Fevergage_Text.SetActive(false);
        }
        else   
        {
            isfever = true;
          

            if (isfever == true)
            {
                fevercount = 1.0f + cafefever + chickenfever + gobchangfever + healthfever + landfever;
                Fevergage_Text.SetActive(true);

                if (fever_cafe == true)
                {
                    slider.value -= Time.deltaTime * fevertime;

                    cafefever = 0.5f;

                    if (slider.value == 0)
                    {
                        fever_cafe = false;
                        cafefever = 0.0f;
                    }
                }

                if (fever_chicken == true)
                {
                    slider_chicken.value -= Time.deltaTime * fevertime;

                   chickenfever = 0.5f;

                    if (slider_chicken.value == 0)
                    {
                        fever_chicken = false;
                        chickenfever = 0.0f;
                    }
                }

                if (fever_gobchang == true)
                {
                    slider_gobchang.value -= Time.deltaTime * fevertime;

                    gobchangfever = 0.5f;

                    if (slider_gobchang.value == 0)
                    {
                        fever_gobchang = false;
                       gobchangfever = 0.0f;
                    }
                }

                if (fever_health == true)
                {
                    slider_health.value -= Time.deltaTime * fevertime;

                    healthfever = 0.5f;

                    if (slider_gobchang.value == 0)
                    {
                        fever_health = false;
                        healthfever = 0.0f;
                    }
                }
                if (fever_land == true)
                {
                    slider_land.value -= Time.deltaTime * fevertime;

                    landfever = 0.5f;

                    if (slider_land.value == 0)
                    {
                        fever_land = false;
                       landfever = 0.0f;
                    }
                }



            }
        }
    }
    //피버 상태에 따른 피버텍스트 보이게 하기
    




    //카페 함수

        
    void CheckCafeGage() //카페 터치에 따른 게이지 상태 체크
    {
       
        gageText.text = Mathf.CeilToInt(slider.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider.value > 0 && fever_cafe == false)
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
            if (slider.value == 100)
            {
                fever_cafe = true;
            
            }
        }
    }

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

    void CheckChickenGage()  //카페 터치에 따른 게이지 상태 체크
    {

        gageText_chicken.text = Mathf.CeilToInt(slider_chicken.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_chicken.value > 0 && fever_chicken == false)
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
            if (slider_chicken.value == 100)
            {
                fever_chicken = true;

            }
        }
    }
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

    void CheckGobchangGage()  //카페 터치에 따른 게이지 상태 체크
    {

        gageText_Gobchang.text = Mathf.CeilToInt(slider_gobchang.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_gobchang.value > 0 && fever_gobchang == false)
        {
            if (isClicked_Gobchang == true)
            {
                timer_Gobchang += Time.deltaTime;
            }

            if (timer_Gobchang >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Gobchang = false;
                slider_gobchang.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (slider_gobchang.value == 100)
            {
                fever_gobchang = true;
            }
        }
    }
    public void SetMaxGage_Gobchang(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_gobchang.maxValue = gageValue;
        slider_gobchang.value = gageValue;
    }
    public void SetGage_Gobchang(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_gobchang.value = gageValue;
    }


    //헬스장 함수
    void CheckHealthGage()  //카페 터치에 따른 게이지 상태 체크
    {

        gageText_Health.text = Mathf.CeilToInt(slider_health.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_health.value > 0 && fever_health == false)
        {
            if (isClicked_Health == true)
            {
                timer_Health += Time.deltaTime;
            }

            if (timer_Health >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Health = false;
                slider_health.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (slider_health.value == 100)
            {
                fever_health = true;
            }
        }
    }
    public void SetMaxGage_Health(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_health.maxValue = gageValue;
        slider_health.value = gageValue;
    }
    public void SetGage_Health(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_health.value = gageValue;
    }


    //냥냐랜드 함수
    void CheckLandGage()  //카페 터치에 따른 게이지 상태 체크
    {

        gageText_Land.text = Mathf.CeilToInt(slider_land.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider_land.value > 0 && fever_land == false)
        {
            if (isClicked_Land == true)
            {
                timer_Land += Time.deltaTime;
            }

            if (timer_Land >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Land = false;
                slider_land.value -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (slider_land.value == 100)
            {
                fever_land = true;
            }
        }
    }
    public void SetMaxGage_Land(int gageValue)   // 게이지 최대값 설정 함수
    {
        slider_land.maxValue = gageValue;
        slider_land.value = gageValue;
    }
    public void SetGage_Land(int gageValue)   // 게이지 초기값 설정 함수
    {
        slider_land.value = gageValue;
    }
}
