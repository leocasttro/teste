using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public class RootObject
{
    public List<Data>? Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
}

public class Data
{
    [JsonPropertyName("_id")]
    public Id Id { get; set; } 
    public string? Nome { get; set; }
    public string? Site { get; set; }
    public bool Active { get; set; }
}

public class Id
{
    [JsonPropertyName("$oid")]
    [DataMember(Name = "$oid")]
    public string Oid { get; set; }
}



public class DataPost 
{
    public string? Nome { get; set; }
    public string? Site { get; set; }
    public string? CreatedByUser { get; set; }
}

[DataContract]
public class DataUpdate
{
    [DataMember(Name = "_id")]
    public IdUpdate Id { get; set; } 

    [DataMember]
    public string? Nome { get; set; }

    [DataMember]
    public string? Site { get; set; }

    [DataMember]
    public bool Active { get; set; }
}


[DataContract]
public class IdUpdate
{

    [DataMember(Name = "$oid")]
    public string Oid { get; set; }
}