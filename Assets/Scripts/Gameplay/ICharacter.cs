using Gameplay.Health;

namespace Gameplay
{
    public interface ICharacter
    {
        IHealth Health { get; }
    }
}