using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource intro, loop;

    void Start()
    {
        StartCoroutine(IntroPlay());
    }

    private IEnumerator IntroPlay()
    {
        intro.Play();
        yield return new WaitForSeconds(5.05f);
        loop.Play();
        intro.Stop();        
    }
}
