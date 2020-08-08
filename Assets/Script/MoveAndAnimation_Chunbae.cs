using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndAnimation_Chunbae : MonoBehaviour
{
    public Animator Animator_Chunbae;
    public StatusManager StatusMng;
    public bool IsTouched_Chunbae;
    public int Touch_count;

    void Awake()
    {
        Animator_Chunbae = GetComponent<Animator>();
          Touch_count =0;
          IsTouched_Chunbae = false;
    }

        // Update is called once per frame
        void Update()
    {
    
    }




    //에니메이터에 트리거를 호출하여 애니메이션을 하게 만듭니다.
    public void ToTouched_Chunbae()
{
        if(Touch_count == 0)
        {
            Touch_count = 1;
            Animator_Chunbae.SetInteger("touched_Index", 0);
            Animator_Chunbae.SetTrigger("IsTouched_Trigger");

        }
        else if(Touch_count == 1)
        {

            Touch_count = 2;
            Animator_Chunbae.SetInteger("touched_Index", 1);
            Animator_Chunbae.SetTrigger("IsTouched_Trigger");
           
        }
        else if (Touch_count == 2)
        {

            Touch_count = 3;
            Animator_Chunbae.SetInteger("touched_Index", 2);
            Animator_Chunbae.SetTrigger("IsTouched_Trigger");

        }
        else if (Touch_count == 3)
        {

            Touch_count = 0;
            Animator_Chunbae.SetInteger("touched_Index", 3);
            Animator_Chunbae.SetTrigger("IsTouched_Trigger");

        }
    }


}


/* 실험용 코드
IsTouched_Chunbae = StatusMng.IsTouched;

        if (IsTouched_Chunbae == true)
        {
            print("트루");
Animator_Chunbae.SetBool("IsTouched", true);
        }
        else if (IsTouched_Chunbae == false)
        {

            print("팔스");
Animator_Chunbae.SetBool("IsTouched", false);
        }
        */
