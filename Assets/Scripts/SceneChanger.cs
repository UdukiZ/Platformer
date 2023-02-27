using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{   
     void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("touch");
     if (other.gameObject.tag == "Player")
         SceneManager.LoadScene (1);
    }
	// public void ChangeScene(string sceneName)
	// {
	// 	SceneManager.LoadScene (name);
	// }
	// public void Exit()
	// {
	// 	Application.Quit ();
	// }
}
