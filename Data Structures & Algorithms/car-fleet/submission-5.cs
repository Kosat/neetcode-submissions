// My first attempt, after some refinements. See Solution 3 for all the refinements applied.
// Mistakes with Sorting by TimeToTarget instead of Position DESC
// Mistake when calcualting TimeToTarget as Integer instead of Double

public class Solution {

    private record Car {
        public int Position;
        public int Speed; // KNOTE: You don't really use Speed. Remove it.
        public double TimeToTarget;
    }

    public int CarFleet(int target, int[] position, int[] speed) {
        
        int carsCount = position.Length;
        if (carsCount == 0) {
            return 0;
        }
        
        List<Car> carsSortedByTTT = [];

        for(int i=0; i < carsCount; i++) {
            carsSortedByTTT.Add(
                new Car() { 
                    Position = position[i],
                    Speed = speed[i],
                    TimeToTarget = ((double)target - position[i])/speed[i],
                }
            );
        }

        // Process front-to-back: car closest to target first.
        var carsComparer = Comparer<Car>.Create((Car c1, Car c2) => c2.Position.CompareTo(c1.Position));
        carsSortedByTTT.Sort(carsComparer);

        Stack<Car> cars = [];
        int fleetsCount = 0;
        foreach (var car in carsSortedByTTT) {
            // You do not really need Stack here b/c you are only peeking the last item
            // So you can just save the lastFleetTime and use it
            if(cars.Count == 0 || car.TimeToTarget > cars.Peek().TimeToTarget) {
                cars.Push(car);
                fleetsCount++;
            }
            // else: this car merges into the fleet ahead, no state change needed.
        }     

        return fleetsCount;
    }
}
