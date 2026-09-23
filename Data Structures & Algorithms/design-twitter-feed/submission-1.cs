public class Twitter
{
    Dictionary<int, HashSet<int>> _following;
    Dictionary<int, List<(long time, int tweetId)>> _tweetsByAuthor;
    long _postCount = 0;


    public Twitter()
    {
        // Example 1: Input: ["Twitter", "postTweet", [1, 10], "postTweet", [2, 20], "getNewsFeed", [1], "getNewsFeed", [2], "follow", [1, 2], "getNewsFeed", [1], "getNewsFeed", [2], "unfollow", [1, 2], "getNewsFeed", [1]] Output: [null, null, null, [10], [20], null, [20, 10], [20], null, [10]]
        // LeetCode pattern: Heap / Priority Queue
        _following = [];
        _tweetsByAuthor = [];
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (_tweetsByAuthor.TryGetValue(userId, out var tweets))
        {
            tweets.Add((_postCount++, tweetId));
        }
        else
        {
            List<(long time, int tweetId)> newList = [];
            newList.Add((_postCount++, tweetId));
            _tweetsByAuthor[userId] = newList;

        }
    }

    // Complexity: O(m*n*log(n*m)) time, O(n*m) extra space, where m - number of followees userId has, n - tweets per followee
    public List<int> GetNewsFeed(int userId)
    {
        List<int> result = [];

        PriorityQueue<int, long> newsFeedQueue = new(Comparer<long>.Create((x, y) => y.CompareTo(x)));

        if (_following.TryGetValue(userId, out HashSet<int> followeeIds))
        {
            foreach (var followeeId in followeeIds)
            {
                if (_tweetsByAuthor.TryGetValue(followeeId, out List<(long time, int tweetId)> followingTweets))
                {
                    foreach (var followingTweet in followingTweets)
                    {
                        newsFeedQueue.Enqueue(followingTweet.tweetId, followingTweet.time);
                    }
                }
            }
        }

        if (_tweetsByAuthor.TryGetValue(userId, out List<(long time, int tweetId)> tweets))
        {
            foreach (var tweet in tweets)
            {
                newsFeedQueue.Enqueue(tweet.tweetId, tweet.time);
            }
        }

        int n = 10;
        while (n > 0 && newsFeedQueue.Count > 0)
        {
            result.Add(newsFeedQueue.Dequeue());
            n--;
        }

        return result;
    }


    // Complexity: O(1) time, O(1) extra space
    public void Follow(int followerId, int followeeId)
    {
        if (followeeId == followerId)
        {
            return;
        }

        if (!_following.ContainsKey(followerId))
        {
            _following[followerId] = [];
        }
        _following[followerId].Add(followeeId);
    }

    // Complexity: O(1) time, O(1) extra space
    public void Unfollow(int followerId, int followeeId)
    {
        if (followeeId == followerId)
        {
            return;
        }

        if (_following.ContainsKey(followerId))
        {
            _following[followerId].Remove(followeeId);
        }
    }
}
