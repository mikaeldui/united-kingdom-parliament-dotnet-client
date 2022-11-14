using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(PrefLabel)}}}")]
public abstract class TermBase : LinkedData
{
    public StringValue PrefLabel { get; set; }
}
