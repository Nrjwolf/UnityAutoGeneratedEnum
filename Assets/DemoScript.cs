using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public One One;
    public Two Two;

    public string[] arrayOne;
    public string[] arrayTwo;

    [ContextMenu("Fill")]
    public void Fill()
    {
        var e1 = new CreateEnum.EnumClass(arrayOne.ToList(), "One");
        var e2 = new CreateEnum.EnumClass(arrayTwo.ToList(), "Two");

        CreateEnum.CreateEnumsInFile("Assets/Enums.cs", e1, e2);
    }
}
