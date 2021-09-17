using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Anim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.lastJumpBoolISwear || !Controller2D.collisions.below)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("inAir", true);
        }

        else if(Player.xAxisInput == 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("inAir", false);
        }
        else if(Player.xAxisInput == -1)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", true);
            anim.SetBool("inAir", false);
        }
        else if(Player.xAxisInput == 1)
        {
            anim.SetBool("isRunningRight", true);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("inAir", false);
        }
    }
}
