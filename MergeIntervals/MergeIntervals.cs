/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    List<Interval> returnList = new List<Interval>();
    public IList<Interval> Merge(IList<Interval> intervals) {
        if(intervals.Count == 0)
            return returnList;
        
        List<Interval> sorted = intervals.OrderBy(x => x.start).ToList();
        for(int i = 0; i < sorted.Count-1; i++) {
            Interval interval1 = sorted[i];
            Interval interval2 = sorted[i+1];
            if(interval1.end >= interval2.start) {
                interval2.start = Math.Min(interval1.start, interval2.start);
                interval2.end = Math.Max(interval1.end, interval2.end);
            } else {
                returnList.Add(sorted[i]);
            }
        }
        returnList.Add(sorted[sorted.Count-1]);
        
        return returnList;
    }
}