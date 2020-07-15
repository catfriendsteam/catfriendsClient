using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public int clickNum;

    public void OnScreenClicked()
    {
        clickNum += 1;
        Debug.Log(clickNum);
    }
}
