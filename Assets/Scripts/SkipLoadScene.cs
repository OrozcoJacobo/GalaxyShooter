using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLoadScene : MonoBehaviour
{
    public void SkipToLevel01()
    {
        SceneManager.LoadScene(2);
    }
}
