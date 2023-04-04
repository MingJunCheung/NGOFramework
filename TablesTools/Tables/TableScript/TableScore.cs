//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg
{

public sealed partial class TableScore
{
    private readonly Dictionary<int, TableScoreData> _dataMap;
    private readonly List<TableScoreData> _dataList;
    
    public TableScore(JSONNode _json)
    {
        _dataMap = new Dictionary<int, TableScoreData>();
        _dataList = new List<TableScoreData>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = TableScoreData.DeserializeTableScoreData(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, TableScoreData> DataMap => _dataMap;
    public List<TableScoreData> DataList => _dataList;

    public TableScoreData GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public TableScoreData Get(int key) => _dataMap[key];
    public TableScoreData this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    
    partial void PostInit();
    partial void PostResolve();
}

}