using System;
using MongoDB.Bson;

namespace Book.Domains
{
   
    public class BaseEntity
    {
        public ObjectId Id { get; set; }

    }
}
