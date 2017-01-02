using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarinForms.Data.Models;
using Xamarin.Forms;

namespace XamarinToDo
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ToDoItem> toDoItemList;
        private ObservableCollection<ToDoItem> GetItemList()
        {
            if (toDoItemList == null)
                toDoItemList = new ObservableCollection<ToDoItem>() {
                new ToDoItem() {Text = "Nuevo", Status = eItemStatus.New },
                new ToDoItem() {Text = "Hecho", Status = eItemStatus.Done }
                };
            return toDoItemList;

        }
        public MainPage()
        {
            InitializeComponent();
            toDoList.ItemsSource = GetItemList();

        }
        void AddItem(object sender, EventArgs args)
        {
            var toDoItem = new ToDoItem();
            toDoItem.Text = newItem.Text;
            toDoItem.Status = eItemStatus.New;

            var toDos = GetItemList();
            toDos.Add(toDoItem);

            //Clear input
            newItem.Text = "";
        }
        void RemoveItem(object sender, EventArgs args)
        {
            var button = (Xamarin.Forms.Button)sender;
            var toDos = GetItemList();            
            toDos.Remove(toDos.FirstOrDefault(x => x.Text == button.CommandParameter.ToString()));
        }
    }
}
