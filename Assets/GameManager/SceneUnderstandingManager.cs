using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.SceneUnderstanding;

public class SceneUnderstandingManager : MonoBehaviour
{
    private AsyncOperation async;

    // Start is called before the first frame update
    async void Start()
    {
        if (!SceneObserver.IsSupported())
        {
            return; // Handle the error
        }

        await SceneObserver.RequestAccessAsync();

        // Create Query settings for the scene update
        SceneQuerySettings querySettings;

        querySettings.EnableSceneObjectQuads = true;                                       // Requests that the scene updates quads.
        querySettings.EnableSceneObjectMeshes = true;                                      // Requests that the scene updates watertight mesh data.
        querySettings.EnableOnlyObservedSceneObjects = false;                              // Do not explicitly turn off quad inference.
        querySettings.EnableWorldMesh = true;                                              // Requests a static version of the spatial mapping mesh.
        querySettings.RequestedMeshLevelOfDetail = SceneMeshLevelOfDetail.Fine;            // Requests the finest LOD of the static spatial mapping mesh.

        // Initialize a new Scene
        Scene myScene = SceneObserver.ComputeAsync(querySettings, 10.0f).GetAwaiter().GetResult();
    }

    // This call should grant the access we need.


}
