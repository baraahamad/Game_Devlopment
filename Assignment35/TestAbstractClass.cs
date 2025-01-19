using UnityEngine;

public class TestAbstractClass : MonoBehaviour
{
    private DerivedClassExample derivedClass;

    void Start()
    {
        derivedClass = new DerivedClassExample();
        derivedClass.PerformAction();
        derivedClass.PrintInfo();
    }
}
