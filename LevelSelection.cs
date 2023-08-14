using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {
    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    [SerializeField] private Button backButton;

    private void Awake() {
        level1.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.Level0);
        });

        level2.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.Level1);
        });

        backButton.onClick.AddListener(() => {
            Loader.LoadWithoutLoading(Loader.Scene.MainMenu);
        });
    }
}
