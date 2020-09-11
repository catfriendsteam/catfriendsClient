using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public long Money = 10;
    public int Diamond;
    public int GoodPoint;

    public int Level_Chunbae;

    public int AllStoreProfit;

    public float touch_value;



    //카페가 사용가능한 상태인가? 해금되었는가?
    public bool Cafe_Active;
    public bool Chicken_Active;
    public bool Gobchang_Active;
    public bool Health_Active;
    public bool Land_Active;


    public float TargetPos;
}
