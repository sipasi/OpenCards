using OpenCards.Durak.Game;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public interface IStateAsync : IState
{
    ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container);
}
