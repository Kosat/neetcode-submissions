// My first attempt, after refinements
// Mistakes with Sorting by TimeToTarget instead of Position DESC
// Mistake when calcualting TimeToTarget as Integer instead of Double

public class Solution {

    record Car {
        public int Position;
        public int Speed;
        public double TimeToTarget;
    }

    public int CarFleet(int target, int[] position, int[] speed) {
        
        int carsCount = position.Length;
        
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

        var carsComparer = Comparer<Car>.Create((Car c1, Car c2) => c2.Position.CompareTo(c1.Position));
        carsSortedByTTT.Sort(carsComparer);

        Stack<Car> cars = [];
        int fleetsCount = 0;
        foreach (var car in carsSortedByTTT) {
            if(cars.Count == 0 || car.TimeToTarget > cars.Peek().TimeToTarget) {
                cars.Push(car);
                fleetsCount++;
            }
        }     

        return fleetsCount;
    }
}
