using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RandomTest02
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SynchronizationContext SyncContext;
        List<string> NameList;
        public MainWindow()
        {
            InitializeComponent();


            SyncContext = new SynchronizationContext();
            SyncContext = SynchronizationContext.Current;

            NameList = new List<string>() {
                        "程忠 "   ,
                        "程忠1 "   ,
                        "程忠2 "   ,
                        "程忠3 "   ,
                        "程忠4 "   ,
                        "程忠5 "   ,
                        "程忠6 "   ,
                        "程忠7"  ,
                        "程忠8 "   ,
                        "程忠9 "   

              };

        }


        public void OnUpdateUI(Action action)
        {
            SyncContext.Post(new SendOrPostCallback(o =>
            {
                action();
            }), null);
        }

        private async void btn_start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Task.Run(() => { changeNumber(); });
            }
            catch
            {
                MessageBox.Show("ERROR!");
                return;
            }
        }


        async void changeNumber()
        {
            OnUpdateUI(() => { btn_start.IsEnabled = false; });
            Random random = new Random();
            int delayTime = 10;
            for (int i = 0; i < 25; i++)
            {
                if (i == 24)
                {
                    OnUpdateUI(() => {

                        this.txb_1.Text = "程忠";
                        this.txb_2.Text = "程忠";
                        this.txb_3.Text = "程忠 ";
                    }
                    );
                    break;
                }

               

                int index1 = random.Next(0, NameList.Count);
                int index2 = random.Next(0, NameList.Count);
                int index3 = random.Next(0, NameList.Count);

                OnUpdateUI(() => {
                    this.txb_1.Text = NameList[index1];
                    this.txb_2.Text = NameList[index2];
                    this.txb_3.Text = NameList[index3];
                }
                );

                await Task.Delay(delayTime);
                delayTime += 5;
            }

            OnUpdateUI(() => { btn_start.IsEnabled = true; });
        }




    }
}
