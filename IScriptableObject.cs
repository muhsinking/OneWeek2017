

namespace OneWeek2017
{
    public interface IScriptableObject
    {
        string VariableName { get; set; }
        // Returns the name of the variable and it's type, ie. 'Door doorName'
        //
        string GetParameterizedName();
    }
}
