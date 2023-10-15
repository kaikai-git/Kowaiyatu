using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image blackBackground;
    [SerializeField] Image FadeInBlack;

    [SerializeField] Image mouseImage;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    public GameObject StartButton;
    public GameObject QuitButton;
    private bool text1Faded = false;
    
    [SerializeField] SceneChange scenechange;

    void Start()
    {
        // フェードインしてシーン開始
        Color color = FadeInBlack.color;
        color.a = 1f;
        FadeInBlack.color = color;
        StartCoroutine(FadeIn(FadeInBlack));
    }

    //スタートボタンを押したとき
    public void OnClickbutton()
    { 
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        StartCoroutine(BlackOut(blackBackground));
    }

    //辞めるボタンを押したとき
    public void OnClickQuitbutton()
    { 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
        Application.Quit();//ゲームプレイ終了
        #endif
    }

    private IEnumerator BlackOut(Image black)
    {   
        float fadeSpeed = 0.55f;
        while (black.color.a < 1f)
        {
            black.color = new Color(
                black.color.r,
                black.color.g, 
                black.color.b, 
                black.color.a + fadeSpeed * Time.deltaTime
            );
            yield return null;
        }
              
        yield return new WaitForSeconds(2.5f);

        if (!text1Faded)
        {
            yield return StartCoroutine(UpAlpha(text1, 0.45f));
            text1Faded = true;
        }
        //マウス画像の透明度アップ
      StartCoroutine(ImageAlpha(mouseImage));

        yield return WaitForMousePress(0); // 左マウスボタンのクリックを待機

        yield return StartCoroutine(DownAlpha(text1, 0.50f));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(UpAlpha(text2, 0.45f));
        yield return WaitForMousePress(0); // 左マウスボタンのクリックを待機
        yield return StartCoroutine(DownAlpha(text2, 0.50f));
        yield return new WaitForSeconds(2.0f);
        scenechange.ChangeScene("GameScene");
    }
   
   //画像のアルファ変更
    private IEnumerator ImageAlpha(Image image)
{
    float minAlpha = 0.01f; // 透明度の最小値
    float maxAlpha = 0.99f; // 透明度の最大値
    float alphaSpeed = 0.33f;

    bool increasing = true; // 透明度を増加させるかどうかを管理

    while (true) // 無限ループ
    {
        if (increasing)
        {
            if (image.color.a < maxAlpha)
            {
                image.color = new Color(
                    image.color.r,
                    image.color.g, 
                    image.color.b, 
                    image.color.a + alphaSpeed * Time.deltaTime
                );
            }
            else
            {
                increasing = false; // 透明度が最大値に達したら減少モードへ
            }
        }
        else
        {
            if (image.color.a > minAlpha)
            {
                image.color = new Color(
                    image.color.r,
                    image.color.g, 
                    image.color.b, 
                    image.color.a - alphaSpeed * Time.deltaTime
                );
            }
            else
            {
                increasing = true; // 透明度が最小値に達したら増加モードへ
            }
        }

        yield return null;
    }
}
    private IEnumerator FadeIn(Image black)
    {
        float fadeSpeed = 0.3f;
        while (black.color.a > 0f)
        {
            black.color = new Color(
                black.color.r,
                black.color.g, 
                black.color.b, 
                black.color.a - fadeSpeed * Time.deltaTime
            );
            yield return null;
        }
        
    }

    private IEnumerator UpAlpha(Text text, float fadeSpeed)
    {
        Color startColor = text.color;
        while (startColor.a < 1f)
        {
            startColor = new Color(
                startColor.r,
                startColor.g, 
                startColor.b, 
                startColor.a + fadeSpeed * Time.deltaTime
            );
            text.color = startColor;
            yield return null;
        }
    }

    private IEnumerator DownAlpha(Text text, float fadeSpeed)
    {
        Color startColor = text.color;
        while (startColor.a > 0f)
        {
            startColor = new Color(
                startColor.r,
                startColor.g, 
                startColor.b, 
                startColor.a - fadeSpeed * Time.deltaTime
            );
            text.color = startColor;
            yield return null;
        }
    }

    private IEnumerator WaitForMousePress(int button)
    {
        while (!Input.GetMouseButtonDown(button))
        {
            yield return null;
        }
    }
}
