using CSharpFunctionalExtensions;

namespace EfCore
{
    public class Tour: Entity,IHasName
    {
        public string Name { get; set; }
    }
}