using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LironHundreds
{
    class CircleCollider
    {
         public float Radius;
         public Vector2 Center;

        public CircleCollider( float Radius, Vector2 Center)
        {
            this.Radius = Radius;
            this.Center = Center;
        }

        public bool Intersects(CircleCollider other)
        {

            //step1: calculate the distance between the two positions
            //step2: calculate the sum of the radii

            //if the sum is greater than or equal to the distance between the centers
            //the objects collide, return true
            //intersection when, distance between centers is smaller than their Radii added together
            //find the distance between the two balls
            float distance = Vector2.Distance(Center, other.Center);

            if (Radius + other.Radius >= distance)
            {
                return true;
            }

            return false;
        }

        public bool ContainsPoint(float x, float y)
        {
            Vector2 point = new Vector2(x, y);
            float distanceBetween = Vector2.Distance(point, Center);

            if (distanceBetween < Radius)
            {
                return true;
            }
            return false;
        }
    }
}
