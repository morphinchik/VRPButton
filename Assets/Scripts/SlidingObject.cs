using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.Events;
using UnityEditorInternal;

[RequireComponent(typeof(HeldObject))]

public class SlidingObject : MonoBehaviour
{
    Transform parent;

    public Transform positionA;

    public Transform positionB;

    Vector3 offSet;

    public UnityEvent releasedA;

    public UnityEvent releasedB;

    public UnityEvent hitA;

    public UnityEvent hitB;

    int stateCurrent = 0;

    int statePrev = 0;

   
    private void Update()
    {
        if (parent != null)
        {
            transform.position = ClosestPointOnLine(parent.position) - offSet;
        }
        else
        {
            transform.position = ClosestPointOnLine(transform.position);
        }

        if (transform.position == positionA.position)
            //hitA.Invoke();
            stateCurrent = 1;
        else if (transform.position == positionB.position)
        {
            // hitB.Invoke();
            stateCurrent = 2;
        }
        else stateCurrent = 0;


        if (stateCurrent == 1 && statePrev == 0)
            hitA.Invoke();
        else if (stateCurrent == 2 && statePrev == 0)
            hitB.Invoke();
        else if ( stateCurrent ==0 && statePrev == 1)
            releasedA.Invoke();
        else if (stateCurrent == 0 && statePrev == 2)
            releasedB.Invoke();

          statePrev = stateCurrent;
    }
    public void Print(string str)
    { 
        print(str);
    }


    Vector3 ClosestPointOnLine(Vector3 point)
    {
        Vector3 vA = positionA.position + offSet;

        Vector3 vB = positionB.position + offSet;

        Vector3 vVector1 = point - vA;

        Vector3 vVector2 = (vB - vA).normalized;

        float temp = Vector3.Dot(vVector2, vVector1);

        if (temp <= 0)
        {
            return vA;
        }

        if (temp >= Vector3.Distance(vA,vB))  return vB;

        Vector3 vVector3 = vVector2 * temp;

        Vector3 vClosestPoint = vA - vVector3;

        return vClosestPoint;

    }
}
