﻿namespace candle_store_backend_app.Models
{
    public class Session
    {
        public string Id { get; set; } = "";

        public string Shop { get; set; } = "";

        public string? Token { get; set; } = "";

        public string? Scope { get; set; }
    }
}
