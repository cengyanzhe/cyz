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

namespace randomTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SynchronizationContext SyncContext;

        List<string> NumberList;
        public MainWindow()
        {
            InitializeComponent();
            SyncContext = new SynchronizationContext();
            SyncContext = SynchronizationContext.Current;

            NumberList = new List<string>() {
                "00119",
                "05651" ,
                "06274" ,
                "08363" ,
                "06802" ,
                "07882" ,
                "05754"  ,
                "06580" ,
                "06395"  ,
                "94017"  ,
                "94024"  ,
                "08295"  ,
                "94023"  ,
                "08166" ,
                "08181" ,
                "07735"  ,
                "94022"  ,
                "00264"  ,
                "94027"  ,
                "06919"  ,
                "08450"  ,
                "00100000"  ,
                "00100410" ,
                "00100415",
                "08011",
                "06775"
                                        };

            txb_count.Text = NumberList.Count.ToString();
        }
        
        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(NumberList.Count == 0) { return; }
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

        async void  changeNumber()
        {
            OnUpdateUI(() => { btn_start.IsEnabled = false; });
            Random random = new Random();
            int delayTime = 10;
            for (int i = 0; i < 25; i++)
            {
                int index = random.Next(0, NumberList.Count);
                string theNumber = NumberList[index];

                int randomNumber1 = 0;
                int randomNumber2 = 0;
                int randomNumber3 = 0;
                int randomNumber4 = 0;
                int randomNumber5 = 0;
                int randomNumber6 = 0;
                int randomNumber7 = 0;
                int randomNumber8 = 0;


                int len = System.Text.Encoding.UTF8.GetBytes(theNumber).Length;
                if (len == 5)
                {
                    randomNumber1 = int.Parse(theNumber[0].ToString());
                    randomNumber2 = int.Parse(theNumber[1].ToString());
                    randomNumber3 = int.Parse(theNumber[2].ToString());
                    randomNumber4 = int.Parse(theNumber[3].ToString());
                    randomNumber5 = int.Parse(theNumber[4].ToString());

                    randomNumber6 = 11;
                    randomNumber7 = 11;
                    randomNumber8 = 11;
                }
                else if(len == 8)
                {
                    randomNumber1 = int.Parse(theNumber[0].ToString());
                    randomNumber2 = int.Parse(theNumber[1].ToString());
                    randomNumber3 = int.Parse(theNumber[2].ToString());
                    randomNumber4 = int.Parse(theNumber[3].ToString());
                    randomNumber5 = int.Parse(theNumber[4].ToString());

                    randomNumber6 = int.Parse(theNumber[5].ToString());
                    randomNumber7 = int.Parse(theNumber[6].ToString());
                    randomNumber8 = int.Parse(theNumber[7].ToString());
                }


                OnUpdateUI(() => { image1.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber1.ToString() + ".png")); });
               
                
                OnUpdateUI(() => { image2.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber2.ToString() + ".png")); });
               
                
                OnUpdateUI(() => { image3.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber3.ToString() + ".png")); });
               
               
                OnUpdateUI(() => { image4.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber4.ToString() + ".png")); });
                
                
                OnUpdateUI(() => { image5.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber5.ToString() + ".png")); });
               
                
                OnUpdateUI(() => { image6.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber6.ToString() + ".png")); });

                
                OnUpdateUI(() => { image7.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber7.ToString() + ".png")); });

                
                OnUpdateUI(() => { image8.Source = new BitmapImage(new Uri("pack://application:,,,/pic/" + randomNumber8.ToString() + ".png")); });

                await Task.Delay(delayTime);
                delayTime += 5;

                if(i == 24)
                {
                    NumberList.Remove(theNumber);
                }

            }

            OnUpdateUI(() => { txb_count.Text = NumberList.Count.ToString(); });

            OnUpdateUI(() => { btn_start.IsEnabled = true; });
        }

        public void OnUpdateUI(Action action)
        {
            SyncContext.Post(new SendOrPostCallback(o =>
            {
                action();
            }), null);
        }




    }
}
