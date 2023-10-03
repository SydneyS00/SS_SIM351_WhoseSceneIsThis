using UnityEngine;

namespace Pattern.Visitor
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        //public float health = 50.0f; // Percentage
        public Rigidbody _cubeRB;
        public Vector3 currentSize; 


        public Vector3 CubeSize()
        {
            //This sets our currentSize variable to the size of the cube
            _cubeRB.transform.localPosition = currentSize;
            return currentSize; 
        }
        //public float Damage(float damage)
        //{
            //health -= damage;
            //return health;
        //}
    
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        //void OnGUI() 
       //{
            //GUI.color = Color.green;
            
            //GUI.Label(
                //new Rect(125, 0, 200, 20), 
                //"Shield Health: " + health);
        //}
    }
}