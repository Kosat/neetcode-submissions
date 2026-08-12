// My first attempt, after ALL the refinements. 

public class Solution {

    private record Car {
        public int Position;
        public double TimeToTarget; //KNOTE: Refined. Removed Speed.
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
                    TimeToTarget = ((double)target - position[i])/speed[i],
                }
            );
        }

        // Process front-to-back: car closest to target first.
        var carsComparer = Comparer<Car>.Create((Car c1, Car c2) => c2.Position.CompareTo(c1.Position));
        carsSortedByTTT.Sort(carsComparer);

        int fleetsCount = 0;
        double lastFleetTime = -1; // Refinement
        foreach (var car in carsSortedByTTT) {
            // You do not really need Stack here b/c you are only peeking the last item
            // So you can just save the lastFleetTime and use it
            if(car.TimeToTarget > lastFleetTime) {
                lastFleetTime = car.TimeToTarget;
                fleetsCount++;
            }
            // else: this car merges into the fleet ahead, no state change needed.
        }     

        return fleetsCount;
    }
}
