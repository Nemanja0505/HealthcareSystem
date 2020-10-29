/***********************************************************************
 * Module:  Entity.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.Entity
 ***********************************************************************/

namespace Class_diagram.Model.Patient
{
    public class Entity
    {
        public Entity() { }
        public Entity(int id )
        {
            this.ID = id;
        }
        public int ID { get; set; }
    }
}