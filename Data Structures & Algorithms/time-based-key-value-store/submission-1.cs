public class TimeMap {

    private record DataPoint (int Timestamp, string Value);

    private Dictionary<string, List<DataPoint>> _data = [];

    public TimeMap() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        // All the timestamps of set are strictly increasing.

        if(_data.TryGetValue(key, out var dataList)) {
            dataList.Add(new DataPoint(timestamp, value));
        } else {
            _data[key] = [new DataPoint(timestamp, value)];
        }
    }
    
    public string Get(string key, int timestamp) {
        if(_data.TryGetValue(key, out var dataList)) {
            // dataList is an time-ordered List of values
            // Returns a value such that set was called previously, with timestamp_prev <= timestamp
            int n = dataList.Count;

            int l = 0, r = n - 1;

            while (l <= r) {
                
                int m = l + (r - l)/2;
                
                if(dataList[m].Timestamp < timestamp) {
                    l = m + 1;
                } else if (dataList[m].Timestamp > timestamp) {
                    r = m - 1;
                } else { // dataList[m].Timestamp == timestamp
                    return dataList[m].Value;
                }
            }

            return (r >= 0 /*&& dataList[r].Timestamp <= timestamp*/) ? dataList[r].Value : "" ;
            
        } else {
            //  If there are no values, it returns "".
            return "";
        }
    }
}