using System.ComponentModel;

namespace flix.comics.Enums
{
    public enum Status
    {
        [Description("In Publication")]
        InPublication = 1,
        [Description("Comics Completed")]
        Completed = 2,
        [Description("Comics Canceled or Descontinued")]
        Canceled = 3
    }
}
