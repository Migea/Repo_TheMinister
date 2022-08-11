using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransController : MonoBehaviour
{
    //cc С��
    public Animator transition;

    private void OnEnable()
    {
        Close();
    }

    public void Open()
    {
        transition.SetTrigger("Open");
    }

    public void Close()
    {
        transition.SetTrigger("Close");
    }

}
