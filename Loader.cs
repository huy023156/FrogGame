using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {
    public enum Scene {
        MainMenu,
        LoadingScene,
        LevelSelection,
        Level0,
        Level1,
        EndGame,
    }

    public static Scene targetSceneName;

    public static void Load(Scene targetSceneName) {
        Loader.targetSceneName = targetSceneName;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadWithoutLoading(Scene targetSceneName) {
        SceneManager.LoadScene(targetSceneName.ToString());
    }

    public static void LoaderCallback() {
        SceneManager.LoadScene(targetSceneName.ToString());
    }
}

