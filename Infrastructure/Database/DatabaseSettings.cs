﻿namespace NTT.CafeManagement.Infrastructure.Database
{
    public class DatabaseSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string Schema { get; set; }
        public string ConnectionString =>
            $@"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database};SearchPath={Schema}";
    }
}
