using System;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] private float timeClock;
    [SerializeField] private TextMeshProUGUI clock;
    public static Action<float> clockValue;
    // Update is called once per frame
    void Update()
    {
        timeClock-=Time.deltaTime;
        clock.text ="" + timeClock.ToString("f2");
        clockValue?.Invoke(timeClock);
    }
}
