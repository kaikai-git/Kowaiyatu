using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
        // 指定したシーン名に移動する
        SceneManager.LoadScene(SceneName);
    }

    public void PauseTitle()
    {
        ChangeScene("StartScene");
    }
    public void PauseQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
        Application.Quit();//ゲームプレイ終了
        #endif
    }
}
