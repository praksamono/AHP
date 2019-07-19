using System;
using System.Collections.Generic;

namespace AHP_Console
{
    public class Alternative
    {
        public string _name;
        public List<float> _priorities; //List of local alternative priorities in each criterion(total of CriteriaNumber), the sum of which is the _goalPriority
        public float _goalPriority; //Alternative priority in respect to the AHP goal, sum of the elements in _priorities list

        public Alternative(string name)
        {
            this._name = name;
            _goalPriority = 0f;
            _priorities = new List<float>(); //Initialise list of local priorities
        }
    }
}
