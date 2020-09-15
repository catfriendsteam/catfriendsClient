using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class StatusManager : MonoBehaviour
{
    public GageMng gagemng;
    public StoreManage Storemng;

    //public long Money = 10;
    //public static int Diamond = 20;
    //public static int GoodPoint = 30;

    //터치 당 게이지 차는 비율
    public float touch_value = 1;
    //춘배레벨
    public int Level_Chunbae = 1;




    //레벨 업 비용
    public int LevelUpCost_Chunbae;
    //터치 당 비용
    public int Touch_Profit;
    //1~99 1  100~ 199 2
    public static float Touch_Step;

    public int LevelUp_Effect;






    // 수익 들어오는 시간
    float t;
    public int AllStoreProfit;

    //받아오는 targetPos (스크롤 위치값)

    public float TargetPos;


    //카페가 사용가능한 상태인가? 해금되었는가?
    public bool Cafe_Active;
    public bool Chicken_Active;
    public bool Gobchang_Active;
    public bool Health_Active;
    public bool Land_Active;



    public void SavePlayer()
    {
        SaveData save = new SaveData();


        save.Money = SingletonMng.instance.Money;
        save.Diamond = SingletonMng.instance.Diamond;
        save.GoodPoint = SingletonMng.instance.GoodPoint;

        save.Level_Chunbae = Level_Chunbae;
        save.AllStoreProfit = AllStoreProfit;
        save.touch_value = touch_value;



        save.Cafe_Active = Cafe_Active;
        save.Chicken_Active = Chicken_Active;
        save.Gobchang_Active = Gobchang_Active;
        save.Health_Active = Health_Active;
        save.Land_Active = Land_Active;
        save.TargetPos = TargetPos;


        SaveManager.Save(save);
    }

    public void FirstSavePlayer()
    {
        SaveData save = new SaveData();


        save.Money = 10;
        save.Diamond = 10;
        save.GoodPoint = 10;

        save.Level_Chunbae = 1;
        save.AllStoreProfit = 0;
        save.touch_value = 1;

        Cafe_Active = false;
        Chicken_Active = false;
        Gobchang_Active = false;
        Health_Active = false;
        Land_Active = false;

        TargetPos = 0;

        
        
               // 가구도 초기화
        string filepath2;
        filepath2 = Application.persistentDataPath + "/MyStoreText.txt";
        File.Delete(filepath2);


        SaveManager.Save(save);

    }

    public void LoadPlayer()
    {
        SaveData save = SaveManager.Load();
        SingletonMng.instance.Money = save.Money;
        SingletonMng.instance.Diamond = save.Diamond;
        SingletonMng.instance.GoodPoint = save.GoodPoint;

        Level_Chunbae = save.Level_Chunbae;
       AllStoreProfit = save.AllStoreProfit;
       touch_value = save.touch_value;


        Cafe_Active = save.Cafe_Active;
        Chicken_Active = save.Chicken_Active;
        Gobchang_Active = save.Gobchang_Active;
        Health_Active = save.Health_Active;
        Land_Active = save.Land_Active;

        TargetPos = save.TargetPos;
    }






    void Awake()
    {
        Level_Chunbae = 1;
        touch_value = 1;



        Cafe_Active = false;
        Chicken_Active = false;
        Gobchang_Active = false;
        Health_Active = false;
        Land_Active = false;

        AllStoreProfit = 10000;



        Touch_Profit = 0;
        Touch_Step = 0;
        LevelUpCost_Chunbae = 0;
        LevelUp_Effect = 0;



        /*
        //Update에서도 계속 호출 되어야 할 변수들. 터치당 이득, 현재 레벨에 따른 레벨단계, 춘배 레벨업 비용 
        Touch_Profit = 10 * Level_Chunbae;

        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;

        LevelUpCost_Chunbae = Touch_Profit * (Level_Chunbae + 1) * (int)Touch_Step;

        //레벌당 오르는 이득
        LevelUp_Effect = (int)Touch_Step * 10;

    */



        // 저장 경로에 파일이 없다면 처음 시작으로 인지하여 저장하고 시작하고 아니면 그냥 로드
        string path = Path.Combine(Application.dataPath, "PlayerData.bin");

      if (!File.Exists(path))
      {
          FirstSavePlayer();
          LoadPlayer();
      }
      else 
      {
          LoadPlayer();
      }
  




    }




    // Update is called once per frame
    void Update()
    {



        ShowUpperMenu();
        TocheckChunbaeProfitAndUpgradeCost(); // 나중에 레벨업 버튼 추가시 Touch_Step 변수와 LevelUpCost_Chunbae는 항상 업데이트에 안걸어 놓고도 옮길 수 있을 것이다. 수정 필요



        // 여기 아래부터는 무조건 1초에 한번씩 호출
        //초당 수입 , 피버일 때, 피버 아닐 때

        AutoProfit();


        Reset_Input_R();
    }

    //R누르면 초기화
    public void Reset_Input_R()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            string filepath2;
            filepath2 = Application.persistentDataPath + "/MyStoreText.txt";
            File.Delete(filepath2);
            print("R누름");


            FirstSavePlayer();
        }
    }


    // 여기 아래부터는 무조건 1초에 한번씩 호출
    //초당 수입 , 피버일 때, 피버 아닐 때
    public void AutoProfit()
    {
        try
        {

            if (gagemng.isfever == false)
            {
                t += Time.deltaTime;
                if (t < 1)
                    return;
                t = 0f;

                SingletonMng.instance.Money = SingletonMng.instance.Money + AllStoreProfit;

            }
            else if (gagemng.isfever == true)
            {
                t += Time.deltaTime;
                if (t < 1)
                    return;
                t = 0f;

                SingletonMng.instance.Money = SingletonMng.instance.Money + (long)(SingletonMng.instance.fevercount * (float)(AllStoreProfit));

            }
        }
        catch (NullReferenceException)
        {
            t += Time.deltaTime;
            if (t < 1)
                return;
            t = 0f;
            //Debug.Log(ex);

            SingletonMng.instance.Money = SingletonMng.instance.Money + AllStoreProfit;

        }


    }




    public void TocheckChunbaeProfitAndUpgradeCost()
    {


        //터치단계
        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;
        //레벨업 비용
        LevelUpCost_Chunbae = Touch_Profit * (Level_Chunbae + 1) * (int)Touch_Step;
        //레벌당 오르는 이득
        LevelUp_Effect = (int)Touch_Step * 10;

        if (Level_Chunbae >= 1000)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 1000) + 1000 + 2000 + 3000 + 4000 + 5000 + 6000 + 7000 +8000 +9000 +10000;

        }
        else if (Level_Chunbae >= 900)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 900) + 1000 + 2000 + 3000 + 4000 + 5000 + 6000 + 7000 + 8000 +9000;

        }
        else if (Level_Chunbae >= 800)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 800) + 1000 + 2000 + 3000 + 4000 + 5000 + 6000 + 7000 + 8000;

        }
        else if (Level_Chunbae >= 700)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 700) + 1000 + 2000 + 3000 + 4000 + 5000 + 6000 + 7000;

        }
        else if (Level_Chunbae >= 600)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 600) + 1000 + 2000 + 3000 + 4000 + 5000 + 6000;

        }
        else if (Level_Chunbae >= 500)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 500) + 1000 + 2000 + 3000 + 4000 + 5000;

        }
        else if (Level_Chunbae >= 400)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 400) + 1000 + 2000 + 3000 + 4000;

        }
        else if (Level_Chunbae >= 300)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 300) + 1000 + 2000 + 3000;

        }

        else if (Level_Chunbae >= 200)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 200) + 1000 + 2000;

        }
        else if (Level_Chunbae >= 100)
        {
            Touch_Profit = LevelUp_Effect * (Level_Chunbae % 100) + 1000;

        }
        else if (Level_Chunbae < 100)
        {
            Touch_Profit = LevelUp_Effect * Level_Chunbae;
        }
       
       
    }

    //Upper매뉴에 있는 돈, 다이아, 선행포인트를 보여줍니다.
    void ShowUpperMenu()
    {


        //택스트 태그를 찾아 텍스트 들의 순서를 배열에 넣습니다.
        Text[] UpperMenu = GameObject.FindGameObjectWithTag("UI_UpperMenu").GetComponentsInChildren<Text>();



        //돈 보여주는 조건문
        if (SingletonMng.instance.Money >= 1000000000000)
        {
            long Money_1000000000000 = SingletonMng.instance.Money / 1000000000000;
            long Money_100000000 = (SingletonMng.instance.Money % 1000000000000) / 100000000;
            long Money_10000 = (SingletonMng.instance.Money % 100000000) / 10000;
            long Money_0 = (SingletonMng.instance.Money % 10000);
            UpperMenu[0].text = Money_1000000000000 + "조" + Money_100000000 + "억" + Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (SingletonMng.instance.Money >= 100000000)
        {
            long Money_100000000 = SingletonMng.instance.Money / 100000000;
            long Money_10000 = (SingletonMng.instance.Money % 100000000) / 10000;
            long Money_0 = (SingletonMng.instance.Money % 10000);
            UpperMenu[0].text = Money_100000000 + "억" + Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (SingletonMng.instance.Money >= 10000)
        {
            long Money_10000 = SingletonMng.instance.Money / 10000;
            long Money_0 = SingletonMng.instance.Money % 10000;
            UpperMenu[0].text = Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (SingletonMng.instance.Money < 10000)
        {
            UpperMenu[0].text = SingletonMng.instance.Money.ToString() + "원";
        }





        UpperMenu[1].text = SingletonMng.instance.Diamond.ToString();
        UpperMenu[2].text = SingletonMng.instance.GoodPoint.ToString();

    }




    //터치하면 오르는 돈, 피버 상태에 따라 피버 배율 적용
    public void Touch_IncreaseMoney()
    {
        if (SingletonMng.instance.isfever == false)
        {
            SingletonMng.instance.Money += Touch_Profit;


        }
        else if (SingletonMng.instance.isfever == true)
        {
            SingletonMng.instance.Money += (int)((float)Touch_Profit * SingletonMng.instance.fevercount);

        }



    }

    //게임 강제종료시 데이터 저장
    /*private void OnApplicationQuit()
    {
        SavePlayer();
    }*/
}
