using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public string level;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            changeLevel(level);
            Debug.Log("change to " + level);
        }
    }

   

    public void changeLevel (string level )
    {
        SceneManager.LoadScene(level);
    }

    public void ChangeScene(string sceneName)
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
