using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Endplay : MonoBehaviour
{
    //public int endnum;

    //0病院1城
    [SerializeField] Sprite[] EndSprite;
    [SerializeField] Image EndImage;
    public RectTransform pos;
    public RectTransform posEndNumText;
    [SerializeField] Text endtext;
    [SerializeField] Text endNumText;
    [TextArea]
    public string[] Endtext;
    public string[] EndNumtext;
    //スクロール速度変数
    public float ScrolSpeed = 0.2f;
    private float scrollAmount ;
    float Alpha;

//フェード用黒画像
     [SerializeField] Image FadeBlack;

    [SerializeField] SceneChange scenechange;
    void Start()
    {
        EndPlayer.endnum = EndPlayer.instance.DecideEnd();
        endmovie();
        scrollAmount = ScrolSpeed * Time.deltaTime; // scrollAmountを初期化
        
        
    }

    void Update()
    {
        if(posEndNumText.anchoredPosition.y < 0)
        {
            pos.anchoredPosition  += new Vector2(0, scrollAmount);
            posEndNumText.anchoredPosition  += new Vector2(0, scrollAmount);
        }
        else
        {
            //Invoke("SceneChange", 3.0f);
            StartCoroutine(BlackOut(FadeBlack));
            StartCoroutine(Scenechange());
        }
       
        //OnEndNumtext();
    }
    //文章とイメージ変更
    public void endmovie()
    {
        if(EndPlayer.endnum == 1)
        {
            EndImage.sprite = EndSprite[0];
            endtext.text = Endtext[0];
            endNumText.text = EndNumtext[0];
        }
        else if(EndPlayer.endnum == 2)
        {
            EndImage.sprite = EndSprite[0];
            endtext.text = Endtext[1];
            endNumText.text = EndNumtext[1];
        }
        else if(EndPlayer.endnum == 3)
        {
            EndImage.sprite = EndSprite[1];
            endtext.text = Endtext[2];
            endNumText.text = EndNumtext[2];
        }
    }

    public void OnEndNumtext()
    {
       if (posEndNumText.anchoredPosition.y < 500)
        {
            Debug.Log("1");
        }
    }

    //posEndNumText.anchoredPosition.yの移動が完了したら３秒後にスタートシーンに戻る
    // private void SceneChange()
    // {
    //     float fadeSpeed = 0.55f;
    //    //scenechange.ChangeScene("StartScene");
    //     Alpha +=  fadeSpeed * Time.deltaTime;
    // }

    private IEnumerator BlackOut(Image black)
    {   
        float fadeSpeed = 0.5f;
        float kussyon = 0.002f;
       yield return new WaitForSeconds(2.2f);
        while(black.color.a < 1f)
        {
            black.color = new Color(
             black.color.r,
             black.color.g, 
             black.color.b, 
             black.color.a + fadeSpeed * Time.deltaTime * kussyon
            );
             yield return null;
             //scenechange.ChangeScene("StartScene");
        }
    }

    private IEnumerator Scenechange()
    {
        yield return new WaitForSeconds(6);
        scenechange.ChangeScene("StartScene");
    }
}



