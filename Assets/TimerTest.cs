using UnityEngine;
using System.Collections;

public class TimerTest : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        yield return StartCoroutine(MyWaitFunction(1.0f));
        print("1");
        yield return StartCoroutine(MyWaitFunction(2.0f));
        print("2");
	}
	
    IEnumerator MyWaitFunction(float delay)
    {
        float timer = Time.time + delay;
        while (Time.time < timer)
        {
            yield return null;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
