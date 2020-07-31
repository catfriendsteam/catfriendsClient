using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsideScene : MonoBehaviour
{
    public void Inside()
    {
        SceneManager.LoadScene(1);
    }
    public void Outside()
    {
        SceneManager.LoadScene(0);
    }
}
