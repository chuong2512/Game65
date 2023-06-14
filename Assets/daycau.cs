using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class daycau : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public Transform luoiCau;

    void Update()
    {
        lineRenderer.SetPosition(1, luoiCau.localPosition);
    }
}
