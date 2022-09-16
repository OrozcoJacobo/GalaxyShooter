using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
