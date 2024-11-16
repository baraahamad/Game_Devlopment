using UnityEngine;

namespace Assignment18
{
    
    public class Soldier : Character
    {
        
        public Soldier(string name, int health, Position position) : base(name, health, position) { }
        
        public Soldier() : base() { }

        public override void DisplayInfo()
        {
            Debug.Log("Soldier");
            base.DisplayInfo();
        }
    }
}
