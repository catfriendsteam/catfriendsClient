using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=GNSD1-y6SeM
//https://www.youtube.com/watch?v=abwOVy5qTO4s

[System.Serializable] //직렬화
//캐릭터의 특성을 저장하는 클래스
public class Character
{
    //생성자
    public Character(string _Type,string _Name,int _Level,int _LevelUpCost,bool _isRocked)
    {
        Type = _Type;Name = _Name;Level = _Level;LevelUpCost = _LevelUpCost;isRocked = _isRocked;
    }
    public string Type, Name;
    public int Level, LevelUpCost;
    public bool isRocked;
    public float SpawnTime, CurTime;
}
public class CharacterManager : MonoBehaviour
{
    public TextAsset CharacterDatabase;
    public List<Character> AllCharacter,MyCharacter,CurCharacter;
    public string curType="Ncat"; //냥인인지 일반 고양이인지 담을 변수
    public GameObject[] Slot;
    public Sprite TabIdleSprite, TabSelectSprite;
    string filePath; //경로 저장변수

    void Start()
    {
        //전체 캐릭터 리스트 불러오기
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length-1).Split('\n');
        for(int i = 0; i < line.Length; i++)
        {
            //Type, Name, Level, LevelUpCost,isRocked를 구분
            string[] row = line[i].Split('\t');
            AllCharacter.Add(new Character(row[0],row[1],int.Parse(row[2]),int.Parse(row[3]),bool.Parse(row[4])));
        }

        filePath = Application.persistentDataPath + "/MyCharacterText.txt";
        //Load(); //MyCharacter불러옴
        //Save();
        //MyCharactor를 저장하는 
    }
    public void Unlock()
    {
        //뽑기에서 나온 캐릭터를 해금하는 함수
    }
    public void TabClick(string tabName)
    {
        //냥인/일반고양이 탭을 눌렀을때 클릭한 탭의 캐릭터만 보임
        curType = tabName;
        CurCharacter = MyCharacter.FindAll(x => x.Type == tabName);

        //슬롯과 텍스트 보이기
        for(int i = 0; i < Slot.Length; i++)
        {
            //Slot[i].SetActive(i < CurCharacter.Count);
            //이름과 레벨, 레벨업 비용을 다 바꿔줘야 하는데 어떻게 해야할지 모르겠넴...
            Slot[i].GetComponentInChildren<Text>().text = i < CurCharacter.Count ? CurCharacter[i].Name : "";    
        }
    }
    void Init()
    {
        
    }
    /*void Save()
    {
        //joson데이터로 직렬화해서 string형으로 변환
        string jdata = JsonConvert.SerializeObject(MyCharacter);
        //debug.log(jdata);
        File.WriteAllText(Application.dataPath + "/Center/MyCharacterText.txt",jdata);

        TabClick(curType);
    }

    void Load()
    {
        //if(!File.Exists(filePath)) { Init();return; }

        //데이터를 불러와서 mycharacter리스트에 역 직렬화 후 저장
        string jdata = File.ReadAllText(Application.dataPath + "/Center/MyCharacterText.txt");
        MyCharacter = JsonConvert.DesrializeObject<List<Character>>(jdata);

        TabClick(curType);
    }*/
}
