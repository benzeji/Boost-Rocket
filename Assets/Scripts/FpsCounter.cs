using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    [SerializeField] private float hudRefreshRate = 1f;
 
    private float timer;
 
    private void Update()
    {
        if (!(Time.unscaledTime > timer)) return;
        var fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS: " + fps;
        timer = Time.unscaledTime + hudRefreshRate;
    }
}
