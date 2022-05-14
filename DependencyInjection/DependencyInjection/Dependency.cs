using System;
using static SimpleWebApp.Dependency;

namespace SimpleWebApp
{
    public class Dependency
    {
        public interface IOperation
        {
            Guid OperationId { get; }
        }
        public interface IOpeTransient : IOperation { }
        public interface IOpeScoped : IOperation { }
        public interface IOpeSingleton : IOperation { }
        public interface IOpeSingletonInstance : IOperation { }

        public class Operation : IOpeTransient, IOpeScoped, IOpeSingleton, IOpeSingletonInstance
        {
            public Operation() : this(Guid.NewGuid()) { }
            public Operation(Guid ID)
            {
                OperationId = ID;
            }      
            public Guid OperationId { get; private set; }
        }
    }
}
