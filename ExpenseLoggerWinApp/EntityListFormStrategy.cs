using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerWinApp
{
    /// <summary>
    /// Performs common actions for EntityForms.
    /// </summary>
    public class EntityListFormStrategy
    {
        private DataGridView dataGrid;
        public EntityListFormStrategy( DataGridView grid)
        {
            this.dataGrid = grid;
            //TODO:Configure grid(configure once,configure all)
        }

        /// <summary>
        /// Gets the Id column of selected item on grid.
        /// Assumes that datagrid has a column (int)Id on index 0.
        /// </summary>
        /// <returns></returns>
        public int GetSelectedRowItemId()
        {
            int id = 0;
            //TODO:Get selected row
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (dataGrid.Rows[i].Selected)
                {
                    id = Convert.ToInt32(dataGrid.Rows[i].Cells[0].Value.ToString());
                    break;
                }
            }

            return id;
        }

        public void DisplayExpenseRecordDetailsForm(int id = 0)
        {
            using (var form = new FormExpenseRecord(id))
            {
                form.ShowDialog();
            }
        }

        public void DisplayProductDetailsForm(int id = 0)
        {
            using (var form = new FormProduct(id))
            {
                form.ShowDialog();
            }
        }

        public void DisplayCompanyDetailsForm(int id = 0)
        {
            using (var form = new FormCompany(id))
            {
                form.ShowDialog();
            }
        }


    }
}
