using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndAnimation_Chunbae : MonoBehaviour
{
    public Animator Animator_Chunbae;
    public StatusManager StatusMng;
    public bool IsTouched_Chunbae;

    void Awake()
    {
        Animator_Chunbae = GetComponent<Animator>();

        IsTouched_Chunbae = false;
    }

        // Update is called once per frame
        void Update()
    {
    
    }




    //에니메이터에 트리거를 호출하여 애니메이션을 하게 만듭니다.
    public void ToTouched_Chunbae()
{
        Animator_Chunbae.SetTrigger("IsTouched_Trigger");
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
