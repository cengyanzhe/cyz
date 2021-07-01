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
                        "白涛 "   ,
                        "赵强 "   ,
                        "周杨 "   ,
                        "刘芳 "   ,
                        "程忠 "   ,
                        "张昊 "   ,
                        "望超 "   ,
                        "王鹤潼"  ,
                        "陈鑫 "   ,
                        "郁健 "   ,
                        "古锦翠"  ,
                        "周云 "   ,
                        "黄栋梁"  ,
                        "徐承 "   ,
                        "崔孟奎"  ,
                        "高强 "   ,
                        "汪圣梁"  ,
                        "刘显昱"  ,
                        "喻露 "   ,
                        "孙宝贤"  ,
                        "廖元明"  ,
                        "庄道智"  ,
                        "潘成乐"  ,
                        "魏金文"  ,
                        "王林 "   ,
                        "乔月华"  ,
                        "黄莹 "   ,
                        "杜二宏"  ,
                        "刘震 "   ,
                        "葛家进"  ,
                        "郑成 "   ,
                        "谢涛 "   ,
                        "张准 "   ,
                        "于景水"  ,
                        "陈春花"  ,
                        "房瑜 "   ,
                        "张巍 "   ,
                        "谷英语"  ,
                        "刘海鹏"  ,
                        "周阳 "   ,
                        "石高峰"  ,
                        "柯岚岚"  ,
                        "王立威"  ,
                        "曾亚威"  ,
                        "孙振波"  ,
                        "邱丽娟"  ,
                        "王伟 "   ,
                        "刘雪莲"  ,
                        "王佳旻"  ,
                        "茅旭凌"  ,
                        "孙图凯"  ,
                        "王明鹃"  ,
                        "李超 "   ,
                        "韦文 "   ,
                        "阮承志"  ,
                        "王敬 "   ,
                        "董钒 "   ,
                        "刘东 "   ,
                        "YE JIAZHEN"

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
                        //this.txb_1.Text = "崔孟奎";
                        //this.txb_2.Text = "王鹤潼";
                        //this.txb_3.Text = "房瑜 ";
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
