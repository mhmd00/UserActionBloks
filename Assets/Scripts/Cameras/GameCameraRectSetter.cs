using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraRectSetter : MonoBehaviour
{
    
    void Start()
    {
        this.GetComponent<Camera>().rect = new Rect(.57f, 0.06f, 0.4f, 0.5f);
        this.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
    }

}
