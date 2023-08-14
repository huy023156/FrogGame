using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackButton : MonoBehaviour {
    private Button menuButton;

    private void Start() {
        menuButton = GetComponent<Button>();

        menuButton.onClick.AddListener(() => {
            Loader.LoadWithoutLoading(Loader.Scene.MainMenu);
        });
    }


}
