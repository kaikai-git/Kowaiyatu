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
}
