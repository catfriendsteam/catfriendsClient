using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class StatusManager : MonoBehaviour
{
    public GageMng gagemng;
    public StoreManage Storemng;

    public static long Money = 10;
    public static int Diamond = 20;
    public static int GoodPoint = 30;
    //터치 당 게이지 차는 비율
    public float touch_value = 1;
    //춘배레벨
    public int Level_Chunbae = 1;




    //레벨 업 비용
    public static int LevelUpCost_Chunbae;
    //터치 당 비용
    public int Touch_Profit;
    //1~99 1  100~ 199 2
    public static float Touch_Step;






    // 수익 들어오는 시간
    float t;
    public int AllStoreIncome;




    public void SavePlayer()
    {
        SaveData save = new SaveData();


        save.Money = Money;
        save.Diamond = Diamond;
        save.GoodPoint = GoodPoint;

        save.Level_Chunbae = Level_Chunbae;
        save.AllStoreIncome = AllStoreIncome;
        save.touch_value = touch_value;


        SaveManager.Save(save);
    }

    public void LoadPlayer()
    {
        SaveData save = SaveManager.Load();
        Money = save.Money;
        Diamond = save.Diamond;
        GoodPoint = save.GoodPoint;

        Level_Chunbae = save.Level_Chunbae;
        AllStoreIncome = save.AllStoreIncome;
        touch_value = save.touch_value;
    
    }






    void Awake()
    {
        /*
        Money = 100;
        Diamond = 1;
        GoodPoint = 2;
    */





        // 저장 경로에 파일이 없다면 처음 시작으로 인지하여 저장하고 시작하고 아니면 그냥 로드
        string path = Path.Combine(Application.dataPath, "PlayerData.bin");

        if (!File.Exists(path))
        {
            SavePlayer();
            LoadPlayer();
        }
        else
        {
            LoadPlayer();
        }






        //Update에서도 계속 호출 되어야 할 변수들. 터치당 이득, 현재 레벨에 따른 레벨단계, 춘배 레벨업 비용 
        Touch_Profit = 10 * Level_Chunbae;

        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;
        LevelUpCost_Chunbae = Touch_Profit* (Level_Chunbae + 1)* (int)Touch_Step;
    }

    // Update is called once per frame
    void Update()
    {

        

        ShowUpperMenu();
        // TocheckChunbaeProfitAndUpgradeCost(); // 나중에 레벨업 버튼 추가시 Touch_Step 변수와 LevelUpCost_Chunbae는 항상 업데이트에 안걸어 놓고도 옮길 수 있을 것이다. 수정 필요





        // 여기 아래부터는 무조건 1초에 한번씩 호출
        t += Time.deltaTime;
      if (t < 1)
            return;
      t = 0f;
        Debug.Log("1초마다 체크됩니다.");

        
        Money = Money + 10; 
        //(long)(Time.deltaTime * 10) ;



    }



   public void TocheckChunbaeProfitAndUpgradeCost()
    {
        Touch_Profit = 10 * Level_Chunbae;
        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;
        LevelUpCost_Chunbae = Touch_Profit * (Level_Chunbae + 1) * (int)Touch_Step;
    }

    //Upper매뉴에 있는 돈, 다이아, 선행포인트를 보여줍니다.
   void ShowUpperMenu()
    {


        //택스트 태그를 찾아 텍스트 들의 순서를 배열에 넣습니다.
        Text[] UpperMenu = GameObject.FindGameObjectWithTag("UI_UpperMenu").GetComponentsInChildren<Text>();



        //돈 보여주는 조건문
        if (Money >= 1000000000000)
        {
            long Money_1000000000000 = Money / 1000000000000;
            long Money_100000000 = (Money % 1000000000000) / 100000000;
            long Money_10000 = (Money % 100000000) / 10000;
            long Money_0 = (Money % 10000);
            UpperMenu[0].text = Money_1000000000000+"조" + Money_100000000 + "억" + Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (Money >= 100000000)
        {
            long Money_100000000 = Money / 100000000;
            long Money_10000 = (Money % 100000000) / 10000;
            long Money_0 = (Money % 10000);
            UpperMenu[0].text = Money_100000000 + "억"+ Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (Money >= 10000)
        {
            long Money_10000 = Money / 10000;
            long Money_0 = Money % 10000;
            UpperMenu[0].text = Money_10000 + "만" + Money_0.ToString() + "원";
        }
        else if (Money < 10000)
        {
            UpperMenu[0].text = Money.ToString() + "원";
        }
      




        UpperMenu[1].text = Diamond.ToString();
        UpperMenu[2].text = GoodPoint.ToString();

    }




    //터치하면 오르는 돈, 피버 상태에 따라 피버 배율 적용
    public void Touch_IncreaseMoney()
    {
        if (gagemng.isfever == false)
        {
            Money += Touch_Profit;

        }
        else if(gagemng.isfever == true)
        {
                   Money += (int)((float)Touch_Profit * gagemng.fevercount);
       
        }



    }

}
