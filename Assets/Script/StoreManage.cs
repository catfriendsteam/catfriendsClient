using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;


//save용 클래스
/*
[System.Serializable]
public class SerializationData<T>
{
    public SerializationData(List<T> _target) => target = _target;
    public List<T> target;
}
*/

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
    public int Level;
    public int Profit;

    public bool isRocked;


    //차례대로 가구가 화면 4개의 슬롯중에 표시되는 순서, 가게배수, 리모델링 배수, 업그레이드 비용
    public int Furnitureindex, Storemagnification;
    public int RemodelingMagnifiaction;
    public int UpgradeCost;
    public int UpgradeEffect_Profit;

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

    string filepath2; //경로 저장변수


    public int AllStoreProfit;



    public NestedScrollManager scrollMng;
    public StatusManager StatusMng;



    //돈이 업그레이드비용보다 있으면 엑티브 한 상태로 보여주기 위해

    public Image[] FurnitureLevelUpButton;
    public Sprite FurnitureLevelUpButton_Active;
    public Sprite FurnitureLevelUpButton_UnActive;


    void Start()
    {

        AllStoreListSetting();


       //Setting();

        //모바일이든 컴퓨터든 파일이 저장된 경로에서 mycharacter 경로 저장
        filepath2 = Application.persistentDataPath + "/MyStoreText.txt";
        Debug.Log(filepath2);
        Load();

    }




    public void TabClick()
    {


        //타겟포인트에 따른 가구 불러오는 것 다르게해서 화면이 움직일때마다 UI에서 보이는 가구들을 다르게 보여줍니다.
        ShowListUI();

        Setting();


        // 
        for (int i = 0; i < Slot.Length; i++)
        {
            //꺼져있던 슬롯 활성화
            Slot[i].SetActive(i < CurStoreList.Count);


            //몇번째에 있는 지 받아오기 위해 for문의 i를 받는다.
            CurStoreList[i].Furnitureindex = i;







            //내가 보유한 캐릭터의 이름 가져오기
            Text FurnitureName = Slot[i].transform.GetChild(1).gameObject.GetComponent<Text>();
            FurnitureName.text = CurStoreList[i].Name;

            //내가 보유한 캐릭터의 레벨 가져오기
            Text FurnitureLevel = Slot[i].transform.GetChild(3).gameObject.GetComponent<Text>();
            FurnitureLevel.text = CurStoreList[i].Level.ToString();

            //내가 보유한 캐릭터의 버는 돈 가져오기
            Text FurnitureProfit = Slot[i].transform.GetChild(4).gameObject.GetComponent<Text>();
            FurnitureProfit.text = (CurStoreList[i].Profit.ToString() + " " + '/' + " s");

            //비용
            Text MyCharCost = Slot[i].transform.GetChild(6).GetChild(0).gameObject.GetComponent<Text>();
            MyCharCost.text = (CurStoreList[i].UpgradeCost).ToString() + "원";

            //레벨업 효과
            Text MyCharEffect = Slot[i].transform.GetChild(6).GetChild(1).gameObject.GetComponent<Text>();
            MyCharEffect.text = ('+' + (3).ToString() + "원");



            //아이템 이미지
            FurnitureImage[i].sprite = UsingSprite[AllStoreList.FindIndex(x => x.RealName == CurStoreList[i].RealName)];

        }
        // statusManager에서 가게들의 해금이 열려있는지 체크하고, AllStoreProfit 변수에다가 활성화되어있는 가구의 돈을 합쳐줍니다.
        CheckAllprofit();
    }













    public void AllStoreListSetting()
    {
        string[] line = StoreDatabase.text.Substring(0, StoreDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllStoreList.Add(new Store(row[0], row[1], row[2], int.Parse(row[3]), int.Parse(row[4]), bool.Parse(row[5])));



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


            //초기 업그레이드 비용, 프로핏, 업그레이드 프로핏 증가, 공식 설정
            AllStoreList[i].UpgradeCost = AllStoreList[i].Profit * AllStoreList[i].Level * AllStoreList[i].Storemagnification * AllStoreList[i].RemodelingMagnifiaction;
            AllStoreList[i].Profit = AllStoreList[i].Level * AllStoreList[i].RemodelingMagnifiaction * AllStoreList[i].Storemagnification * 10;
            AllStoreList[i].UpgradeEffect_Profit = AllStoreList[i].Level * AllStoreList[i].RemodelingMagnifiaction * AllStoreList[i].Storemagnification;


        }
    }


    public void Setting()
    {
        string[] line = StoreDatabase.text.Substring(0, StoreDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
           //  string[] row = line[i].Split('\t');
           // MyStoreList.Add(new Store(row[0], row[1], row[2], int.Parse(row[3]), int.Parse(row[4]), bool.Parse(row[5])));



            //리모델링 배수 설정 -> 지금 AllStore에다가 하는 중인데, MystoreList로 옮길까 생각중
            if (MyStoreList[i].Type == "카페")
                MyStoreList[i].RemodelingMagnifiaction = 1;
            else if (MyStoreList[i].Type == "치킨집")
                MyStoreList[i].RemodelingMagnifiaction = 2;
            else if (MyStoreList[i].Type == "곱창집")
                MyStoreList[i].RemodelingMagnifiaction = 4;
            else if (MyStoreList[i].Type == "헬스장")
                MyStoreList[i].RemodelingMagnifiaction = 8;
            else if (MyStoreList[i].Type == "냥냐랜드")
                MyStoreList[i].RemodelingMagnifiaction = 16;

            //가게 배수 설정
            if (MyStoreList[i].Type == "카페")
                MyStoreList[i].Storemagnification = 1;
            else if (MyStoreList[i].Type == "치킨집")
                MyStoreList[i].Storemagnification = 4;
            else if (MyStoreList[i].Type == "곱창집")
                MyStoreList[i].Storemagnification = 16;
            else if (MyStoreList[i].Type == "헬스장")
                MyStoreList[i].Storemagnification = 64;
            else if (MyStoreList[i].Type == "냥냐랜드")
                MyStoreList[i].Storemagnification = 256;


            //초기 업그레이드 비용, 프로핏, 업그레이드 프로핏 증가, 공식 설정
            MyStoreList[i].UpgradeCost = MyStoreList[i].Profit * MyStoreList[i].Level * MyStoreList[i].Storemagnification * MyStoreList[i].RemodelingMagnifiaction;
            MyStoreList[i].Profit = MyStoreList[i].Level * MyStoreList[i].RemodelingMagnifiaction * MyStoreList[i].Storemagnification * 10;
            MyStoreList[i].UpgradeEffect_Profit = MyStoreList[i].Level * MyStoreList[i].RemodelingMagnifiaction * MyStoreList[i].Storemagnification;


        }
    }


    // statusManager에서 가게 해금 상태를 받아와서 잠긴 상태를 풉니다.
    public void CheckAllprofit()
    {
        string[] line = StoreDatabase.text.Substring(0, StoreDatabase.text.Length - 1).Split('\n');

        AllStoreProfit = 0;


        for (int i = 0; i < line.Length; i++)
        {

            if (MyStoreList[i].Type == "카페" && StatusMng.Cafe_Active == true)
            {
                MyStoreList[i].isRocked = true;
            }
            else if (MyStoreList[i].Type == "치킨집" && StatusMng.Chicken_Active == true)
            {
                MyStoreList[i].isRocked = true;
            }
            else if (MyStoreList[i].Type == "곱창집" && StatusMng.Gobchang_Active == true)
            {
                MyStoreList[i].isRocked = true;
            }
            else if (MyStoreList[i].Type == "헬스장" && StatusMng.Health_Active == true)
            {
                MyStoreList[i].isRocked = true;
            }
            else if (MyStoreList[i].Type == "냥냐랜드" && StatusMng.Land_Active == true)
            {
                MyStoreList[i].isRocked = true;
            }

            if (MyStoreList[i].isRocked == true)
            {

                AllStoreProfit = AllStoreProfit + MyStoreList[i].Profit;
            }


        }

        StatusMng.AllStoreProfit = AllStoreProfit;

    }

    public void ShowListUI()
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


        //가게이름 받아오기
        StoreNameText.text = curType;

    }









    void Init()
    {
        //MyCharacter가 존재하지 않는 경우 MyCharacter만듦
        for (int i = 0; i < AllStoreList.Count; i++)
        {
            MyStoreList.Add(AllStoreList[i]);
        }
        Save();
        Load();
    }

    void Save()
    {
    

        //리스트가 바로 저장이 안되는 관계로 위에 클래스를(serializeationData) 만들어 줬음
        //joson데이터로 직렬화해서 string형으로 변환
        string jdata = JsonUtility.ToJson(new SerializationData<Store>(MyStoreList));
        //debug.log(jdata);
        File.WriteAllText(filepath2, jdata);

        TabClick();
    }


    void Load()
    {



        //mycharacterText파일이 존재하지 않으면 init에서 새로 만들어줌
        if (!File.Exists(filepath2)) { Init(); return; }

        //데이터를 불러와서 mycharacter리스트에 역 직렬화 후 저장
        //리스트가 바로 저장이 안되는 관계로 위에 클래스를 만들어 줬음
        string jdata = File.ReadAllText(filepath2);
        MyStoreList = JsonUtility.FromJson<SerializationData<Store>>(jdata).target;

        TabClick();

    }



    public void RemodelingClick(int Buttonindex)
    {

        Store CurFurniture = CurStoreList.Find(x => x.Furnitureindex == Buttonindex);
        CurFurniture.RemodelingMagnifiaction = CurFurniture.RemodelingMagnifiaction + 1;


        Save();

        print(CurFurniture.RemodelingMagnifiaction);
    }


    public void LevelUpButton(int Buttonindex)
    {

        Store CurFurniture = CurStoreList.Find(x => x.Furnitureindex == Buttonindex);

        if (SingletonMng.instance.Money >= CurFurniture.UpgradeCost)
        {
            SingletonMng.instance.Money = SingletonMng.instance.Money - CurFurniture.UpgradeCost;
            CurFurniture.Level = CurFurniture.Level + 1;
            print(CurFurniture.Level);
            Save();
        }

        //
    }


    void Show_FurnitureLevelUpButton_UI()
    {
       

        for (int i = 0; i < CurStoreList.Count; i++)
        {
            print("시발 " + CurStoreList.Count);
            Store CurFurniture = CurStoreList.Find(x => x.Furnitureindex == i);
            if (SingletonMng.instance.Money >= CurFurniture.UpgradeCost)
            {
                FurnitureLevelUpButton[i].sprite =FurnitureLevelUpButton_Active;
            }
            else if (SingletonMng.instance.Money < CurFurniture.UpgradeCost)
            {
                FurnitureLevelUpButton[i].sprite = FurnitureLevelUpButton_UnActive;
            }

        }
       

       
    }

    void Update()
    {
        Show_FurnitureLevelUpButton_UI();
    }



}


