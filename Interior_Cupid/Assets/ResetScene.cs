#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ResetScene : MonoBehaviour
{
    void Start()
    {
        print("Start");
    }
    public void Resetsession()
    {
        // SceneManager.LoadScene("SampleScene");
        //EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
#endif