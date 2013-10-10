using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Document : BaseElement<Document>
    {
        public Document()
        {
            ControlType = ControlType.Document;
        }

        public string GetDocumentText(int maxLength)
        {
            return ((TextPattern) Element.GetCurrentPattern(TextPattern.Pattern)).DocumentRange.GetText(maxLength);
        }
    }
}
