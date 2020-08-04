using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    public GageMng gagemng;

    public static int Money;
    public static int Diamond;
    public static int GoodPoint;
    //터치 당 게이지 차는 비율
    public float touch_value;



    //춘배레벨
    public int Level_Chunbae;
    //레벨 업 비용
    public static int LevelUpCost_Chunbae;
    //터치 당 비용
    public int Touch_Profit;
    //1~99 1  100~ 199 2
    public static float Touch_Step;



    // Start is called before the first frame update
    void Awake()
    {
        Money = 1000;
        Diamond = 1;
        GoodPoint = 2;
        Level_Chunbae = 1;
        touch_value = 1;

        //Update에서도 계속 호출 되어야 할 변수들. 터치당 이득, 현재 레벨에 따른 레벨단계, 춘배 레벨업 비용 
        Touch_Profit = 10 * Level_Chunbae;

        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;
        LevelUpCost_Chunbae = Touch_Profit* (Level_Chunbae + 1)* (int)Touch_Step;
    }

    // Update is called once per frame
    void Update()
    {


        ShowUpperMenu();
        TocheckChunbaeProfitAndUpgradeCost(); // 나중에 레벨업 버튼 추가시 Touch_Step 변수와 LevelUpCost_Chunbae는 항상 업데이트에 안걸어 놓고도 옮길 수 있을 것이다. 수정 필요


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
        Text[] UpperMenu = GameObject.FindGameObjectWithTag("UI_UpperMenu").GetComponentsInChildren<Text>();
        UpperMenu[0].text = Money.ToString();
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
