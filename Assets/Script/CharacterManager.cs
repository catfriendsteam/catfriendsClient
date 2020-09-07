using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

//센터 목록관리, 펫 배치, 레벨업 구현
//https://www.youtube.com/watch?v=GNSD1-y6SeM
//https://www.youtube.com/watch?v=abwOVy5qTO4s


//save용 클래스
[System.Serializable]
public class SerializationData<T>
{
    public SerializationData (List<T> _target) => target = _target;
    public List<T> target;
}

[System.Serializable] //직렬화
//캐릭터의 특성을 저장하는 클래스
public class Character
{
    //생성자 : 각각 타입(냥멍인/냥이),이름,레벨,레벨업비용,해금여부,레벨업 효과,설명글
    public Character(string _Type,string _Name,int _Level,int _LevelUpCost,bool _isRocked,float _LevelUpEffect,string _ExplainText)
    {
        Type = _Type;Name = _Name;Level = _Level;LevelUpCost = _LevelUpCost;isRocked = _isRocked;LevelUpEffect = _LevelUpEffect;ExplainText = _ExplainText;
    }
    public string Type, Name;
    public float LevelUpEffect;
    public int Level, LevelUpCost,Characteridx;
    public bool isRocked;

    [TextArea]
    public string ExplainText;

    //추가해야 할 변수 : 능력치들
}

public class CharacterManager : MonoBehaviour
{
    public TextAsset CharacterDatabase;
    public List<Character> AllCharacter,MyCharacter,CurCharacter;
    public string curType="Ncat"; //냥인인지 일반 고양이인지 담을 변수
    public GameObject[] Slot;

    //탭이미지 저장및 변환
    public Image[] TabImage;
    public Sprite TabIdleSprite, TabSelectSprite;

    //고양이, 냥인 그림 저장하는 리스트(AllCharacter데이터에 있는 순서대로 그림 넣어줘야 함)
    public GameObject[] CenterCharImages;

    //레벨업 관련 팝업창 이미지
    public GameObject LevelUpO,LevelUpX;

    string filePath; //경로 저장변수

    void Start()
    {
        //전체 캐릭터 리스트 불러와서 줄바꿈을 기준으로 데이터를 저장
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length-1).Split('\n');
        for(int i = 0; i < line.Length; i++)
        {
            //Type, Name, Level, LevelUpCost,isRocked,LevelUpEffect를 구분
            string[] row = line[i].Split('\t');
            AllCharacter.Add(new Character(row[0],row[1],int.Parse(row[2]),int.Parse(row[3]),bool.Parse(row[4]),float.Parse(row[5]),row[6]));

            //AllCharacter에서 isRocked가 false인 경우 CenterCharImages배열에서 이미지 불러옴
            if (!AllCharacter[i].isRocked)
            {
                GameObject instance=PrefabUtility.InstantiatePrefab(CenterCharImages[i]) as GameObject;
                instance.transform.SetParent(GameObject.Find("Content").transform,false);
            }
        }

        //모바일이든 컴퓨터든 파일이 저장된 경로에서 mycharacter 경로 저장
        //filePath = Application.persistentDataPath + "/Resources/MyCharacterText.txt";
        filePath = Application.persistentDataPath + "/MyCharacterText.txt";
        Debug.Log(filePath);
        Load(); //MyCharacter불러옴
    }

    public void TabClick(string tabName)
    {
        //냥인/일반고양이 탭을 눌렀을때 클릭한 탭의 캐릭터만 보임
        curType = tabName;
        //탭을 무엇을 클릭하느냐에 따라 냥멍인/고양이만 골라와서 curCharacter리스트에 저장
        CurCharacter = MyCharacter.FindAll(x => x.Type == tabName);

        //탭이미지 전환
        int tabNum = 0;
        switch (tabName)
        {
            case "Ncat": tabNum = 0;break;
            case "Cat": tabNum = 1;break;
        }
        for (int i = 0; i < 2; i++)
            TabImage[i].sprite = i == tabNum ? TabSelectSprite : TabIdleSprite;


        //슬롯과 텍스트 보이기
        for(int i = 0; i <10; i++)
        {
            //버튼인덱스 부여
            CurCharacter[i].Characteridx = i;

            //해금이 된 경우
            if (!CurCharacter[i].isRocked)
            {
                //내가 보유한 캐릭터의 이름 가져오기
                Text MyCharName = Slot[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                MyCharName.text = CurCharacter[i].Name;

                //내가 보유한 캐릭터의 레벨 가져오기
                Text MyCharLevel = Slot[i].transform.GetChild(3).gameObject.GetComponent<Text>();
                MyCharLevel.text = CurCharacter[i].Level.ToString();

                //내가 보유한 캐릭터의 설명 가져오기
                //데이터에 설명을...설명은 띄어쓰기가 되어있는데 어떻게 데이터로 저장하지ㅜㅜ? 
                //일단에디터에서 편집하는걸로
                Text MyCharExplain = Slot[i].transform.GetChild(4).gameObject.GetComponent<Text>();
                MyCharExplain.text = CurCharacter[i].ExplainText;

                //비용
                Text MyCharCost = Slot[i].transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
                MyCharCost.text = CurCharacter[i].LevelUpCost.ToString();

                //레벨업 효과
                Text MyCharEffect = Slot[i].transform.GetChild(5).GetChild(1).gameObject.GetComponent<Text>();
                MyCharEffect.text = CurCharacter[i].LevelUpEffect.ToString();

                //슬롯잠금이미지 해제
                GameObject Rock = Slot[i].transform.GetChild(6).gameObject;
                Rock.SetActive(false);
            }
            else //해금이 안된경우
            {
                Text MyCharName = Slot[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                MyCharName.text = "???";

                Text MyCharLevel = Slot[i].transform.GetChild(3).gameObject.GetComponent<Text>();
                MyCharLevel.text = "??";

                Text MyCharExplain = Slot[i].transform.GetChild(4).gameObject.GetComponent<Text>();
                MyCharExplain.text = "????";

                Text MyCharCost = Slot[i].transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
                MyCharCost.text = "???";

                Text MyCharEffect = Slot[i].transform.GetChild(5).GetChild(1).gameObject.GetComponent<Text>();
                MyCharEffect.text = "???";

                //슬롯잠금이미지 나타내기
                GameObject Rock = Slot[i].transform.GetChild(6).gameObject;
                Rock.SetActive(true);
            }
        }
    }

    void Init()
    {
        //MyCharacter가 존재하지 않는 경우 MyCharacter만듦
        for(int i = 0; i < AllCharacter.Count; i++)
        {
            MyCharacter.Add(AllCharacter[i]);
        }
        Save();
        Load();
    }
    void Save()
    {
        //리스트가 바로 저장이 안되는 관계로 위에 클래스를(serializeationData) 만들어 줬음
        //joson데이터로 직렬화해서 string형으로 변환
        string jdata = JsonUtility.ToJson(new SerializationData<Character>(MyCharacter));
        //debug.log(jdata);
        File.WriteAllText(filePath,jdata);

        TabClick(curType);
    }

    void Load()
    {
        //mycharacterText파일이 존재하지 않으면 init에서 새로 만들어줌
        if(!File.Exists(filePath)) { Init();return; }

        //데이터를 불러와서 mycharacter리스트에 역 직렬화 후 저장
        //리스트가 바로 저장이 안되는 관계로 위에 클래스를 만들어 줬음
        string jdata = File.ReadAllText(filePath);
        MyCharacter = JsonUtility.FromJson<SerializationData<Character>>(jdata).target;

        TabClick(curType);
    }

    public void CheckLevelUp(int Buttonidx)
    {
        //보유한 선행포인트가 레벨업 비용보다 많으면 레벨업 진행
        Character CurChar = CurCharacter.Find(x => x.Characteridx == Buttonidx);
        int NeedGoodPoint = CurChar.LevelUpCost;
        if (StatusManager.GoodPoint >= NeedGoodPoint)
         {
             StatusManager.GoodPoint -= NeedGoodPoint;
             CurChar.Level += 1;

             Save();
             Debug.Log("레벨업 성공");
             //LevelUpO.SetActive(true);
             //0.5초후에 사라지도록 하려면 코루틴 함수 필요?
         }
         else
         {
             Debug.Log("선행포인트가 부족해욧");
             //LevelUpX.SetActive(true);
         }
    }

    public void Unlock()
    {
        //뽑기에서 나온 캐릭터를 해금하는 함수
    }
}
