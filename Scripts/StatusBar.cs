using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Slider bar;

    public void Set(int curr, int max)
    {
        bar.maxValue = max;
        bar.value = curr;

        text.text = curr.ToString() + "/" + max.ToString();
    }

}
