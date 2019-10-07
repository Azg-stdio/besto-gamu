using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoftRestart : MonoBehaviour
{

    [SerializeField] private float total;
    [SerializeField] TextMeshProUGUI timerF;
    [SerializeField] GameObject[] interactionObjects;
    private Dictionary<string, Transform> objectsResetTransforms;

    float remaining;
    void Start()
    {
        remaining = total;
        if(interactionObjects != null) foreach(GameObject obj in interactionObjects)
        {
                objectsResetTransforms.Add(obj.name, obj.transform);
        }
    }

    public void ChangeResetTransformForObject(string objName,Transform newValue)
    {
        objectsResetTransforms[objName] = newValue;
    }
    void ResetGame()
    {
        remaining = total;
        foreach(GameObject obj in interactionObjects)
        {
            obj.transform.position = objectsResetTransforms[obj.name].position;
            obj.transform.rotation = objectsResetTransforms[obj.name].rotation;
        }
    }

    private void Update()
    {
        remaining -= Time.deltaTime;
        timerF.text = (int)total + "";
        if (remaining < 0)
        {
            ResetGame();
        }
    }
}
