using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCamShake : MonoBehaviour
{

    public Animator camAnim;

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }
}
