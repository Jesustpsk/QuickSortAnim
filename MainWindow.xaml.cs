
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace QuickSortAnim
{
    public partial class MainWindow : Window
    {
        private const int ArraySize = 59; // Размер сортируемого массива
        private const int Delay = 50; // Задержка анимации (в миллисекундах)

        private int SwapCount = 0;
        private bool isRed = false; // Переменная для отслеживания текущего цвета элементов
        private int[] array;
        private Rectangle[] rectangles;
        private Random random;

        public MainWindow()
        {
            InitializeComponent();

            InitializeArray();
            InitializeRectangles();
        }

        private void InitializeArray()
        {
            array = new int[ArraySize];
            random = new Random();
            TbArray.Text = "Initial array: {";
            for (var i = 0; i < ArraySize; i++)
            {
                array[i] = random.Next(1, 395); // Заполнение массива случайными числами от 1 до 100
                if(i != ArraySize - 1)
                    TbArray.Text += $"[{array[i]}], ";
                else
                    TbArray.Text += $"[{array[i]}]";
            }

            TbArray.Text += "}.";
        }

        private void InitializeRectangles()
        {
            rectangles = new Rectangle[ArraySize];

            for (var i = 0; i < ArraySize; i++)
            {
                rectangles[i] = new Rectangle
                {
                    Width = 10,
                    Height = array[i], // Высота прямоугольника соответствует элементу массива
                    Fill = Brushes.Blue
                };
                Canvas.SetTop(rectangles[i], 395 - rectangles[i].Height); // Расположение прямоугольника по оси Y
                Canvas.SetLeft(rectangles[i], i * 12); // Расположение прямоугольника по оси X

                canvas.Children.Add(rectangles[i]); // Добавление прямоугольника на Canvas
            }
        }

        private async Task QuickSortAnimation(int[] array, int low, int high)
        {
            if (low < high)
            {
                var pivotIndex = await PartitionAnimation(array, low, high);

                // Подсветка разделяемой части
                for (int i = low; i <= high; i++)
                {
                    rectangles[i].Fill = Brushes.DodgerBlue;
                    await Task.Delay(Delay);
                }

                // Подсветка элемента-медианы
                rectangles[pivotIndex].Fill = Brushes.Red;

                await QuickSortAnimation(array, low, pivotIndex - 1);
                await QuickSortAnimation(array, pivotIndex + 1, high);

                // Сброс подсветки
                for (var i = low; i <= high; i++)
                {
                    rectangles[i].Fill = Brushes.Blue;
                    await Task.Delay(Delay);
                }
                rectangles[pivotIndex].Fill = Brushes.Blue;
            }
        }

        private async Task<int> PartitionAnimation(int[] array, int low, int high)
        {
            var pivot = array[high]; // Опорный элемент
            var i = low - 1;

            for (var j = low; j < high; j++)
            {
                if (array[j] >= pivot) continue;
                i++;
                await SwapAnimation(i, j);
            }

            await SwapAnimation(i + 1, high);

            return i + 1;
        }

        private async Task SwapAnimation(int i, int j)
        {
            rectangles[i].Fill = Brushes.Green;
            rectangles[j].Fill = Brushes.Green;
            await Task.Delay(Delay);

            (array[i], array[j]) = (array[j], array[i]);
            SwapCount++;
            lSwap.Content = SwapCount;
            rectangles[i].Height = array[i]; // Обновление высоты прямоугольника
            rectangles[j].Height = array[j]; // Обновление высоты прямоугольника

            Canvas.SetTop(rectangles[i], 395 - rectangles[i].Height); // Обновление позиции прямоугольника
            Canvas.SetTop(rectangles[j], 395 - rectangles[j].Height); // Обновление позиции прямоугольника

            rectangles[i].Fill = Brushes.Blue;
            rectangles[j].Fill = Brushes.Blue;
        }

        private async void btnSort_Click(object sender, RoutedEventArgs e)
        {
            btnSort.IsEnabled = false; // Отключение кнопки сортировки
            await QuickSortAnimation(array, 0, ArraySize - 1);
            
            TbArray2.Text = "Output array: {";
            for (var i = 0; i < ArraySize; i++)
            {
                if(i != ArraySize - 1)
                    TbArray2.Text += $"[{array[i]}], ";
                else
                    TbArray2.Text += $"[{array[i]}]";
            }

            TbArray2.Text += "}.";
            btnSort.IsEnabled = true; // Включение кнопки сортировки
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            TbArray.Text = "";
            TbArray2.Text = "";
            SwapCount = 0;
            isRed = false;
            lSwap.Content = 0;
            canvas.Children.Clear();
            Array.Clear(array, 0, 59);
            Array.Clear(rectangles, 0, 59);
            InitializeArray();
            InitializeRectangles();
        }
    }
}