using System.Collections.Immutable;

namespace HW_12;

public class Part5
{
    public ImmutableList<string> Poem { get; private set; }

    public Part5(ImmutableList<string> poem)
    {
        Poem = poem;
    }

    public ImmutableList<string> AddPart(ImmutableList<string> prevPoem)
    {
        var newPoem = new List<string>(new[]
        {
            "\nВот пес без хвоста,", 
            "Который за шиворот треплет кота,", 
            "Который пугает и ловит синицу,", 
            "Которая часто ворует пшеницу," , 
            "Которая в темном чулане хранится", 
            "В доме,",
            "Который построил Джек."
        }).ToImmutableList();
        Poem = prevPoem.Concat(newPoem).ToImmutableList();
        return Poem;
    }
}