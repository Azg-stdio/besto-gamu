using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLumberjack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.PopDialogOnProximity += OnNearPlayer;
        GameEvents.current.HideDialogOnLeave += OnLeavePlayer;
    }


    private void OnNearPlayer()
    {
        Debug.Log("Uno");
    }

    private void OnLeavePlayer()
    {
        Debug.Log("Se fue");
    }
}
  