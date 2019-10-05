using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.PopDialogProximity();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.HideDialogProximity();
    }
}
