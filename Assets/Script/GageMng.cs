using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageMng : MonoBehaviour
{
    public Slider slider;
    public bool isClicked;
    public float timer;
    public Text gageText;

    void Awake()
    {
        SetMaxGage(100);
        SetGage(0);
        isClicked = false;
        timer = 0.0f;
    }

    void Update()
    {
        gageText.text = Mathf.CeilToInt(slider.value).ToString();   // 게이지 숫자 텍스트 표시(실수를 정수로 문자화)
        if (slider.value > 0)
        {
            if (isClicked == true)
            {
                timer += Time.deltaTime;
            }

            if (timer >= 1.0f)  // 1초동안 게이지버튼 클릭 안하면 게이지 제거
            {
                isClicked = false;
                slider.value -= Time.deltaTime * 20;   // 초당 20씩 게이지 제거
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
}
