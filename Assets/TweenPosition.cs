using UnityEngine;
using System.Collections;

public class TweenPosition : MonoBehaviour {

	//0:not started;1,starting,2,start progress is over
	private int inited = 0;
	// Use this for initialization
	void Start () 
	{
		//TweenPosition tween = TweenPosition.Begin (gameObject,20,new Vector3(4,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (inited == 1) {
			//transform.position.y>=2?
				//inited=2:transform.position.y++;	
			//transform.position.y++;	
			Vector3 newPos = new Vector3(0,1.0f,0);
			this.transform.position=newPos;
		
		}
	}

	public void play()
	{
		//TweenPosition tween = gameObject.GetComponent<TweenPosition> ();
		//tween.PlayForward ();
		if (inited == 0) 
		{
			inited = 1;
		}
	}
}
