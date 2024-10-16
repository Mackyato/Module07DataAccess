using Module07DataAccess.Services;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace Module07DataAccess
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        private readonly DatabaseConnectionService _dbConnectionService;

        public MainPage()
        {
            InitializeComponent();

            //initiliaze the database connection
            _dbConnectionService = new DatabaseConnectionService();
        }


        private async void OnTestConnectionClicked(object sender, EventArgs e)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    ConnectionStatuslLabel.Text = "Connection Successful!";
                    ConnectionStatuslLabel.TextColor = Colors.Green;
                }
            }
            catch(Exception ex)
            {
                ConnectionStatuslLabel.Text = $"Connection Failed: {ex.Message}";
                ConnectionStatuslLabel.TextColor = Colors.Red;
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
