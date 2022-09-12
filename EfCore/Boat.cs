using CSharpFunctionalExtensions;

namespace EfCore
{
    public class Boat:Entity,IHasName
    {
        public string Name { get; set; }
    }
}