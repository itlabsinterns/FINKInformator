using System.ComponentModel;

namespace ItLabs.FinkInformator.Api.Models
{
    public class Enums
    {
        public enum Program
        {
            [Description("КНИ")]
            KNI,
            [Description("ПЕТ")]
            PET,
            [Description("ИКИ")]
            IKI,
            [Description("МТ")]
            MT,
        }
    }
}