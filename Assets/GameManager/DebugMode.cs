using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    [SerializeField] GameObject mapping;
    [SerializeField] GameObject debugLog;
    [SerializeField] GameObject markers;

    private BoxCollider[] markerCollider;
    private MeshRenderer[] markerMesh;

    private void Awake()
    {
        markerCollider = markers.GetComponentsInChildren<BoxCollider>();
        markerMesh = markers.GetComponentsInChildren<MeshRenderer>();

    }
    public void SetDebugMode()
    {
        mapping.SetActive(true);
        debugLog.SetActive(true);
        foreach (var col in markerCollider)
        {
            col.enabled = true;
        }
        foreach (var mesh in markerMesh)
        {
            mesh.enabled = true;
        }
    }

    public void SetPlayMode()
    {
        mapping.SetActive(false);
        debugLog.SetActive(false);
        foreach (var col in markerCollider)
        {
            col.enabled = false;
        }
        foreach (var mesh in markerMesh)
        {
            mesh.enabled = false;
        }
    }
}
