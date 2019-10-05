using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action PopDialogOnProximity;
    public void PopDialogProximity()
    {
        if (PopDialogOnProximity != null)
        {
            PopDialogOnProximity();
        }
    }

    public event Action HideDialogOnLeave;
    public void HideDialogProximity()
    {
        if (HideDialogOnLeave != null)
        {
            HideDialogOnLeave();
        }
    }

}
