using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class EarthCatcher : MonoBehaviour
{
    [SerializeField] Transform room;

    public bool isCatch = false;
    public void CatchObject()
    {
        isCatch = true;
        transform.parent = room;
    }
    public void ReleaseObject()
    {
        isCatch = false;
    }

    public void SetManipuleator(bool flag)
    {
        GetComponent<ObjectManipulator>().enabled = flag;
        GetComponent<NearInteractionGrabbable>().enabled = flag;
    }
}
