using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public void ChangeScene (string sceneName )
    {

        SceneManager.LoadScene(sceneName);
        Debug.Log("isPressed " + sceneName);
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("isPressed: Quitting Application");
    }

}
