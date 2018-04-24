using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class VRBuildSettings {

    [MenuItem("VR Build Settings/Update Selected Prefab In All Scenes")]
    static void CopySelectionToAllScenes() {
        // First, save the open Scene
        EditorSceneManager.SaveOpenScenes();
        // Save the path of the currently opened scene, so we can re-open it later
        string currentScenePath = EditorSceneManager.GetActiveScene().path;
        // Save the name of the currently selected gameobject, so we can find this prefab in other scenes
        string currentSelection = Selection.activeGameObject.name;

        // For every scene in the build list
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes) {
            if (S.enabled) {
                // Open the scene in the editor
                EditorSceneManager.OpenScene(S.path);
                // Try to find the prefab in this scene by name
                GameObject Prefab = GameObject.Find(currentSelection);
                // If the prefab was found
                if (Prefab != null) {
                    // "Revert" the prefab instance to the newly updated prefab instance.
                    PrefabUtility.RevertPrefabInstance(Prefab);
                }
            }
        }
        // Return to the original scene that we were working in
        EditorSceneManager.OpenScene(currentScenePath);
    }

    [MenuItem("VR Build Settings/Build GearVR")]
    static void BuildGearVRSettings() {
        // Define var for GoogleVR Viewer
        GvrViewer gvrViewer;
        // Define var for GoogleVR Head
        GvrHead gvrHead;
        // Try to find the main GoogleVR script
        try {
            gvrViewer = GvrViewer.Instance;            
        }
        // Log an error if GvrViewer could not be found
        catch {
            Debug.LogError("'GvrViewer' could not be found. Add 'VRMain' Prefab.");
            // Do not execute this script any further
            return;
        }
        // Try to find the GoogleVR Head script
        try {
            gvrHead = gvrViewer.transform.GetChild(0).GetComponent<GvrHead>();
        }
        // Log an error if GvrHead could not be found
        catch {
            Debug.LogError("'GvrHead' could not be found. Make sure the camera has a 'GvrHead' script or add the 'VRMain' Prefab.");
            // Do not execute this script any further
            return;
        }
        
        // Set the VR Mode on GoogleVR Viewer to False, this will make it go into a fullscreen mode.
        // Fullscreen mode will be broken into stereoscopic 3d render because of VR Supported Option in build settings.
        gvrViewer.VRModeEnabled = false;
        // Tell GoogleVR Head to not track position, because VR Supported mode does this now
        gvrHead.trackPosition = false;
        // Tell GoogleVR Head to not track rotation, because VR Supported mode does this now
        gvrHead.trackRotation = false;
        // Set the Virtual Reality Supported option in the Player Build Settings
        PlayerSettings.virtualRealitySupported = true;
        // This forces the inspector to update the settings on GoogleVR script
        EditorUtility.SetDirty(gvrViewer);
        // This forces the inspector to update the settings on Head script
        EditorUtility.SetDirty(gvrHead);
    }

    [MenuItem("VR Build Settings/Build GoogleVR")]
    static void BuildGoogleVRSettings(){
        // Define var for GoogleVR Viewer
        GvrViewer gvrViewer;
        // Define var for GoogleVR Head
        GvrHead gvrHead;
        // Try to find the main GoogleVR script
        try {
            gvrViewer = GvrViewer.Instance;
        }
        // Log an error if GvrViewer could not be found
        catch {
            Debug.LogError("'GvrViewer' could not be found. Add 'VRMain' Prefab.");
            // Do not execute this script any further
            return;
        }
        // Try to find the GoogleVR Head script
        try {
            gvrHead = gvrViewer.transform.GetChild(0).GetComponent<GvrHead>();
        }
        // Log an error if GvrHead could not be found
        catch {
            Debug.LogError("'GvrHead' could not be found. Make sure the camera has a 'GvrHead' script or add the 'VRMain' Prefab.");
            // Do not execute this script any further
            return;
        }

        // Set the VR Mode on GoogleVR Viewer to True, this will make it go into VR split screen mode.
        gvrViewer.VRModeEnabled = true;
        // Tell GoogleVR Head to track position
        gvrHead.trackPosition = false;
        // Tell GoogleVR Head to track rotation
        gvrHead.trackRotation = true;
        // Set the Virtual Reality Supported option in the Player Build Settings
        PlayerSettings.virtualRealitySupported = false;
        // This forces the inspector to update the settings on GoogleVR script
        EditorUtility.SetDirty(gvrViewer);
        // This forces the inspector to update the settings on Head script
        EditorUtility.SetDirty(gvrHead);
    }
}

/*
class PostAssetImport : AssetPostprocessor {
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
        foreach (string str in importedAssets) {
            Debug.Log("Reimported Asset: " + str);
        }
        foreach (string str in deletedAssets) {
            Debug.Log("Deleted Asset: " + str);
        }

        for (int i = 0; i < movedAssets.Length; i++) {
            Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
        }
    }
}
*/