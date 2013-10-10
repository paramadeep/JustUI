using System.Windows.Automation;

namespace JustUI
{
    public class By
    {
        internal Condition Condition { get; set; }

        public static By Id(string id)
        {
            return new By {Condition = new PropertyCondition(AutomationElement.AutomationIdProperty, id)};
        }

        public static By Name(string name)
        {
            return new By {Condition = new PropertyCondition(AutomationElement.NameProperty, name)};
        }

        public static By IdAndName(string id, string name)
        {
            return new By {
                Condition =
                    new AndCondition(
                        new PropertyCondition(AutomationElement.NameProperty, name),
                        new PropertyCondition(AutomationElement.AutomationIdProperty, id))
            };
        }
    }
}
