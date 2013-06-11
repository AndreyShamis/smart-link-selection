using System;
using System.Collections;

namespace Visualisator
{
    [Serializable()]
    class SimulationContainer:ISerializable
    {
        private ArrayList _objects;

        public ArrayList Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }
        public SimulationContainer(ArrayList _objs)
        {
            _objects = _objs;
            //_MEDIUM = _med;
        }
    }
}
