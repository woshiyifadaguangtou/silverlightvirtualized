using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Runtime;
using System.Text;
using System.Collections;
using SilverlightPrint;

namespace SilverlightApplication1
{
    public class Data:INotifyPropertyChanged
    {
        public Double PageHeight { get { return (RowCount+1) * RowHeight + 30; } }
        public int RowCount { get; set; }
        public double RowHeight { get; set; }
        public TextWrapping TextWrap { get; set; }
        public double FontSize { get; set; }
        public Thickness CellPadding { get; set; }
        public Thickness Margin { get; set; }
        public List<Column> Columns { get; set; }
        public IEnumerable ItemsSource
        {
            get; set;
        }
        public string Name { get; set; }
        public UIElement Page { get; set; }

        public Uri ImageUri
        {
            get
            {
                return imageUri;
            }

            set
            {
                if (imageUri == value)
                {
                    return;
                }
                imageUri = value;
                
            }
        }

        private Uri imageUri;
        

        #region 下载图片所需参数
        WeakReference bitmapImage;


        public ImageSource ImageSource
        {
            get
            {
                Debug.WriteLine(String.Format("加载数据{0}",Name));
                if (bitmapImage != null)
                {
                    if (bitmapImage.IsAlive)
                        return (ImageSource)bitmapImage.Target;
                    else
                        Debug.WriteLine("数据已经被回收");
                }


                if (imageUri != null)
                {
                    Task.Factory.StartNew(() => { DownloadImage(imageUri); });
                }
                return null;
            }
        }

        #endregion

        #region TextContent
        WeakReference controlTemplateReference;
        public TextBlock TextContent
        {
            get 
            {
                Debug.WriteLine(String.Format("加载模版{0}", Name));
                if(controlTemplateReference != null)
                {
                    if (controlTemplateReference.IsAlive)
                        return (TextBlock)controlTemplateReference.Target;
                    else
                        Debug.WriteLine("数据已经被回收");
                }


                Task.Factory.StartNew(() => { DrawGrid(); });
                
                return null;
            }
        }
        #endregion

        #region Report
        WeakReference reportReference;

        public Panel ReportPanel
        {
            get
            {
                Debug.WriteLine(String.Format("加载报表第{0}页", Name));
                if (reportReference != null)
                {
                    if (reportReference.IsAlive)
                        return (Panel)reportReference.Target;
                    else
                        Debug.WriteLine("数据已经被回收");
                }


                Task.Factory.StartNew(() => { DrawReport(); });

                return null;
            }
        }

        #endregion
        private void DrawGrid()
        {
            Debug.WriteLine(String.Format("绘制模版{0}", Name));
            Page.Dispatcher.BeginInvoke(() =>
            {
                TextBlock textBlock = new TextBlock ();
                textBlock.Text =String.Format("{0}:{1}",this.Name,DateTime.Now);
                textBlock.Height = 400;
                if(controlTemplateReference == null)
                    controlTemplateReference = new WeakReference (textBlock);
                else
                    controlTemplateReference.Target = textBlock;
                OnPropertyChanged("TextContent");
            });
        }
        private void DownloadImage(Uri uri)
        {
            try
            {
                /*由于SL的跨域访问限制,SL不能访问承载站点以外的域*/


                ServiceReference1.ImageServiceClient client = new ServiceReference1.ImageServiceClient();
                //client.DownLoadCompleted += client_DownLoadCompleted;
                //client.DownLoadAsync(uri);
               
                client.DownLoad1Completed += client_DownLoad1Completed;
                client.DownLoad1Async(uri);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void DrawReport()
        {
            Debug.WriteLine(String.Format("绘制模版{0}", Name));
            Page.Dispatcher.BeginInvoke(() =>
            {
                Panel panel = new Grid();
                Grid grid = DrawReportGrid();
                panel.Children.Add(grid);
                panel.HorizontalAlignment = HorizontalAlignment.Stretch;
                panel.VerticalAlignment = VerticalAlignment.Top;
                panel.Height = RowHeight * RowCount;
                Grid.SetRow(panel, 1);
                if (reportReference == null)
                    reportReference = new WeakReference(panel);
                else
                    reportReference.Target = panel;
                OnPropertyChanged("ReportPanel");
            });
        }

        void client_DownLoad1Completed(object sender, ServiceReference1.DownLoad1CompletedEventArgs e)
        {
            var result = e.Result;
            MemoryStream streamForUI = new MemoryStream(result, 0, result.Length);//将byte转换为内存流
            Page.Dispatcher.BeginInvoke(() =>
            {
                BitmapImage bm = new BitmapImage();

                bm.SetSource(streamForUI);
                if (bitmapImage == null)
                    bitmapImage = new WeakReference(bm);
                else
                    bitmapImage.Target = bm;
                OnPropertyChanged("ImageSource");
            });
        }

        Grid DrawReportGrid()
        {
            Grid result = new Grid();
            result.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(RowHeight) });
            int j = 0;
            foreach (var colunm in Columns)
            {
                result.ColumnDefinitions.Add(new ColumnDefinition() { Width = colunm.Width });
                TextBlock tb = new TextBlock();
                tb.FontSize = this.FontSize;
                tb.Text = colunm.Text;

                tb.VerticalAlignment = VerticalAlignment.Center;
                result.Children.Add(tb);
                Grid.SetRow(tb, result.RowDefinitions.Count - 1);
                Grid.SetColumn(tb, j);
                j++;
            }

            foreach (var item in ItemsSource)
            {
                result.RowDefinitions.Add(new RowDefinition() { Height = new GridLength (RowHeight) });
                int i = 0;
                foreach (var colunm in Columns)
                {
                    TextBlock tb = new TextBlock();
                    tb.FontSize = this.FontSize;
                    if (colunm.DataMember != null)
                        tb.SetBinding(TextBlock.TextProperty, colunm.DataMember);
                    tb.DataContext = item;
                    tb.TextWrapping = this.TextWrap;

                    tb.VerticalAlignment = VerticalAlignment.Center;
                    result.Children.Add(tb);
                    Grid.SetRow(tb, result.RowDefinitions.Count - 1);
                    Grid.SetColumn(tb, i);
                    i++;
                }
            }
            return result;
        }
        void AddGridHeader(Grid grid, List<Column> ls, int rowindex, ref int colSpan, ref int colIndex, List<Column> colNodes, int maxLayer)
        {
            if (ls.Count > 0)
            {
                if (rowindex == grid.RowDefinitions.Count)
                {
                    RowDefinition hRow = new RowDefinition();
                    hRow.Height = GridLength.Auto;
                    grid.RowDefinitions.Add(hRow);
                }

                for (int i = 0; i < ls.Count; i++)
                {
                    Column col = ls[i];
                    TextBlock tb = new TextBlock()
                    {
                        Text = col.Text,
                        FontWeight = FontWeights.Bold,
                        FontSize = this.FontSize,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = CellPadding,
                        TextWrapping = this.TextWrap
                    };
                    grid.Children.Add(tb);
                    Grid.SetRow(tb, rowindex);

                    Rectangle line = new Rectangle() { Width = 1, StrokeThickness = 0.5, Stroke = new SolidColorBrush(Colors.LightGray), HorizontalAlignment = HorizontalAlignment.Right };
                    //竖线

                    grid.Children.Add(line);
                    Grid.SetRow(line, rowindex);
                    Grid.SetColumn(line, colIndex);

                    //横线
                    Rectangle line2 = new Rectangle()
                    {
                        Height = 1,
                        StrokeThickness = 0.5,
                        Stroke = new SolidColorBrush(Colors.LightGray),
                        VerticalAlignment = VerticalAlignment.Bottom
                    };
                    grid.Children.Add(line2);
                    Grid.SetRow(line2, rowindex);

                    int pcolSpan = colSpan;
                    Grid.SetColumn(tb, colIndex);
                    Grid.SetColumn(line2, colIndex);
                    if (col.Columns.Count > 0)
                    {
                        AddGridHeader(grid, col.Columns, rowindex + 1, ref colSpan, ref colIndex, colNodes, maxLayer);
                        if (colSpan > pcolSpan)
                        {
                            int cspan = colSpan - pcolSpan;
                            Grid.SetColumnSpan(tb, cspan);
                            Grid.SetColumnSpan(line, cspan);
                            Grid.SetColumnSpan(line2, cspan);
                        }
                    }
                    else
                    {
                        colNodes.Add(col);

                        colSpan++;
                        ColumnDefinition colDef = new ColumnDefinition();
                        colDef.Width = col.Width;
                        grid.ColumnDefinitions.Add(colDef);

                        if (maxLayer > rowindex + 1)
                        {
                            int rspan = maxLayer - rowindex;
                            tb.VerticalAlignment = VerticalAlignment.Center;
                            Grid.SetRowSpan(tb, rspan);
                            Grid.SetRowSpan(line, rspan);
                            Grid.SetRowSpan(line2, rspan);
                        }
                        colIndex++;
                    }

                }

            }

        }
        int AddGridBody(Grid grid, Size printableArea, List<Column> colNodes, Size itemsPanelMaxSize, int ix, Grid pagePanel, Panel itemsPanel)
        {
            List<object> ls = ItemsSource.Cast<object>().ToList();
            for (int j = ix; j < ls.Count; j++)
            {
                //手动分页


                object currentItem = ls[j];

                PrintingEventArgs args = new PrintingEventArgs();
                args.DataContext = currentItem;
                // OnBeginBuildReportItem(args);

                grid.RowDefinitions.Add(new RowDefinition());
                // create row. Set data context.
                for (int i = 0; i < colNodes.Count; i++)
                {
                    Column col = colNodes[i];
                    TextBlock tb = new TextBlock() { Margin = CellPadding, TextAlignment = col.TextAlignment };
                    tb.FontSize = this.FontSize;
                    if (col.DataMember != null)
                        tb.SetBinding(TextBlock.TextProperty, col.DataMember);
                    tb.DataContext = currentItem;
                    tb.TextWrapping = this.TextWrap;

                    tb.VerticalAlignment = VerticalAlignment.Center;
                    grid.Children.Add(tb);
                    Grid.SetRow(tb, grid.RowDefinitions.Count - 1);
                    Grid.SetColumn(tb, i);
                }

                grid.Measure(printableArea);
                if (grid.DesiredSize.Height > itemsPanelMaxSize.Height)
                {
                    grid.RowDefinitions.RemoveAt(grid.RowDefinitions.Count - 1);
                    int n = colNodes.Count;
                    for (int i = 0; i < n; i++)
                        grid.Children.RemoveAt(grid.Children.Count - 1);
                    return j;
                }
            }
            return ls.Count;
        }
        private Grid GetNewPage(Size printableArea, out Panel itemsPanel, out Size itemsPanelMaxSize)
        {
            const int HeaderGridRowNumber = 0;
            const int BodyGridRowNumber = 1;
            const int FooterGridRowNumber = 2;

            // CurrentPageNumber++;

            Grid outerGrid = new Grid();
            outerGrid.Margin = new Thickness(0);
            outerGrid.Background = new SolidColorBrush(Colors.White);
            Grid pagePanel = new Grid();
            pagePanel.Margin = Margin;
            outerGrid.Children.Add(pagePanel);

            RowDefinition headerRow = new RowDefinition();
            headerRow.Height = GridLength.Auto;

            RowDefinition itemsRow = new RowDefinition();
            itemsRow.Height = new GridLength(1, GridUnitType.Star);

            RowDefinition footerRow = new RowDefinition();
            footerRow.Height = GridLength.Auto;

            pagePanel.RowDefinitions.Add(headerRow);
            pagePanel.RowDefinitions.Add(itemsRow);
            pagePanel.RowDefinitions.Add(footerRow);

            // page header.
            double headerDesiredHeight = 0;
            FrameworkElement header = null;

            //page body
            itemsPanel = new Grid();
            itemsPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            itemsPanel.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(itemsPanel, BodyGridRowNumber);
            pagePanel.Children.Add(itemsPanel);


            //page footer.
            double footerDesiredHeight = 0;


            itemsPanelMaxSize = new Size(printableArea.Width - Margin.Left - Margin.Right,
                printableArea.Height - Margin.Top - Margin.Bottom - footerDesiredHeight - headerDesiredHeight);

            

            return pagePanel;
        }
        void RemoveMostRightLine(Grid grid)
        {
            int lastIndex = 0;
            for (int i = 0; i < grid.Children.Count; i++)
            {
                var c = grid.Children[i] as FrameworkElement;
                if (c is Rectangle && (c as Rectangle).Width == 1)
                {
                    FrameworkElement nc = i + 1 == grid.Children.Count ? null : grid.Children[i + 1] as FrameworkElement;
                    int col = Grid.GetColumn(c);
                    int row = Grid.GetRow(c);
                    if (nc != null)
                    {
                        if (Grid.GetRow(nc) != row)
                        {
                            grid.Children.RemoveAt(i);
                            i--;
                        }
                    }
                    lastIndex = i;
                }
            }
            grid.Children.RemoveAt(lastIndex);
        }




        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string property)
        {
            var hander = PropertyChanged;
            Page.Dispatcher.BeginInvoke(() =>
            {
                if (hander != null)
                    hander(this, new PropertyChangedEventArgs(property));
            });
        }
    }
}
