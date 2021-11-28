﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarScript : MonoBehaviour {

    private bool loadScene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Slider sliderBar;

    
    void Start () {

        
        sliderBar.gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

      
        if (loadScene == false)
        {

            
            loadScene = true;

            
            sliderBar.gameObject.SetActive(true);

            loadingText.text = "Loading...";

            StartCoroutine(LoadNewScene(LoadingSceneName));

        }

    }

      IEnumerator LoadNewScene(string sceneName) {

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            loadingText.text = progress * 100f + "%";
            yield return null;

        }

    }

}
