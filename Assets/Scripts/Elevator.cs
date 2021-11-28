using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
	public GameObject moveplatform;
	public GameObject Boss;
	private  void OnTriggerStay2D() 
	{
		
		
		moveplatform.transform.position += moveplatform.transform.up * Time.deltaTime;
			
	}
	
	
}