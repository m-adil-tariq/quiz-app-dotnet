using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace QuizApp
{
    public class BaseForm : MetroForm
    {
        public BaseForm()
        {
            this.Theme = MetroFramework.MetroThemeStyle.Light; 
            this.Style = MetroFramework.MetroColorStyle.Teal;

            this.BorderStyle = MetroFormBorderStyle.FixedSingle;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyThemeAndStyle(this.Controls);
        }

        private void ApplyThemeAndStyle(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is MetroLabel label)
                {
                    label.Theme = this.Theme;
                    label.Style = this.Style;
                }
                else if (ctrl is MetroButton button)
                {
                    button.Theme = this.Theme;
                    button.Style = this.Style;
                }
                else if (ctrl is MetroTextBox textBox)
                {
                    textBox.Theme = this.Theme;
                    textBox.Style = this.Style;
                }
                else if (ctrl is MetroComboBox comboBox)
                {
                    comboBox.Theme = this.Theme;
                    comboBox.Style = this.Style;
                }
                else if (ctrl is MetroGrid grid)
                {
                    grid.Theme = this.Theme;
                    grid.Style = this.Style;
                }
                else if (ctrl is MetroTile tile)
                {
                    tile.Theme = this.Theme;
                    tile.Style = this.Style;
                }

                if (ctrl.HasChildren)
                {
                    ApplyThemeAndStyle(ctrl.Controls);
                }
            }
        }
    }
}

