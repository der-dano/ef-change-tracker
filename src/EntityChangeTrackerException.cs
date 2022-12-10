using System;
using System.Runtime.Serialization;

namespace DerDano.EntityFrameworkChangeTracker
{
    [Serializable]
    public class EntityChangeTrackerException : Exception
    {
        public EntityChangeTrackerException() { }
        public EntityChangeTrackerException(string message) : base(message) { }
        public EntityChangeTrackerException(string message, Exception inner) : base(message, inner) { }
        protected EntityChangeTrackerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}