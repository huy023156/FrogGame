using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {
    private AudioSource finishSoundEffect;

    private bool levelCompleted = false;

    private void Start() {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player" && !levelCompleted) {
            finishSoundEffect.Play();
            //load next level
            levelCompleted = true;

            PlayerPrefs.SetInt("CherryCount", ItemCollector.Instance.cherryCount);

            Invoke("CompleteLevel", 2);
        }
    }

    private void CompleteLevel() {
        Loader.Scene currentEnum = Loader.targetSceneName;
        Loader.Scene nextEnum;

        var enumValues = Enum.GetValues(typeof(Loader.Scene));
        var currentIndex = Array.IndexOf(enumValues, currentEnum);

        if (currentIndex < enumValues.Length - 1) {
            nextEnum = (Loader.Scene) enumValues.GetValue(currentIndex + 1);

            if (nextEnum == Loader.Scene.EndGame) {
                Loader.LoadWithoutLoading(Loader.Scene.EndGame);
            } else {
                Loader.Load(nextEnum);
            }
        }
    }
}
