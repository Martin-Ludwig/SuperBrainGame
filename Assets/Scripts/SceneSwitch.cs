using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public void ChangeScene(string SceneName)
    {
        if (SceneName == null)
        { }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
        
    }
}
