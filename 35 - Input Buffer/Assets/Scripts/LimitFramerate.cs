using UnityEngine;

public class LimitFramerate : MonoBehaviour
{
    public static int FPS = 60;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
    }

}
