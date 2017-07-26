

namespace OneWeek2017
{
    public interface IScriptableObject
    {
        string VariableName { get;}
		string Documentation { get;}
        // Returns the name of the variable and it's type, ie. 'Door doorName'
        //
        string GetParameterizedName();
    }
}
