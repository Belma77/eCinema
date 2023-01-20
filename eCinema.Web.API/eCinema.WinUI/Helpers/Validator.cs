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

            else if (control is CheckedListBox && (string.IsNullOrEmpty((control as CheckedListBox).Text) || (control as CheckedListBox).SelectedIndex < 0))
                _setError = true;

            else if (control is PictureBox && (control as PictureBox).Image == null)
                _setError = true;

            else if (control is RichTextBox && string.IsNullOrEmpty(control.Text))
                _setError = true;

            else if (control is DataGridView)
            {
               
                //foreach (DataGridViewRow rw in (control as DataGridView).Rows)
                //{
                    
                //    //for (int i = 0; i < rw.Cells.Count; i++)
                //    //{
                //    //    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                //    //    {
                //    //        _setError = true;
                //    //    }
                //    //}
                //}
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
    

