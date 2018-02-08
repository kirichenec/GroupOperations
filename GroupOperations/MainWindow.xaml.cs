using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace GroupOperations
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Включение уведомлений об изменениях свойств
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region ChangeFormat | Показыват, нужно ли менять формат
        private bool changeFormat = false;
        /// <summary>
        /// Показыват, нужно ли менять формат
        /// (True - менять, False - добавить)
        /// </summary>
        public bool ChangeFormat
        {
            get { return changeFormat; }
            set { changeFormat = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region CroppingProgressCompletion
        private float _croppingProgressCompletion;

        public float CroppingProgressCompletion
        {
            get { return _croppingProgressCompletion; }
            set { _croppingProgressCompletion = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region FolderPath | Путь папки для переименования
        private string folderPath = "";
        /// <summary>
        /// Путь папки для переименования
        /// </summary>
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region FolderFiles | Список названий файлов
        private List<string> folderFiles;
        /// <summary>
        /// Список названий файлов
        /// </summary>
        public List<string> FolderFiles
        {
            get { return folderFiles; }
            set { folderFiles = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region Formats | Список форматов
        private List<string> formats = new List<string>() { ".jpg", ".png", ".txt" };
        /// <summary>
        /// Список форматов
        /// </summary>
        public List<string> Formats
        {
            get { return formats; }
            set { formats = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region IsCropped | Произвождится нарезка
        private bool _isCropping = false;

        /// <summary>
        /// Произвождится нарезка
        /// </summary>
        public bool IsCropping
        {
            get { return _isCropping; }
            set { _isCropping = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region ProgressCompletion | Прогресс выполнения переименования
        private double progressCompletion = 0;
        /// <summary>
        /// Прогресс выполнения переименования
        /// </summary>
        public double ProgressCompletion
        {
            get { return progressCompletion; }
            set { progressCompletion = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region RenamingOff | В данный момент нисего не переименовывается
        private bool renamingOff = true;
        /// <summary>
        /// В данный момент нисего не переименовывается
        /// </summary>
        public bool RenamingOff
        {
            get { return renamingOff; }
            set { renamingOff = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region SelectedFormat | Выбранный формат
        private string selectedFormat = "";
        /// <summary>
        /// Выбранный формат
        /// </summary>
        public string SelectedFormat
        {
            get { return selectedFormat; }
            set { selectedFormat = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region WinState
        private string wState = WindowState.Normal.ToString();

        public string WinState
        {
            get { return wState; }
            set { wState = value; NotifyPropertyChanged(); }
        }
        #endregion

        #endregion

        #region GetLocatoinButton_Click | Установка папки
        /// <summary>
        /// Установка папки
        /// </summary>
        private void GetLocatoinButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.FolderPath = folderDialog.SelectedPath;
            }
        }
        #endregion

        #region AddFormatButton_Click | Переименование файлов
        /// <summary>
        /// Нажатие на кнопку переименования файлов
        /// </summary>
        private void AddFormatButton_Click(object sender, RoutedEventArgs e)
        {
            new Task(RenameMethod).Start();
        }
        #endregion

        #region RenameMethod | Переименование файлов
        /// <summary>
        /// Переименование файлов
        /// </summary>
        private void RenameMethod()
        {
            this.RenamingOff = false;
            this.FolderFiles = new List<string>();
            float progress = 0;
            this.ProgressCompletion = progress;
            try
            {
                var files = Directory.GetFiles(this.FolderPath);
                foreach (string file in files)
                {
                    if (this.ChangeFormat)
                    {
                        if (System.IO.Path.GetExtension(file) != System.IO.Path.GetExtension(this.SelectedFormat))
                        {
                            var newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file) + this.SelectedFormat);
                            File.Move(file, newPath);
                        }
                    }
                    else
                    {
                        File.Move(file, file + this.SelectedFormat);
                    }
                    progress += (float)100 / files.Count();
                    this.ProgressCompletion += progress;
                }
            }
            catch
            {
            }
            this.RenamingOff = true;
            MessageBox.Show("Всё выполнено");
        }
        #endregion

        #region CropButton_Click | Нажатие на кнопку нарезки фото
        /// <summary>
        /// Нажатие на кнопку нарезки фото
        /// </summary>
        private void CropButton_Click(object sender, RoutedEventArgs e)
        {
            new Task(CroppingMethod).Start();
        }
        #endregion

        #region CroppingMethod | Метод нарезки фото
        /// <summary>
        /// Метод нарезки фото
        /// </summary>
        private void CroppingMethod()
        {
            this.IsCropping = true;
            this.FolderFiles = new List<string>();
            float progress = 0;
            this.CroppingProgressCompletion = progress;
            try
            {
                var files = Directory.GetFiles(this.FolderPath);
                foreach (string file in files)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file) + @"\Converted");
                    Bitmap src = Image.FromFile(file) as Bitmap;
                    int x = 0;
                    int i = 0;
                    while (x < src.Width)
                    {
                        i++;
                        Rectangle cropRect = new Rectangle(x, 0, src.Height, src.Height);
                        Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                        using (Graphics g = Graphics.FromImage(target))
                        {
                            g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                             cropRect,
                                             GraphicsUnit.Pixel);
                        }
                        var newPath = Path.GetDirectoryName(file) + @"\Converted\" + Path.GetFileNameWithoutExtension(file) + "_" + i.ToString() + ".png";//Path.GetExtension(file);
                        target.Save(newPath);
                        x += src.Height + 1;
                    }
                    progress += (float)100 / files.Count();
                    this.CroppingProgressCompletion += progress;
                }
            }
            catch
            {
            }
            this.IsCropping = false;
            MessageBox.Show("Всё выполнено");
        }
        #endregion

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.FolderPath);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximazeButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow.WindowState == WindowState.Normal)
                App.Current.MainWindow.WindowState = WindowState.Maximized;
            else if (App.Current.MainWindow.WindowState == WindowState.Maximized)
                App.Current.MainWindow.WindowState = WindowState.Normal;
            WinState = App.Current.MainWindow.WindowState.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
