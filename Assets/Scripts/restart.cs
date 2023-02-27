using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
     if (other.gameObject.tag == "Player")
        Destroy(other.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 }
