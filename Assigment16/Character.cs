using UnityEngine;

namespace Assignment18
{
    public class Character
    {
        public string Name;
        private int health;
        protected Position position;

        public int Health
        {
            get { return health; }
            set { health = Mathf.Clamp(value, 0, 100); }
        }

        public Character(string name, int health, Position position)
        {
            Name = name;
            Health = health;
            this.position = position;
        }

        public Character() : this("No name", 100, new Position(0, 0, 0)) { }

        public virtual void DisplayInfo()
        {
            Debug.Log($"Name: {Name}, Health: {Health}");
            position.PrintPosition();  // Call the PrintPosition method from Position struct
        }

        public void Attack(int damage, Character target)
        {
            target.Health -= damage;
        }

        public void Attack(int damage, Character target, string attackType)
        {
            Debug.Log($"Attack Type: {attackType}");
            Attack(damage, target);
        }
    }
}
