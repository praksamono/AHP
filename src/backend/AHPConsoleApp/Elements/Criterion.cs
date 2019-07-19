namespace AHP_Console
{
    public class Criterion
    {
        public string _name;
        public float _priority; //Global priority in respect to other criteria

        public Criterion(string name)
        {
            this._name = name;
            _priority = 0f; //Initial priority always set to 0
        }
    }
}
