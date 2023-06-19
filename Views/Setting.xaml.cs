using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multiple_Views.Views
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
        }

        public class CategoryInfo {
            public String Name { get; set; }
            public String Value { get; set; }
        }

        // Change languages
        private void btnChangeLang_Click(object sender, RoutedEventArgs e) {
            object selectedName = cbLang.SelectedValue;
            if (selectedName != null) {
                string langName = selectedName.ToString();
                if (langName == "en_US") {
                    langName = "DefaultLanguage";
                }
                ResourceDictionary? langRd = null;
                try {
                    langRd = Application.LoadComponent(new Uri(@"Strings\" + langName + ".xaml", UriKind.Relative)) as ResourceDictionary;
                } catch (Exception e2) {
                    MessageBox.Show(e2.Message);
                }

                if (langRd != null) {
                    if (this.Resources.MergedDictionaries.Count > 0) {
                        this.Resources.MergedDictionaries.Clear();
                    }
                    this.Resources.MergedDictionaries.Add(langRd);
                }
            } else {
                MessageBox.Show("Please selected one Language first.");
            }
        }

        // Control loads, ComboBox assignment
        private void cbLang_Loaded(object sender, RoutedEventArgs e) {
            List<CategoryInfo> categoryList = new List<CategoryInfo>();
            categoryList.Add(new CategoryInfo { Name = "English", Value = "en_US" });
            categoryList.Add(new CategoryInfo { Name = "中文", Value = "zh_CN" });

            cbLang.ItemsSource = categoryList;
            cbLang.DisplayMemberPath = "Name";
            cbLang.SelectedValuePath = "Value";
        }
    }
}
