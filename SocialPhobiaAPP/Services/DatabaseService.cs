using SocialPhobiaAPP.Models;
using SQLite;


namespace SocialPhobiaAPP.Services
{
    public sealed class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        private readonly Task _initTask;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyJournal.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            _initTask = InitializeAsync();
        }

        public async Task<List<JournalEntry>> GetEntriesAsync()
        {
            await EnsureInitializedAsync();
            return await _database.Table<JournalEntry>().ToListAsync();
        }

        private async Task EnsureInitializedAsync()
        {
            await _initTask;
        }
        private async Task InitializeAsync()
        {
            await _database.CreateTableAsync<JournalEntry>();
        }

        public async Task SaveEntryAsync(JournalEntry entry)
        {
            await EnsureInitializedAsync();
            // Pokud záznam už má ID, aktualizujeme, jinak vložíme nový
            if (entry.ID != 0)
                await _database.UpdateAsync(entry);
            else
                await _database.InsertAsync(entry);
        }

        public async Task DeleteEntryAsync(JournalEntry entry)
        {
            await EnsureInitializedAsync();
            await _database.DeleteAsync(entry);
        }

        public async Task UpdateEntryAsync(JournalEntry entry)
        {
            await EnsureInitializedAsync();
            await _database.UpdateAsync(entry);
        }

        public async Task ClearAllEntriesAsync()
        {
            await EnsureInitializedAsync();
            await _database.DeleteAllAsync<JournalEntry>();
        }
    }

}

