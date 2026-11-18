using Microsoft.Data.Sqlite;

// Los datos de ejemplo se insertan de nuevo en cada ejecución.
var filamentos = new[]
{
    
    (Material: "PLA", Color: "Rojo", PesoGramos: 1000),
    (Material: "PETG", Color: "Azul", PesoGramos: 750),
    (Material: "ABS", Color: "Negro", PesoGramos: 500)
};

using (var connection = new SqliteConnection("Data Source=inventario_3d.db"))
{
    connection.Open();

    // Crea la tabla si hace falta y vacía el inventario anterior.
    using (SqliteCommand setupCommand = connection.CreateCommand())
    {
        setupCommand.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Filamentos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Material TEXT,
                Color TEXT,
                PesoGramos INT
            );
            DELETE FROM Filamentos;
            """;
        setupCommand.ExecuteNonQuery();
    }

    // Inserta cada filamento con parámetros para separar los datos del SQL.
    foreach (var filamento in filamentos)
    {
        using (SqliteCommand insertCommand = connection.CreateCommand())
        {
            insertCommand.CommandText =
                """
                INSERT INTO Filamentos (Material, Color, PesoGramos)
                VALUES ($material, $color, $pesoGramos);
                """;
            insertCommand.Parameters.AddWithValue("$material", filamento.Material);
            insertCommand.Parameters.AddWithValue("$color", filamento.Color);
            insertCommand.Parameters.AddWithValue("$pesoGramos", filamento.PesoGramos);
            insertCommand.ExecuteNonQuery();
        }
    }

    // Lee y muestra todos los filamentos guardados.
    using (SqliteCommand selectCommand = connection.CreateCommand())
    {
        selectCommand.CommandText =
            "SELECT Material, Color, PesoGramos FROM Filamentos ORDER BY Id;";

        using (SqliteDataReader reader = selectCommand.ExecuteReader())
        {
            Console.WriteLine("Inventario de filamentos:");
            Console.WriteLine("Material | Color | Peso (g)");
            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader.GetString(0)} | {reader.GetString(1)} | {reader.GetInt32(2)}");
            }
        }
    }
}
