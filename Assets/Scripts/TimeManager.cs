using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.05f; //how much the time slow
    public float slowdownLenght = 2f; //how much long will the slow time last

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
    }

}
