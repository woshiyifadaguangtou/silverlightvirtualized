using SilverlightPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        //public VirtualDataList Data { get; set; }
        public MainPage()
        {
            InitializeComponent();
            List<Data> Items = new List<Data>();
            List<Column> columns = new List<Column>()
            {
             new Column() { Text="姓名",DataMember = new System.Windows.Data.Binding ("Name"),Width = new GridLength (50)},
             new Column() { Text="年龄",DataMember = new System.Windows.Data.Binding ("Age"),Width = new GridLength (50)  },
             new Column() { Text="地址",DataMember = new System.Windows.Data.Binding ("Address") ,Width = new GridLength (50) },
             new Column() { Text="电话",DataMember = new System.Windows.Data.Binding ("PhoneNO") ,Width = new GridLength (50) },
             new Column() { Text="本月读数",DataMember = new System.Windows.Data.Binding ("Byds") ,Width = new GridLength (100) },
           new Column() { Text="上次读数",DataMember = new System.Windows.Data.Binding ("Scds") ,Width = new GridLength (150) },
           new Column() { Text="收款方式",DataMember = new System.Windows.Data.Binding ("Skfsname") ,Width = new GridLength (150) },
           new Column() { Text="签约银行",DataMember = new System.Windows.Data.Binding ("Yhname") ,Width = new GridLength (150) },
          };

           
            List<Customer> customerList = new List<Customer>();



            for (int i = 0; i < 10000; i++)
            {
                customerList.Add(
                new Customer() {
                    Name = String.Format("Davie{0}", i),
                    Age = i,
                    Address = "中国北京朝阳区",
                    PhoneNO = "13X_XXXX_XXXX",
                    Byds = i.ToString(),
                    Scds = i,
                    Dj = i,
                    Skfsname = i%2 ==0? "现金" :"储蓄",
                    Yhname = "中国银行"
                });
            }

            int pageNum = customerList.Count();
            int pageSize = 30;

            for (int i = 0; i < pageNum / pageSize +1; i++)
            {
                Items.Add(new Data {RowHeight = 25,RowCount = pageSize,FontSize = 10 ,TextWrap = TextWrapping.Wrap,Columns = columns, ItemsSource = customerList.Skip(pageSize * i).Take(pageSize), Name = "Test" + i, Page = this, ImageUri = new Uri("http://pic002.cnblogs.com/images/2012/152755/2012120917494440.png?index=" + i) });
            }
          //  listBox1.ItemsSource = Items;
            listBox2.ItemsSource = Items;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            
        }
    }
}
