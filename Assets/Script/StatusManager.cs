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

        Touch_Profit = 10 * Level_Chunbae;
        Touch_Step = Mathf.Floor(Level_Chunbae / 100) + 1;
        LevelUpCost_Chunbae = Touch_Profit* (Level_Chunbae + 1)* (int)Touch_Step;
    }

    // Update is called once per frame
    void Update()
    {
        

        Text[] UpperMenu = GameObject.FindGameObjectWithTag("UI_UpperMenu").GetComponentsInChildren<Text>();
        UpperMenu[0].text = Money.ToString();
        UpperMenu[1].text = Diamond.ToString();
        UpperMenu[2].text = GoodPoint.ToString();


    }

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
