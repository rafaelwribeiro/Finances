using System.ComponentModel;

namespace FinancesAPI.Types;

public enum MovementType
{
    [Description("C")]
    Credit=0,
    [Description("D")]
    Debit=1
}