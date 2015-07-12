using UnityEngine;
using System.Collections;
using System.Threading;
public class thread : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Thread t = new Thread(new ThreadStart(Cal));
	}

    void Cal()
    {
        print("Hellp");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
