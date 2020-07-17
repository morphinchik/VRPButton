using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class Events : MonoBehaviour
{

    public GameObject changeObject= null;

    public Material mareialRed;

    public Material materialGreen;


    public void drawRed()
    {
        changeObject.GetComponent<MeshRenderer>().material = mareialRed;
    }

    public void drawGreen()
    {
        changeObject.GetComponent<MeshRenderer>().material = materialGreen;
    }

}
