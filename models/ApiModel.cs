using System.Text.Json.Serialization;
    public class RootObject
    {
        public List<Data> Data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("_id")]
        public Id Id { get; set; }

        [JsonPropertyName("DateCreated")]
        public DateCreated DateCreated { get; set; }

        [JsonPropertyName("DateModified")]
        public DateModified DateModified { get; set; }

        [JsonPropertyName("Active")]
        public bool Active { get; set; }

        [JsonPropertyName("CreatedByUser")]
        public string CreatedByUser { get; set; }

        [JsonPropertyName("ModifiedByUser")]
        public string ModifiedByUser { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Site")]
        public string Site { get; set; }

        [JsonPropertyName("Segmento")]
        public Segmento Segmento { get; set; }

        [JsonPropertyName("611edbfdfd5915f2ae005dc5")]
        public List<Segmento> Segmentos { get; set; }
    }

    public class Id
    {
        [JsonPropertyName("$oid")]
        public string Oid { get; set; }
    }

    public class DateCreated
    {
        [JsonPropertyName("$date")]
        public DateTime Date { get; set; }
    }

    public class DateModified
    {
        [JsonPropertyName("$date")]
        public DateTime Date { get; set; }
    }

    public class Segmento
    {
        [JsonPropertyName("$oid")]
        public string Oid { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Descrição")]
        public string Descricao { get; set; }
    }
