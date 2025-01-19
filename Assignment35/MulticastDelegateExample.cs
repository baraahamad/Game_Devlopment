using UnityEngine;

public class MulticastDelegateExample : MonoBehaviour
{
   
    delegate void MathOperation(int number);

    void Start()
    {
        MathOperation operation;

        operation = DoubleNumber;
        operation += SquareNumber;
        operation += CubeNumber;

        int input = 5;
        operation(input);
    }

   
    void DoubleNumber(int number) => Debug.Log("Double: " + (number * 2));

    void SquareNumber(int number) => Debug.Log("Square: " + (number * number));

    void CubeNumber(int number) => Debug.Log("Cube: " + (number * number * number));
}
