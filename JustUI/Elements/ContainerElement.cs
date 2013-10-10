using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace JustUI.Elements
{
    public class ContainerElement<T> : BaseElement<T>
        where T : BaseElement<T>
    {
        private IEnumerable<AutomationElement> GetAutomationElementCollection(
            int waitInMilliSeconds, TreeScope relationship, Condition condition)
        {
            var elementCollection = new Wait(waitInMilliSeconds).Untill(
                () => Element.FindAll(relationship, condition), collection => collection.Count != 0);
            return elementCollection.Cast<AutomationElement>();
        }

        public List<TX> GetAll<TX>(int waitInMilliSeconds = WaitTime, Relation relationship = Relation.Descendents)
            where TX : BaseElement<TX>, new()
        {
            var childElement = new TX {Parent = Element};
            childElement.Condition = new PropertyCondition(
                AutomationElement.ControlTypeProperty, childElement.ControlType);
            var automationElements = GetAutomationElementCollection(
                waitInMilliSeconds, RelationshipMap[relationship], childElement.Condition);
            return automationElements.Select(element => new TX {Element = element}).ToList();
        }
    }
}
