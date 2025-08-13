using Unity.Cinemachine;
using UnityEngine;

public enum CameraState
{
   Outside, Field, House, Animal
}

public class GameManager : SingleTon<GameManager>
{
    public FieldManager field;
    public UIManager_Farm ui;
    public ItemManager item;

    public CameraState camState = CameraState.Outside;

    [SerializeField] CinemachineClearShot clearShot;

    public void SetcamerState(CameraState newState)
    {
        if(camState != newState)
        {
            camState = newState;

            foreach (var camera in clearShot.ChildCameras)            
                camera.Priority = 1;            

            clearShot.ChildCameras[(int)camState].Priority = 10;
        }
    }
}


