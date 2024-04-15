﻿using OpenCards.Assertation;
using OpenCards.Collections.Extensions;

namespace OpenCards.Collections.Players;

public class PlayerQueue<T>(IPlayerStorage<T> storage, IEqualityComparer<T> comparer) : IPlayerQueue<T>
{
    private readonly IPlayerStorage<T> storage = storage;
    private readonly IEqualityComparer<T> comparer = comparer;

    public T Attacker { get; private set; } = default!;
    public T Defender { get; private set; } = default!;
    public T Current { get; private set; } = default!;

    public bool IsAttackerQueue => Equals(Current, Attacker);
    public bool IsDefenderQueue => Equals(Current, Defender);

    public PlayerQueue(IPlayerStorage<T> storage) : this(storage, EqualityComparer<T>.Default) { }

    public void SetAttackerQueue() => Set(Attacker, Defender, current: Attacker);
    public void SetDefenderQueue() => Set(Attacker, Defender, current: Defender);
    public void SetAttackerQueue(T attacker, T defender) => Set(attacker, defender, current: attacker);
    public void SetDefenderQueue(T attacker, T defender) => Set(attacker, defender, current: defender);

    public T GetNextFrom(T player, int andSkip = 0)
    {
        IReadOnlyList<T> active = storage.Active;

        int index = storage.Active.IndexOf(player);

        int next = (index + 1 + andSkip) % active.Count;

        return active[next];
    }

    private void Set(T attacker, T defender, T current)
    {
        AssertSet(attacker, defender);

        Attacker = attacker;
        Defender = defender;

        Current = current;
    }

    private void AssertSet(T attacker, T defender)
    {
        Assert.IsNotDefault(attacker);
        Assert.IsNotDefault(defender);

        Assert.IsTrue(storage.IsActive(attacker));
        Assert.IsTrue(storage.IsActive(defender));
    }

    private bool Equals(T? left, T? right) => comparer.Equals(left, right);
}