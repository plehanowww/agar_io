using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScaling : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    float normalSize;
    private void Start()
    {
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        normalSize = vcam.m_Lens.OrthographicSize;
    }

    public void ScaleUp()
    {
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, vcam.m_Lens.OrthographicSize + 2.5f, Time.deltaTime);           
    }
    public void ScaleDown()
    {
        //vcam.m_Lens.OrthographicSize *= 1.1f;
    }
}
