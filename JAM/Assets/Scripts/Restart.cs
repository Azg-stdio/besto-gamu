using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public float total;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        total -= Time.deltaTime;
        if (total < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
