using Dapper;
using Microsoft.Data.Sqlite;

public interface ISQLite3Ctrl
{
    public SqliteConnection Sqlite3Conn { get; set; }
}

public class SQLite3Ctrl : ISQLite3Ctrl
{
    public SqliteConnection Sqlite3Conn { get; set; }
    IConfiguration cfg;

    public SQLite3Ctrl(IConfiguration config)
    {
        cfg = config;
        var cs = cfg.GetConnectionString("DatabaseConnection");
        Sqlite3Conn = new SqliteConnection(cs);

//todo: OK        Sqlite3Conn = new SqliteConnection("DataSource=" + Globals.DBName);
    }

    ~SQLite3Ctrl()
    {
        Sqlite3Conn.Dispose();
    }
}