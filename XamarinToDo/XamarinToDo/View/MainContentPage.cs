//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using XamarinToDo.Model;
//using Xamarin.Forms;

//namespace XamarinToDo
//{
//    public class MainContentPage : ContentPage
//    {
//        private Label labelTitle;
//        private Entry noteEntry;
//        private Button btnAdd;
//        private ObservableCollection<TodoItem> toDoItemList;
//        private ObservableCollection<TodoItem> GetItemList()
//        {
//            if (toDoItemList == null)
//                toDoItemList = new ObservableCollection<TodoItem>() {
//                new TodoItem() {Text = "Nuevo" },
//                new TodoItem() {Text = "Hecho" }
//                };
//            return toDoItemList;

//        }
//        public MainContentPage()
//        {
//            labelTitle = new Label
//            {
//                Text = "Xamarin Test - ToDo List",
//            };
//            noteEntry = new Entry
//            {
//                Placeholder = "Ingrese una nueva nota"
//            };
//            btnAdd = new Button
//            {
//                Text = "+"
//            };
//            btnAdd.Clicked += BtnAdd_Clicked;
//            var toDoListView = new ListView
//            {
//                ItemsSource = GetItemList().Select(x=>x.Text)
//            };
//            Content = new StackLayout()
//            {
//                Padding = 10,
//                Spacing = 25,
//                Children = { labelTitle, noteEntry, btnAdd, toDoListView}
//            };
//        }

//        private void BtnAdd_Clicked(object sender, EventArgs e)
//        {
//            var toDoItem = new TodoItem();
//            toDoItem.Text = noteEntry.Text;

//            var toDos = GetItemList();
//            toDos.Add(toDoItem);

//            //Clear input
//            noteEntry.Text = "";
//        }
//    }
//}
