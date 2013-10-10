using System.Collections.Generic;
using System.Windows.Automation;

namespace JustUI.Elements
{
    public abstract class BaseElement<T>
        where T : BaseElement<T>
    {
        protected const int WaitTime = 20000;
        protected internal Condition Condition;
        protected internal ControlType ControlType;
        protected internal AutomationElement Element;
        protected internal AutomationElement Parent;
        protected readonly Dictionary<Relation, TreeScope> RelationshipMap = new Dictionary<Relation, TreeScope>
            {
                {Relation.Descendents, TreeScope.Descendants},
                {Relation.Children, TreeScope.Children},
                {Relation.Parent, TreeScope.Parent}
            };

        public TX Get<TX>(By by, bool waitForEnabled = true, int waitInMilliSeconds = WaitTime, Relation relationship = Relation.Descendents) where TX : BaseElement<TX>, new()
        {
            var childElement = new TX {Parent = Element};
            childElement.Condition =
                new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, childElement.ControlType), by.Condition);
            childElement.Element = GetAutomationElement(
                waitForEnabled, waitInMilliSeconds, RelationshipMap[relationship], childElement.Condition);
            return childElement;
        }

        public TX Get<TX>(bool waitForEnabled = true, int waitInMilliSeconds = WaitTime, Relation relationship = Relation.Descendents) where TX : BaseElement<TX>, new()
        {
            var childElement = new TX {Parent = Element};
            childElement.Condition = new PropertyCondition(
                AutomationElement.ControlTypeProperty, childElement.ControlType);
            childElement.Element = GetAutomationElement(
                waitForEnabled, waitInMilliSeconds, RelationshipMap[relationship], childElement.Condition);
            return childElement;
        }

        private AutomationElement GetAutomationElement(bool waitForEnabled, int waitInMilliSeconds, TreeScope relationship, Condition condition)
            {
            var wait = new Wait(waitInMilliSeconds);
            var automationElement = wait.UntillNotNull(() => Element.FindFirst(relationship, condition));
            if (waitForEnabled)
            {
                wait.UntillTrue(() => !automationElement.Current.IsOffscreen);
                wait.UntillTrue(() => automationElement.Current.IsEnabled);
            }
            return automationElement;
        }

        public TX GetParent<TX>() where TX : BaseElement<TX>, new()
        {
            var tx = new TX();
            var child = Element;
            do
            {
                child = TreeWalker.RawViewWalker.GetParent(child);
            } while (!Equals(child.Current.ControlType, tx.ControlType));
            tx.Element = child;
            return tx;
        }
        public string GetName()
        {
            return Element.Current.Name;
        }
        public bool IsEnabled()
        {
            return Element.Current.IsEnabled;
        }
        public bool IsVisible()
        {
            return !Element.Current.IsOffscreen;
        }
        public void WaitToDiasppear(int waitInMilliSeconds)
        {
            new Wait(waitInMilliSeconds).Untill(() => Parent.FindFirst(TreeScope.Descendants, Condition), element => element == null);
        }

        public bool IsPresent()
        {
            return Element != null;
        }

        //ToDo:Deepak:Need better implementation
        protected void WaitForLoader()
        {
        }
    }
}
