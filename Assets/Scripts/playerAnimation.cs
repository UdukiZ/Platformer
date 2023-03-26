using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void playerSpeed(float playerSpeed)
    {
        _anim.SetFloat("playerSpeed", Mathf.Abs(playerSpeed));
    }

    // public void isJumping(bool isJumping)
    // {
    //     _anim.SetBool("isJumping", isJumping);
    // }
}
