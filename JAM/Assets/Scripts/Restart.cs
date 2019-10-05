using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Restart : MonoBehaviour
{
    public float total;
    public Text timerF;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        total -= Time.deltaTime;
        timerF.text = (int) total + "";
        if (total < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
