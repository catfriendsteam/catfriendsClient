using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FevergageTextManager : MonoBehaviour
{
    public GageMng gagemng;
    public GameObject Fevergage_Text;



    void update()
    {
        Fevercheck();
    }


    void Fevercheck()
    {
        if (gagemng.isfever == true)
        {
            Fevergage_Text.SetActive(true);
            print("활성화");

        }
        else if(gagemng.isfever == false)
        {
            Fevergage_Text.SetActive(true);
            print("비활성화");

        }
    }


}
