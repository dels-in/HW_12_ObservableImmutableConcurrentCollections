using System.Collections.Immutable;

namespace HW_12;

public class Part9
{
    public ImmutableList<string> Poem { get; private set; }

    public Part9(ImmutableList<string> poem)
    {
        Poem = poem;
    }

    public ImmutableList<string> AddPart(ImmutableList<string> prevPoem)
    {
        var newPoem = new List<string>(new[]
        {
            "\nВот два петуха,", 
            "Которые будят того пастуха,", 
            "Который бранится с коровницей строгою,",
            "Которая доит корову безрогую,", 
            "Лягнувшую старого пса без хвоста,", 
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,", 
            "Которая часто ворует пшеницу,", 
            "Которая в темном чулане хранится",
            "В доме,", 
            "Который построил Джек."
        }).ToImmutableList();
        Poem = prevPoem.Concat(newPoem).ToImmutableList();
        return Poem;
    }
}