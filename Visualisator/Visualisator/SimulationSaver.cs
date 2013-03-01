using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Visualisator
{

    [Serializable()]
    class SimulationSaver:ISerializable
    {
        private ArrayList _objects;

        public ArrayList Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }
        private Medium _MEDIUM;

        internal Medium MEDIUM
        {
            get { return _MEDIUM; }
            set { _MEDIUM = value; }
        }

        public SimulationSaver(ArrayList _objs, Medium _med)
        {
            _objects = _objs;
            _MEDIUM = _med;
        }
    }
}
