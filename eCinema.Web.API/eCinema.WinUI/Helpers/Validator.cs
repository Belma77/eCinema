using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI.Helpers
{
    public class Validator
    {
        public static bool Validate(Control control, ErrorProvider err, string message)
        {
            bool _setError = false;

            if (control is TextBox && string.IsNullOrEmpty(control.Text))
                _setError = true;

            else if (control is ComboBox && (string.IsNullOrEmpty((control as ComboBox).Text) || (control as ComboBox).SelectedIndex < 0))
                _setError = true;

            else if (control is CheckedListBox && (string.IsNullOrEmpty((control as CheckedListBox).Text) || (control as CheckedListBox).SelectedIndex < 0 || (control as CheckedListBox).CheckedItems.Count<1))
                _setError = true;

            else if (control is PictureBox && (control as PictureBox).Image == null)
                _setError = true;

            else if (control is RichTextBox && string.IsNullOrEmpty(control.Text))
                _setError = true;

            else if (control is DataGridView)
            {
                if ((control as DataGridView).Rows.Count >= 2)
                {

                    foreach (DataGridViewRow row in (control as DataGridView).Rows)
                    {

                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value == null)
                                    _setError = true;
                            }
                        }

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in (control as DataGridView).Rows)
                    {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value == null)
                                    _setError = true;
                            }

                    }
                }
            }

                if (_setError)
                {
                    err.SetError(control, message);
                    return false;
                }

                err.Clear();
                return true;
            
        }
    }
}
    

