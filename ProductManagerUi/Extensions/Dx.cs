using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;

namespace ProductManagerUi.Extensions
{
    public static class Dx
    {
        public static DataGridBuilder<T> SetDataGridDefaults<T>(this DataGridBuilder<T> dataGridBuilder)
        {
            return dataGridBuilder
                    .SetDataGridDefaults(true, true);

        }

        public static DataGridBuilder<T> SetDataGridDefaults<T>(this DataGridBuilder<T> dataGridBuilder, bool showColumnChooser, bool showGroupPanel)
        {
            return dataGridBuilder
                    .FilterRow(f => f.Visible(true))
                    .HeaderFilter(f => f.Visible(true))
                    .GroupPanel(p => p.Visible(showGroupPanel))
                    .FilterPanel(p => p.Visible(true))
                    .LoadPanel(p => p.Enabled(true))
                    .Grouping(g => g.AutoExpandAll(false))
                    .AllowColumnResizing(true)
                    .Scrolling(s => s.Mode(GridScrollingMode.Standard))
                    .Paging(paging => paging.PageSize(25))
                    .Pager(Pager)
                    .ShowColumnLines(true)
                    .ShowRowLines(true)
                    .RowAlternationEnabled(true)
                    .ShowBorders(true)
                    .ColumnAutoWidth(true)
                    .ColumnChooser(c => c.Enabled(showColumnChooser))
                    .ColumnFixing(c => c.Enabled(true));

        }

        public static void Pager(DataGridPagerBuilder pager)
        {
            pager.Visible(true);
            pager.DisplayMode(GridPagerDisplayMode.Full);
            pager.ShowPageSizeSelector(true);
            pager.AllowedPageSizes(new[] { 25, 50, 75, 100 });
            pager.ShowInfo(true);
            pager.ShowNavigationButtons(true);
        }

    }

}
