namespace RestaurantReservation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //  Application.Run(new SqlConnectionForm());
             Application.Run(new Login());
            // Application.Run(new SqlConnectionForm());
            //Application.Run(new MainMenuWindow());
            //Application.Run(new newMainForm());
            //Application.Run(new ActiveOrdersForm());
            // Application.Run(new SalesDashboard());
            //  Application.Run(new AccountsForm());
            //  Application.Run(new CreateOrderForm());
            //Application.Run(new PaymentForm());
        }
    }
}