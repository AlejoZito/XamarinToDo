using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinToDo.Model;
using Xamarin.Forms;
using XamarinToDo.Services;

namespace XamarinToDo.View
{
    public partial class ToDoPage : ContentPage
    {
        TodoItemManager manager;

        private ObservableCollection<TodoItem> toDoItemList = new ObservableCollection<TodoItem>();


        public ToDoPage()
        {
            InitializeComponent();
            manager = TodoItemManager.DefaultManager;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                await RefreshItems(false, true);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + ex.Message + ")", "OK");
            }
            finally
            {
                todoList.EndRefresh();
            }
        }

        // Data methods
        async Task AddItem(TodoItem item)
        {
            await manager.SaveTaskAsync(item);
            todoList.ItemsSource = await manager.GetTodoItemsAsync();
        }

        async Task CompleteItem(TodoItem item)
        {
            item.Done = true;
            await manager.SaveTaskAsync(item);
            todoList.ItemsSource = await manager.GetTodoItemsAsync();
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            var todo = new TodoItem { Name = newItemName.Text };
            await AddItem(todo);

            newItemName.Text = string.Empty;
            newItemName.Unfocus();
        }

        // Event handlers

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#context
        public async void OnComplete(object sender, EventArgs e)
        {
            var mi = ((Button)sender);
            var todo = mi.CommandParameter as TodoItem;
            await CompleteItem(todo);
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false, true);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

        public async void OnSyncItems(object sender, EventArgs e)
        {
            await RefreshItems(true, true);
        }

        private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, true))
            {
                todoList.ItemsSource = await manager.GetTodoItemsAsync(syncItems);
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
        //async void AddItem(object sender, EventArgs args) {

        //    var toDoItem = new TodoItem();
        //    toDoItem.Name = newItem.Text;

        //    toDoItemList.Add(toDoItem);

        //    await RefreshList();

        //    //Clear input
        //    newItem.Text = "";
        //}
        //async void RemoveItem(object sender, EventArgs args)
        //{
        //    var button = (Xamarin.Forms.Button)sender;
        //    var toDos = RefreshList();
        //    toDoItemList.Remove(toDoItemList.FirstOrDefault(x => x.Name == button.CommandParameter.ToString()));
        //    await RefreshList();
        //}
        //void OnColorSlideChange(object sender, EventArgs args)
        //{
        //    var red = sliderRed.Value;
        //    newItem.BackgroundColor = Color.FromRgb(red, 0, 0);
        //    newItem.TextColor = Color.FromRgb(red, red, red);
        //}
    }
}
