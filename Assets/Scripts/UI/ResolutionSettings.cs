using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    Resolution[] res;
    public Toggle toggle;

    void Start()
    {
        Screen.fullScreen = true;
        toggle.isOn = false;

        Resolution [] resolution = Screen.resolutions;//Создаем массив из доступных значений разрешений
        res = resolution.Distinct().ToArray();//Создаем массив, для предотвращения создания дубликатов из массива resolution
        string[] strRes = new string[res.Length];//Преобразование массива res в тип string
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }
        dropdown.ClearOptions();//очищаем заранее заданные элементы dropdown
        dropdown.AddOptions(strRes.ToList());//добавляем в dropdown элементы из списка strRes
        dropdown.value = res.Length - 1;
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, Screen.fullScreen);
    }

    public void ScreenMode()
    {
        Screen.fullScreen = toggle.isOn;
    }
}
