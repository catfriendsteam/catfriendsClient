﻿using System;
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
    public int Level = 1;
    public int Profit = 1;
    
    public bool isRocked;

    //차례대로 가구가 화면 4개의 슬롯중에 표시되는 순서, 가게배수, 리모델링 배수
    public int Furnitureindex, Storemagnification;
    public int RemodelingMagnifiaction;


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
    public Image[] FurnitureImage;

    public Sprite[] UsingSprite;
    



    public NestedScrollManager scrollMng;


    /*
    private void Update()
    {
        TabClick();
    }
    */

    void Start()
    {
        Setting();
        


    }


    
    public void Setting()
    {
        string[] line = StoreDatabase.text.Substring(0, StoreDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllStoreList.Add(new Store(row[0], row[1], row[2], int.Parse(row[3]), int.Parse(row[4]), row[5] == "TRUE"));



            //리모델링 배수 설정 -> 지금 AllStore에다가 하는 중인데, MystoreList로 옮길까 생각중
            if (AllStoreList[i].Type == "카페")
                AllStoreList[i].RemodelingMagnifiaction = 1;
            else if (AllStoreList[i].Type == "치킨집")
                AllStoreList[i].RemodelingMagnifiaction = 2;
            else if (AllStoreList[i].Type == "곱창집")
                AllStoreList[i].RemodelingMagnifiaction = 4;
            else if (AllStoreList[i].Type == "헬스장")
                AllStoreList[i].RemodelingMagnifiaction = 8;
            else if (AllStoreList[i].Type == "냥냐랜드")
                AllStoreList[i].RemodelingMagnifiaction = 16;

            //가게 배수 설정
            if (AllStoreList[i].Type == "카페")
                AllStoreList[i].Storemagnification = 1;
            else if (AllStoreList[i].Type == "치킨집")
                AllStoreList[i].Storemagnification = 4;
            else if (AllStoreList[i].Type == "곱창집")
                AllStoreList[i].Storemagnification = 16;
            else if (AllStoreList[i].Type == "헬스장")
                AllStoreList[i].Storemagnification = 64;
            else if (AllStoreList[i].Type == "냥냐랜드")
                AllStoreList[i].Storemagnification = 256;

       
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

        //타겟포인트에 따른 가구 불러오는 것 다르게
        if (scrollMng.targetPos >= 0f && scrollMng.targetPos < 0.25f)
        {
            curType = "카페";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "카페");
        }
        else if (scrollMng.targetPos >= 0.25f && scrollMng.targetPos < 0.5f)
        {
            curType = "치킨집";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "치킨집");
        }
        else if (scrollMng.targetPos >= 0.5f && scrollMng.targetPos < 0.75f)
        {
            curType = "곱창집";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "곱창집");
        }
        else if (scrollMng.targetPos >= 0.75f && scrollMng.targetPos < 1f)
        {
            curType = "헬스장";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "헬스장");
        }
        else if (scrollMng.targetPos >= 1.0f)
        {
            curType = "냥나랜드";
            CurStoreList = MyStoreList.FindAll(x => x.Type == "냥냐랜드");
        }

        // 
        for (int i = 0; i<Slot.Length; i++)
        {
            //꺼져있던 슬롯 활성화
            Slot[i].SetActive(i < CurStoreList.Count);


            //몇번째에 있는 지 받아오기 위해 for문의 i를 받는다.
            CurStoreList[i].Furnitureindex = i;



            // 리모델링 배수 설정 -> 지금 AllStore에다가 하는 중인데, MystoreList로 옮길까 생각중 하다가 -> CurStoreList에 넣어봄.

            if (CurStoreList[i].Type == "카페")
                CurStoreList[i].RemodelingMagnifiaction = 1;
            else if (CurStoreList[i].Type == "치킨집")
                CurStoreList[i].RemodelingMagnifiaction = 2;
            else if (CurStoreList[i].Type == "곱창집")
                CurStoreList[i].RemodelingMagnifiaction = 4;
            else if (CurStoreList[i].Type == "헬스장")
                CurStoreList[i].RemodelingMagnifiaction = 8;
            else if (CurStoreList[i].Type == "냥냐랜드")
                CurStoreList[i].RemodelingMagnifiaction = 16;

            //가게 배수 설정
            if (CurStoreList[i].Type == "카페")
                CurStoreList[i].Storemagnification = 1;
            else if (CurStoreList[i].Type == "치킨집")
                CurStoreList[i].Storemagnification = 4;
            else if (CurStoreList[i].Type == "곱창집")
                CurStoreList[i].Storemagnification = 16;
            else if (CurStoreList[i].Type == "헬스장")
                CurStoreList[i].Storemagnification = 64;
            else if (CurStoreList[i].Type == "냥냐랜드")
                CurStoreList[i].Storemagnification = 256;







            /*//이름을 받아옵니다.
            Slot[i].GetComponentInChildren<Text>().text = i < CurStoreList.Count ? CurStoreList[i].Name : "";
      
            // Slot[i].GetComponentInChildren<Text>().text = i < CurStoreList.Count ? CurStoreList[i].Level.ToString : "";*/

            //내가 보유한 캐릭터의 이름 가져오기
            Text FurnitureName = Slot[i].transform.GetChild(1).gameObject.GetComponent<Text>();
            FurnitureName.text = CurStoreList[i].Name;

            //내가 보유한 캐릭터의 레벨 가져오기
            Text FurnitureLevel = Slot[i].transform.GetChild(3).gameObject.GetComponent<Text>();
            FurnitureLevel.text = CurStoreList[i].Level.ToString();

            //내가 보유한 캐릭터의 버는 돈 가져오기
            Text FurnitureProfit = Slot[i].transform.GetChild(4).gameObject.GetComponent<Text>();
            FurnitureProfit.text =  (CurStoreList[i].Profit.ToString() +" " +  '/' + " s");

            //비용
            Text MyCharCost = Slot[i].transform.GetChild(6).GetChild(0).gameObject.GetComponent<Text>();
            MyCharCost.text = ((CurStoreList[i].Profit * CurStoreList[i].Level * CurStoreList[i].Storemagnification * CurStoreList[i].RemodelingMagnifiaction).ToString()+ "원");

            //레벨업 효과
            Text MyCharEffect = Slot[i].transform.GetChild(6).GetChild(1).gameObject.GetComponent<Text>();
            MyCharEffect.text =('+' + (3).ToString() + "원");



            //아이템 이미지
            FurnitureImage[i].sprite = UsingSprite[AllStoreList.FindIndex(x => x.RealName == CurStoreList[i].RealName)];
         
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



    public void RemodelingClick(int Buttonindex)
    {

        Store CurFurniture = CurStoreList.Find(x => x.Furnitureindex == Buttonindex);
        CurFurniture.RemodelingMagnifiaction = CurFurniture.RemodelingMagnifiaction + 1;
        TabClick();

        print(CurFurniture.RemodelingMagnifiaction);
    }


    public void LevelUpButton(int Buttonindex)
    {

        Store CurFurniture = CurStoreList.Find(x => x.Furnitureindex == Buttonindex);
        CurFurniture.Level = CurFurniture.Level + 1;
        TabClick();
    }



}

