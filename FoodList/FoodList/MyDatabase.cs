using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace FoodList
{
    public class MyDatabase
    {
        readonly SQLiteAsyncConnection database;

        public MyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Food>().Wait();
        }

        public Task<int> SaveItemAsync(Food food)
        {
            if (food.ID != 0)
            {
                return database.UpdateAsync(food);
            }
            else
            {
                return database.InsertAsync(food);
            }
        }

        public Task<int> Insert(Food food)
        {
            return database.InsertAsync(food);
        }

        public Task<List<Food>> SelectAll()
        {
            return database.Table<Food>().ToListAsync();
        }

        public Task<int> DeleteItemAsync(Food food)
        {
            return database.DeleteAsync(food);
        }
        public Task<List<Food>> GetItemsBySearchAsync(string searchText)
        {
            return database.QueryAsync<Food>($"SELECT * FROM [Food] WHERE [Description] LIKE \'%{searchText}%\'");
        }
    }
}


