using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для ToolBar.xaml
    /// </summary>
    public partial class ToolBar : UserControl
    {
//        #region LabelText
//        /// <summary>
//        /// Свойство текста в текстовом блоке
//        /// </summary>
//        public string LabelText
//        {
//            get { return (string)GetValue(LabelTextProperty); }
//            set { SetValue(LabelTextProperty, value); }
//        }

//        public static readonly DependencyProperty LabelTextProperty =
//            DependencyProperty.Register("LabelText", typeof(string), typeof(ToolBar), new PropertyMetadata(null));
//        #endregion
//        #region ItemSource
//        /// <summary>
//        /// Источник для ComboBox
//        /// </summary>
//        public IEnumerable ItemSource
//        {
//            get { return (IEnumerable)GetValue(ItemSourceProperty); }
//            set { SetValue(ItemSourceProperty, value); }
//        }

//        public static readonly DependencyProperty ItemSourceProperty =
//            DependencyProperty.Register("ItemSource", typeof(IEnumerable), typeof(ToolBar), new PropertyMetadata(default(IEnumerable), OnItemsSourceChanged, ItemsCoerceValue));

//        private static object ItemsCoerceValue(DependencyObject d, object baseValue) => baseValue;

//        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        
//#endregion
//        #region SelectedValuePath
//        /// <summary>
//        /// наименование поля для выбранного значения в ComboBox
//        /// </summary>
//        public string SelectedValuePath
//        {
//            get { return (string)GetValue(SelectedValuePathProperty); }
//            set { SetValue(SelectedValuePathProperty, value); }
//        }

//        public static readonly DependencyProperty SelectedValuePathProperty =
//            DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(ToolBar),new PropertyMetadata(null));
//        #endregion
//        #region SelectedItemIndex
//        /// <summary>
//        /// Отображаемое поле для пользователя в ComboBox
//        /// </summary>
//        //public int SelectedItemIndex
//        //{
//        //    get { return (int)GetValue(SelectedItemIndexProperty); }
//        //    set { SetValue(SelectedItemIndexProperty, value); }
//        //}

//        //public static readonly DependencyProperty SelectedItemIndexProperty =
//        //    DependencyProperty.Register("SelectedItemIndex", typeof(int), typeof(ToolBar)
//        //        , new FrameworkPropertyMetadata(default(int), flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
//        #endregion 
//        #region ViewPropertyPath
//        /// <summary>
//        /// Всплывающая подсказка при наведении на элемент ComboBox
//        /// </summary>
//        public string ViewPropertyPath
//        {
//            get => (string)GetValue(ViewPropertyPathProperty); 
//            set => SetValue(ViewPropertyPathProperty, value); 
//        }

//        public static readonly DependencyProperty ViewPropertyPathProperty =
//            DependencyProperty.Register("ViewPropertyPath", typeof(string), typeof(ToolBar),new PropertyMetadata(null));
//        #endregion
//        #region SelectedItem
//        public object SelectedItem
//        {
//            get { return (object)GetValue(SelectedItemProperty); }
//            set { SetValue(SelectedItemProperty, value); }
//        }

//        public static readonly DependencyProperty SelectedItemProperty =
//            DependencyProperty.Register("SelectedItem", typeof(object), typeof(ToolBar), new PropertyMetadata(null));
//        #endregion
//        #region ItemTemplate
//        public DataTemplate ItemTemplate
//        {
//            get { return (DataTemplate)GetValue(ItemTeplateProperty); }
//            set { SetValue(ItemTeplateProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for ItemTeplate.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty ItemTeplateProperty =
//            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ToolBar), new PropertyMetadata(default(DataTemplate)));

//        #endregion
//        #region AddCommand
//        public ICommand AddCommand
//        {
//            get { return (ICommand)GetValue(AddCommandProperty); }
//            set { SetValue(AddCommandProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for AddComman.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty AddCommandProperty =
//            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(ToolBar), new PropertyMetadata(default(ICommand)));
//        #endregion
//        #region UpdateCommand
//        public ICommand UpdateCommand
//        {
//            get { return (ICommand)GetValue(UpdateCommandProperty); }
//            set { SetValue(UpdateCommandProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for AddComman.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty UpdateCommandProperty =
//            DependencyProperty.Register("UpdateCommand", typeof(ICommand), typeof(ToolBar), new PropertyMetadata(default(ICommand)));
//        #endregion
//        #region DeleteCommand
//        public ICommand DeleteCommand
//        {
//            get { return (ICommand)GetValue(DeleteCommandProperty); }
//            set { SetValue(DeleteCommandProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty DeleteCommandProperty =
//            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(ToolBar), new PropertyMetadata(default(ICommand)));

//        #endregion
        public ToolBar()=>InitializeComponent();
    }
}
