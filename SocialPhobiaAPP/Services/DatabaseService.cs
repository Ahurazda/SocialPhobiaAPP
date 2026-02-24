using SocialPhobiaAPP.Models;
using SQLite;


namespace SocialPhobiaAPP.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection? _database;

        async Task Init()
        {
            if (_database is not null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyJournal.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<JournalEntry>();
        }

        public async Task<List<JournalEntry>> GetEntriesAsync()
        {
            await Init();
            return await _database.Table<JournalEntry>().ToListAsync();
        }

        public async Task SaveEntryAsync(JournalEntry entry)
        {
            await Init();
            await _database.InsertAsync(entry);
        }

        public async Task DeleteEntryAsync(JournalEntry entry)
        {
            await Init();
            await _database.DeleteAsync(entry);
        }

        public async Task UpdateEntryAsync(JournalEntry entry)
        {
            
            await _database.UpdateAsync(entry);
        }

        public async Task ClearAllEntriesAsync()
        {
            await Init();
            await _database.DeleteAllAsync<JournalEntry>();
        }
    }
} 
