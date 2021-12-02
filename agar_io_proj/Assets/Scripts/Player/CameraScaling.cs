using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScaling : MonoBehaviour
{
    //отдаление камеры в моменты поедани€ еды и ботов. »спользова плагин Cinemachine

    CinemachineVirtualCamera vcam;
    float normalSize;
    private void Start()
    {
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        normalSize = vcam.m_Lens.OrthographicSize;
    }

    public void ScaleUp(float size) //плавное увеличение камеры
    {
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize,  vcam.m_Lens.OrthographicSize + size* 2.5f, Time.deltaTime);           
    }

}
