using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour
{
    public Slider slider;
    public GageMng gageMng;
    public StatusManager statusMng;

    public void IncreaseGage()
    {
        slider.value += 1;   //게이지 1%씩 증가
        gageMng.isClicked = true;
        gageMng.timer = 0.0f;

        statusMng.Touch_IncreaseMoney();
    }


}
