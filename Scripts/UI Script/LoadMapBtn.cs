using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMapBtn : MonoBehaviour
{

    public void LoadMapBtnPressed()
    {
        SceneManager.LoadScene(1);
    }
}
