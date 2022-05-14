using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SimpleWebApp.Dependency;

namespace SimpleWebApp
{
    public class DependencyService2
    {
        private readonly IOpeTransient _opeTransient;
        private readonly IOpeScoped _opeScoped;
        private readonly IOpeSingleton _opeSingleton;
        private readonly IOpeSingletonInstance _opeSingletonInstance;

        public DependencyService2(IOpeTransient opeTransient, IOpeScoped opeScoped, IOpeSingleton opeSingleton, IOpeSingletonInstance opeSingletonInstance)
        {
            this._opeTransient = opeTransient;
            this._opeScoped = opeScoped;
            this._opeSingleton = opeSingleton;
            this._opeSingletonInstance = opeSingletonInstance;
        }

        public void write()
        {
            Console.WriteLine("From Servcie2: ");
            Console.WriteLine($"Transient - {_opeTransient.OperationId}");
            Console.WriteLine($"Scoped - {_opeScoped.OperationId} ");
            Console.WriteLine($"Singleton - {_opeSingleton.OperationId}");
            Console.WriteLine($"Singleton Instance - {_opeSingletonInstance.OperationId}");
        }
    }
}
