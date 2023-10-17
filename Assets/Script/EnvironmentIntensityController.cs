using UnityEngine;

public class EnvironmentIntensityController : MonoBehaviour
{
    public float newIntensity = 0f; // 新しいintensity multiplierの値

    void Start()
    {
        // スクリプトがアクティブになったときにambientIntensityを変更
        RenderSettings.ambientIntensity = newIntensity;
    }

    // 新しいintensity multiplierの値を変更するためのメソッド
    public void ChangeIntensity(float intensity)
    {
        RenderSettings.ambientIntensity = intensity;
    }
}