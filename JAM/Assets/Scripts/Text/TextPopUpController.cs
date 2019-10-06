using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUpController : MonoBehaviour
{
    [SerializeField] GameObject panelWithText = null;
    [SerializeField] private TextMeshPro textMesh = null;
    [SerializeField] private char lineSpliter = ',';
    [SerializeField] private string[] npcDialogsInput;

    private int activeDialogNumber;
    private int activeLineNumber;

    private List<List<string>> npcDialogs = new List<List<string>>();
    private List<string> activeLines;
    void Start()
    {
        if (npcDialogsInput != null)
        {
            foreach (string text in npcDialogsInput)
            {
                List<string> aux = new List<string>(text.Split(lineSpliter));
                npcDialogs.Add(aux);
            }
            activeDialogNumber = 0;
            activeLineNumber = 0;
            activeLines = npcDialogs[activeDialogNumber];
        }
        for (int i = 0; i < activeLines.Count; i++) Debug.Log(activeLines[i]);
        panelWithText.SetActive(false);
    }

    public void ChangeActiveDialogNumber(int newActiveDialogNumber)
    {
        if (newActiveDialogNumber >= 0 && newActiveDialogNumber < npcDialogs.Count)
        {
            activeDialogNumber = newActiveDialogNumber;
            activeLineNumber = 0;
            activeLines = npcDialogs[activeDialogNumber];

        }
    }

    public void TurnOnDialog(float time = 3f)
    {
        
        panelWithText.SetActive(true);
        StartCoroutine(ChangeText(time));
        
    }

    public void TurnOffDialog()
    {
        StopCoroutine("ChangeText");
        Debug.Log("corutina, llamada");
        panelWithText.SetActive(false);
        activeLineNumber = 0;
    }

    private IEnumerator  ChangeText(float time)
    {
        while (true) { 
        if (activeLines != null)
            {
            Debug.Log(textMesh != null);
                textMesh.text = activeLines[activeLineNumber]; 
                if (activeLineNumber + 1 >= activeLines.Count) activeLineNumber = 0;
                else activeLineNumber++;
            }
        yield return new WaitForSecondsRealtime(time);
        }
    }

    // prueba para comprobar que este funcionando
    [SerializeField] Transform obj;
    bool bandera = false;
    private void Update()
    {
        Vector3 aux = obj.position - transform.position;
        
        if (!bandera && aux.magnitude < 10f)
        {
            TurnOnDialog();
            bandera = true;
        }
        if (bandera && aux.magnitude > 10f) { TurnOffDialog(); bandera = false; }
    }
}
