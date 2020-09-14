using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingletonMng : MonoBehaviour
{
    public static SingletonMng instance;

    public long Money;
    public int Diamond;
    public int GoodPoint;

    public float fevertime_default;
    //피버 1.5 2 2.5 새어주는 변수
    public float fevercount;

    public GameObject Fevergage_Text;
    public bool isfever; // 피버 상태인지 아닌지 받아주는 변수 

    // 카페 게이지 선언
    public float gage_cafe;
    public Slider slider_cafe;
    public bool isClicked_cafe;
    public float timer_cafe;
    public Text gageText_cafe;
    public bool isfever_cafe;
    public float feverfigure_cafe;

    //치킨집 게이지 선언
    public float gage_chicken;
    public Slider slider_chicken;
    public bool isClicked_chicken;
    public float timer_chicken;
    public Text gageText_chicken;
    public bool isfever_chicken;
    public float feverfigure_chicken;

    //곱창집 게이지 선언
    public float gage_gobchang;
    public Slider slider_gobchang;
    public bool isClicked_Gobchang;
    public float timer_Gobchang;
    public Text gageText_Gobchang;
    public bool isfever_gobchang;
    public float feverfigure_gobchang;


    //헬스장 게이지 선언
    public float gage_health;
    public Slider slider_health;
    public bool isClicked_Health;
    public float timer_Health;
    public Text gageText_Health;
    public bool isfever_health;
    public float feverfigure_health;


    //냥냐랜드 게이지 선언
    public float gage_land;
    public Slider slider_land;
    public bool isClicked_Land;
    public float timer_Land;
    public Text gageText_Land;
    public bool isfever_land;
    public float feverfigure_land;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        fevertime_default = 10f;

        //카페 선언
        isClicked_cafe = false;
        timer_cafe = 0.0f;
        slider_cafe = GameObject.Find("Gagebar_cafe").GetComponent<Slider>();
        gageText_cafe = GameObject.Find("Text_cafe").GetComponent<Text>();

        //치킨집 선언
        isClicked_chicken = false;
        timer_chicken = 0.0f;
        slider_chicken = GameObject.Find("Gagebar_chicken").GetComponent<Slider>();
        gageText_chicken = GameObject.Find("Text_chicken").GetComponent<Text>();

        //곱창집 선언
        isClicked_Gobchang = false;
        timer_Gobchang = 0.0f;
        slider_gobchang = GameObject.Find("Gagebar_Gobchang").GetComponent<Slider>();
        gageText_Gobchang = GameObject.Find("Text_Gobchang").GetComponent<Text>();

        //헬스장 선언
        isClicked_Health = false;
        timer_Health = 0.0f;
        slider_health = GameObject.Find("Gagebar_Health").GetComponent<Slider>();
        gageText_Health = GameObject.Find("Text_Health").GetComponent<Text>();

        //냥냐랜드 선언
        isClicked_Land = false;
        timer_Land = 0.0f;
        slider_land = GameObject.Find("Gagebar_Land").GetComponent<Slider>();
        gageText_Land = GameObject.Find("Text_Land").GetComponent<Text>();

        //모든 가게 슬라이드의 기본 값과 최대 값 설정
        SetMaxGageAndGage(100, 0);
    }

    void Update()
    {
        AllFeverCheck();

        CheckCafeGage();
        CheckChickenGage();
        CheckGobchangGage();
        CheckHealthGage();
        CheckLandGage();

        if (SceneManager.GetActiveScene().name == "Main")
        {
            ToshowFeverTextWhenIsfeferTrue();
            slider_cafe.value = gage_cafe;
            slider_chicken.value = gage_chicken;
            slider_gobchang.value = gage_gobchang;
            slider_health.value = gage_health;
            slider_land.value = gage_land;

            gageText_cafe.text = Mathf.CeilToInt(gage_cafe).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
            gageText_chicken.text = Mathf.CeilToInt(gage_chicken).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
            gageText_Gobchang.text = Mathf.CeilToInt(gage_gobchang).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
            gageText_Health.text = Mathf.CeilToInt(gage_health).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
            gageText_Land.text = Mathf.CeilToInt(gage_land).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        }
        if (Input.GetKeyDown("q"))
        {
            Debug.Log(fevercount);
        }
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이름이 Main인 씬에서만 실행되는 코드
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Fevergage_Text = GameObject.Find("Fevergage_Text");

            //카페 선언
            slider_cafe = GameObject.Find("Gagebar_cafe").GetComponent<Slider>();
            gageText_cafe = GameObject.Find("Text_cafe").GetComponent<Text>();

            //치킨집 선언
            slider_chicken = GameObject.Find("Gagebar_chicken").GetComponent<Slider>();
            gageText_chicken = GameObject.Find("Text_chicken").GetComponent<Text>();

            //곱창집 선언
            slider_gobchang = GameObject.Find("Gagebar_Gobchang").GetComponent<Slider>();
            gageText_Gobchang = GameObject.Find("Text_Gobchang").GetComponent<Text>();

            //헬스장 선언
            slider_health = GameObject.Find("Gagebar_Health").GetComponent<Slider>();
            gageText_Health = GameObject.Find("Text_Health").GetComponent<Text>();

            //냥냐랜드 선언
            slider_land = GameObject.Find("Gagebar_Land").GetComponent<Slider>();
            gageText_Land = GameObject.Find("Text_Land").GetComponent<Text>();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //피버 상태일 때 피버텍스트에 피버 변수를 넣어 피버 변수의 숫자가 나타나게 합니다.
    void ToshowFeverTextWhenIsfeferTrue()
    {
        if (isfever == true)
        {
            Fevergage_Text.SetActive(true);
            Text[] Fevertext = GameObject.FindGameObjectWithTag("Fever_Text").GetComponentsInChildren<Text>();
            Fevertext[0].text = fevercount.ToString();
        }
        else if (isfever == false)
        {
            Fevergage_Text.SetActive(false);
        }

    }




    //모든 가게의 피버 체크
    void AllFeverCheck()
    {
        if (isfever_cafe == false && isfever_chicken == false && isfever_gobchang == false && isfever_health == false && isfever_land == false)
        {
            isfever = false;
            //ToshowFeverTextWhenIsfeferTrue();
        }
        else
        {
            isfever = true;

            if (isfever == true)
            {
                fevercount = 1.0f + feverfigure_cafe + feverfigure_chicken + feverfigure_gobchang + feverfigure_health + feverfigure_land;
                //ToshowFeverTextWhenIsfeferTrue();

                if (isfever_cafe == true && gage_cafe > 0)
                {
                    gage_cafe -= Time.deltaTime * (100 / fevertime_default);
                    
                    feverfigure_cafe = 0.5f;

                    if (gage_cafe <= 0)
                    {
                        isfever_cafe = false;
                        feverfigure_cafe = 0.0f;
                        gage_cafe = 0;
                    }
                }

                if (isfever_chicken == true && gage_chicken > 0)
                {
                    gage_chicken -= Time.deltaTime * (100 / fevertime_default);

                    feverfigure_chicken = 0.5f;

                    if (gage_chicken <= 0)
                    {
                        isfever_chicken = false;
                        feverfigure_chicken = 0.0f;
                        gage_chicken = 0;
                    }
                }

                if (isfever_gobchang == true && gage_gobchang > 0)
                {
                    gage_gobchang -= Time.deltaTime * (100 / fevertime_default);

                    feverfigure_gobchang = 0.5f;

                    if (gage_gobchang <= 0)
                    {
                        isfever_gobchang = false;
                        feverfigure_gobchang = 0.0f;
                        gage_gobchang = 0;
                    }
                }

                if (isfever_health == true && gage_health > 0)
                {
                    gage_health -= Time.deltaTime * (100 / fevertime_default);

                    feverfigure_health = 0.5f;

                    if (gage_health <= 0)
                    {
                        isfever_health = false;
                        feverfigure_health = 0.0f;
                        gage_health = 0;
                    }
                }
                if (isfever_land == true && gage_land > 0)
                {
                    gage_land -= Time.deltaTime * (100 / fevertime_default);

                    feverfigure_land = 0.5f;

                    if (gage_land <= 0)
                    {
                        isfever_land = false;
                        feverfigure_land = 0.0f;
                        gage_land = 0;
                    }
                }



            }
        }
    }
    //피버 상태에 따른 피버텍스트 보이게 하기

    public void SetMaxGageAndGage(int maxgagevalue, int gagevalue)
    {
        slider_cafe.maxValue = maxgagevalue;
        slider_cafe.value = gagevalue;

        slider_chicken.maxValue = maxgagevalue;
        slider_chicken.value = gagevalue;


        slider_gobchang.maxValue = maxgagevalue;
        slider_gobchang.value = gagevalue;


        slider_health.maxValue = maxgagevalue;
        slider_health.value = gagevalue;

        slider_land.maxValue = maxgagevalue;
        slider_land.value = gagevalue;
    }


    //카페 함수
    void CheckCafeGage() //카페 터치에 따른 게이지 상태 체크
    {
        
        if (gage_cafe > 0 && isfever_cafe == false)
        {
            if (isClicked_cafe == true)
            {
                timer_cafe += Time.deltaTime;
            }

            if (timer_cafe >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_cafe = false;
                gage_cafe -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (gage_cafe == 100)
            {
                isfever_cafe = true;
            }
        }
    }






    //치킨 함수

    void CheckChickenGage()  //카페 터치에 따른 게이지 상태 체크
    {

        
        if (slider_chicken.value > 0 && isfever_chicken == false)
        {
            if (isClicked_chicken == true)
            {
                timer_chicken += Time.deltaTime;

            }

            if (timer_chicken >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_chicken = false;
                gage_chicken -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (gage_chicken == 100)
            {
                isfever_chicken = true;

            }
        }
    }


    //곱창집 함수

    void CheckGobchangGage()  //카페 터치에 따른 게이지 상태 체크
    {

        
        if (slider_gobchang.value > 0 && isfever_gobchang == false)
        {
            if (isClicked_Gobchang == true)
            {
                timer_Gobchang += Time.deltaTime;
            }

            if (timer_Gobchang >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Gobchang = false;
                gage_gobchang -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (gage_gobchang == 100)
            {
                isfever_gobchang = true;
            }
        }
    }


    //헬스장 함수
    void CheckHealthGage()  //카페 터치에 따른 게이지 상태 체크
    {

        
        if (slider_health.value > 0 && isfever_health == false)
        {
            if (isClicked_Health == true)
            {
                timer_Health += Time.deltaTime;
            }

            if (timer_Health >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Health = false;
                gage_health -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (gage_health == 100)
            {
                isfever_health = true;
            }
        }
    }



    //냥냐랜드 함수
    void CheckLandGage()  //카페 터치에 따른 게이지 상태 체크
    {

        
        if (slider_land.value > 0 && isfever_land == false)
        {
            if (isClicked_Land == true)
            {
                timer_Land += Time.deltaTime;
            }

            if (timer_Land >= 2.0f)  // 2초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked_Land = false;
                gage_land -= Time.deltaTime * 10;   // 초당 10씩 게이지 제거
            }
            if (gage_land == 100)
            {
                isfever_land = true;
            }
        }
    }
}
