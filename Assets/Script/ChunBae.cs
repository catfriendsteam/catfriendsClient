using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunBae : MonoBehaviour
{
    public GameObject menu_chunbae;
    public void ChunBaeButton()
    {
        menu_chunbae.SetActive(true);
    }
    public void XButton()
    {
        menu_chunbae.SetActive(false);
    }
}
