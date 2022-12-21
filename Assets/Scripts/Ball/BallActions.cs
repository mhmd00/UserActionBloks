using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BallActions : MonoBehaviour
{
    [SerializeField] GameObject gameObjectToBeMoved;
    [Range(1,1000)][SerializeField] float movingSpeed;
    public delegate void BallAction();
    public Dictionary<string,Action> BallActionsMethods = new Dictionary<string, System.Action>();

    public void CreateDictionaryOfBallActions()
    {
        BallActionsMethods = new Dictionary<string,Action>()
      {
          {"MoveForward", () => MoveForward() },
          {"MoveBackward", () => MoveBackward() },
          {"Jump", () => Jump() }
      };

    }
    public void MoveForward()
    {
        print("call MoveForward");
        gameObjectToBeMoved.GetComponent<Rigidbody>().AddForce(Vector3.forward * movingSpeed);
    }

    public void MoveBackward()
    {
        print("call MoveBaackward");
        gameObjectToBeMoved.GetComponent<Rigidbody>().AddForce(Vector3.back * movingSpeed);
    }

    public void Jump()
    {
        print("call Jump");
        gameObjectToBeMoved.GetComponent<Rigidbody>().AddForce(Vector3.up * movingSpeed);
    }

}
