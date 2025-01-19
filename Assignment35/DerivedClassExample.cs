using UnityEngine;

public class DerivedClassExample : AbstractBaseClass
{
    
    public override void PerformAction()
    {
        Debug.Log("PerformAction is implemented in the derived class.");
    }
}
