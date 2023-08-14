using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI cherryCollectText;

    private void Awake() {
        menuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenu);
        });

        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void Start() {
        cherryCollectText.text = "Cherry Collected: " + ItemCollector.Instance.cherryCount;

        PlayerPrefs.DeleteAll();
    }
}
