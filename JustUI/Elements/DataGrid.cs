using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace JustUI.Elements
{
    public class DataGrid : ContainerElement<DataGrid>
    {
        public DataGrid()
        {
            ControlType = ControlType.DataGrid;
        }

        private ScrollPattern ScrollPattern
        {
            get
            {
                return ((ScrollPattern) Element.GetCurrentPattern(ScrollPattern.Pattern));
            }
        }

        public bool IsScrollable()
        {
            return ScrollPattern.Current.VerticallyScrollable;
        }

        public T GetCell<T>(int rowIndex, int columnIndex, int waitInMilliSeconds = 10000)
            where T : BaseElement<T>, new()
        {
            var automationElement = new Wait(waitInMilliSeconds).UntillNotNull(
                () => GetCellElement(rowIndex, columnIndex));
            return new T {Element = automationElement};
        }

        public int GetColumnIndex(string columnName)
        {
            var col = GetColumnHeaders().IndexOf(columnName);
            return col;
        }

        private AutomationElement GetCellElement(int rowIndex, int columnIndex)
        {
            TablePattern tablePattern = GetTablePattern();
            AutomationElement cellElement = tablePattern.GetItem(rowIndex, columnIndex);
            var cellIsVirtual = (bool) cellElement.GetCurrentPropertyValue(AutomationElementIdentifiers.IsVirtualizedItemPatternAvailableProperty);
            if(cellIsVirtual)
                ((VirtualizedItemPattern)cellElement.GetCurrentPattern(VirtualizedItemPattern.Pattern)).Realize();
            return cellElement;
        }

        public int GetRowCount()
        {
            return GetTablePattern().Current.RowCount;
        }

        public List<string> GetColumnHeaders()
        {
            return GetTablePattern().Current.GetColumnHeaders().Select(element => element.Current.Name).ToList();
        }

        private TablePattern GetTablePattern()
        {
            return ((TablePattern) Element.GetCurrentPattern(TablePattern.Pattern));
        }

        public string[] GetColumnTextData(string columnName)
        {
            var rowCount = GetRowCount();
            var columnData = new string[rowCount];
            var columnIndex = GetColumnIndex(columnName);
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var cell = GetCell<Custom>(rowIndex, columnIndex,30000);
                columnData[rowIndex] = cell.Get<Text>().GetName();
            }
            return columnData;
        }

        public string[] GetColumnData(string columnName)
        {
            var rowCount = GetRowCount();
            var columnData = new string[rowCount];
            var columnIndex = GetColumnIndex(columnName);
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var cell = GetCell<Custom>(rowIndex, columnIndex);
                columnData[rowIndex] = cell.GetName();
            }
            return columnData;
        }

        public string[] GetDataItemTextForColumnValues(string columnName)
        {
            var rowCount = GetRowCount();
            var columnData = new string[rowCount];
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                columnData[rowIndex] =GetAll<DataItem>()[rowIndex].Get<Text>().GetName();
            }
            return columnData;
        }

        public void WaitForColumnToLoad(string columnName, int waitInMilliSeconds)
        {
            new Wait(waitInMilliSeconds).UntillTrue(() => GetColumnIndex(columnName) != -1);
        }
    }
}
