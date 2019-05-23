using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatorManager : MonoBehaviour {

    Animator anim;
    bool rotateHow=true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Rotate()
    {
        if (rotateHow == true)
        {
            anim.SetTrigger("rotate1");
            rotateHow = false;
        }
        else if (rotateHow == false)
        {
            anim.SetTrigger("rotate2");
            rotateHow = true;
        }
    }


}
