using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{
    public void showchat(GameObject obj)
    {
    obj.SetActive(true);
    }
    public void hidechat(GameObject obj)
    {
    obj.SetActive(false);   
    }
}
