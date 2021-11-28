using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class IntroLoaderScript : MonoBehaviour {
	
	//public int index;
	
	//public Image BlackImage;
	//public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			SceneManager.LoadScene ("Menu");
		}
		else{
			StartCoroutine ("coRoutineTest");
		}
	}

IEnumerator coRoutineTest () {

		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene ("Menu");
	}
	/*IEnumerator Fading (){
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>BlackImage.color.a==1);
		SceneManager.LoadScene(1);
	}*/
}
