using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;




[System.Serializable] //직렬화
//캐릭터의 특성을 저장하는 클래스
public class Store
{
    //생성자 : 각각 타입(냥멍인/냥이),이름,레벨,레벨업비용,해금여부,레벨업 효과,설명글
    public Store(string _Type, string _Name, string _RealName, int _Level, int _Profit, bool _isRocked)
    {
        Type = _Type; Name = _Name; RealName = _RealName; Level = _Level; Profit = _Profit; isRocked = _isRocked;
    }
    public string Type, Name, RealName;
    public int Level, Profit;
    
    public bool isRocked;

    [TextArea]
    public string ExplainText;

    //추가해야 할 변수 : 능력치들
}

public class StoreManage : MonoBehaviour
{

    public TextAsset StoreDatabase;
    public List<Store> AllStoreList, MyStoreList, CurStoreList;
    public string curType = "카페";
    public GameObject[] Slot;
    public Text StoreNameText;

    public NestedScrollManager scrollMng;


    /*
    private void Update()
    {
        TabClick();
    }
    */

    void Start()
    {
        string[] line = StoreDatabase.text.Substring(0, StoreDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllStoreList.Add(new Store(row[0], row[1], row[2], int.Parse(row[3]), int.Parse(row[4]), row[5] == "TRUE"));
        }

        Load();

    }

    /*
        public void TabClick(String tabName)
        {

        }
        */
    public void TabClick()
    {
        if (scrollMng.targetPos == 0)
        {
            curType = "카페";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "카페");
        }
        
        // 
        for(int i = 0; i<Slot.Length; i++)
        {
            //꺼져있던 슬롯 활성화
            Slot[i].SetActive(i < CurStoreList.Count);
            //이름을 받아옵니다.
            Slot[i].GetComponentInChildren<Text>().text = i < CurStoreList.Count ? CurStoreList[i].Name : "";

           // Slot[i].GetComponentInChildren<Text>().text = i < CurStoreList.Count ? CurStoreList[i].Level.ToString : "";
        }

            //가게이름 받아오기
        StoreNameText.text = curType;



        /*
        String tabName = curType;

        int tabNum = 0;
        switch(tabName)
        {
            case "카페": tabNum = 0; break;
            case "치킨집": tabNum = 1; break;
            case "곱창집": tabNum = 2; break;
            case "헬스장": tabNum = 3; break;
            case "냥냐랜드": tabNum = 4; break;
        }*/
    }

    void Save()
    {
        string jdata = JsonConvert.SerializeObject(MyStoreList);
        File.WriteAllText(Application.dataPath + "/Resources/MyStoreText.txt", jdata);

        TabClick();
    }


    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyStoreText.txt");
        MyStoreList = JsonConvert.DeserializeObject<List<Store>>(jdata);

        TabClick();

    }
}


