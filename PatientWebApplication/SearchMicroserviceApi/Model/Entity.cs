/***********************************************************************
 * Module:  Entity.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.Entity
 ***********************************************************************/

namespace SearchMicroserviceApi.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public Entity() { }
        public Entity(int id)
        {
            Id = id;
        }
    }
}