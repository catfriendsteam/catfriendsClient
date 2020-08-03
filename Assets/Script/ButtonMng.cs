using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour
{

    public GageMng gageMng;
    public StatusManager statusMng;


    public NestedScrollManager nestedScrollMng;





    //카페 슬라이더
    public Slider slider;
    //치킨 슬라이더
    public Slider slider_chicken;


    public void IncreaseGage()
    {
        if (nestedScrollMng.targetIndex >= 0 && nestedScrollMng.targetIndex < 1)
        {
            slider.value += 1;   //게이지 1%씩 증가
            gageMng.isClicked = true;
            gageMng.timer = 0.0f;
            statusMng.Touch_IncreaseMoney();
        }


        else if (nestedScrollMng.targetIndex >= 1 && nestedScrollMng.targetIndex < 2)
        {
            slider_chicken.value += 1;   //게이지 1%씩 증가
            gageMng.isClicked_chicken = true;
            gageMng.timer_chicken = 0.0f;
            statusMng.Touch_IncreaseMoney();
        }
    }


}
