using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeFun : MonoBehaviour
{
    public List<int> list = new List<int>();

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
