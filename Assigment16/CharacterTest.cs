using UnityEngine;

namespace Assignment18
{
    public class CharacterTest : MonoBehaviour
    {
    
        private void Start()
        {
            Character[] characters = new Character[]
            {
                new Soldier(), 
                new Officer("Captain John", 90, new Position(5, 10, 15)) // Using parameterized constructor for Officer
            };

            foreach (Character character in characters)
            {
                character.DisplayInfo();
            }

            Officer officer = (Officer)characters[1];
            Soldier soldier = (Soldier)characters[0];

            Debug.Log($"Soldier's Health before attack: {soldier.Health}");
            officer.Attack(20, soldier, "shooting");
            Debug.Log($"Soldier's Health after attack: {soldier.Health}");
        }
    }
}
