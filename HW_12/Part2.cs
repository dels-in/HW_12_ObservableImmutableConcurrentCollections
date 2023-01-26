using System.Collections.Immutable;

namespace HW_12;

public class Part2
{
    public ImmutableList<string> Poem { get; private set; }

    public Part2(ImmutableList<string> poem)
    {
        Poem = poem;
    }

    public ImmutableList<string> AddPart(ImmutableList<string> prevPoem)
    {
        var newPoem = new List<string>(new[]
        { "\nА это пшеница,", 
            "Которая в темном чулане хранится", 
            "В доме,", 
            "Который построил Джек."
        }).ToImmutableList();
        Poem = prevPoem.Concat(newPoem).ToImmutableList();
        return Poem;
        }
    }